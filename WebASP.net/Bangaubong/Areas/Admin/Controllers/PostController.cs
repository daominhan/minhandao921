using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Bangaubong.Models;

namespace Bangaubong.Areas.Admin.Controllers
{
    public class PostController : Controller
    {
        private BangaubongDBContext db = new BangaubongDBContext();

        // GET: Admin/Post
        public ActionResult Index()
        {
            ViewBag.ListTopics = new SelectList(db.Topics, "Id", "Name");
            var model = db.Posts.Where(m => m.Status != 0);
            return View(model.ToList());
        }

        public ActionResult Trash()
        {
            ViewBag.ListTopics = new SelectList(db.Topics, "Id", "Name");
            var model = db.Posts.Where(m => m.Status == 0);
            return View(model.ToList());
        }

        // GET: Admin/Post/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mpost mpost = db.Posts.Find(id);
            if (mpost == null)
            {
                return HttpNotFound();
            }
            return View(mpost);
        }

        // GET: Admin/Post/Create
        public ActionResult Create()
        {
            ViewBag.ListTopics = new SelectList(db.Topics, "Id", "Name");
            return View();
        }

        // POST: Admin/Post/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(FormCollection collection, Mpost mpost)
        {
            int user_id = (!Session["user_id"].Equals("")) ? Convert.ToInt32(Session["user_id"].ToString()) : 1;
            XString str = new XString();
            if (ModelState.IsValid)
            {
                mpost.TopId = collection["ListTopics"];
                mpost.Slug = str.ToAscii(mpost.Title);
                mpost.Created_at = DateTime.Now;
                mpost.Created_by = 1;
                mpost.Updated_at = DateTime.Now;
                mpost.Updated_by = 1;
                var file = Request.Files["fileimg"];
                if (file != null && file.ContentLength > 0)
                {
                    mpost.Img = file.FileName.ToString();
                    string path = System.IO.Path.Combine(Server.MapPath("~/Images/product/"), file.FileName.ToString());
                    file.SaveAs(path);
                    db.Posts.Add(mpost);
                    db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            ViewBag.ListTopics = new SelectList(db.Topics, "Id", "Name");
            return View(mpost);
        }

        // GET: Admin/Post/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mpost mpost = db.Posts.Find(id);
            ViewBag.ListTopics = new SelectList(db.Topics, "Id", "Name");
            if (mpost == null)
            {
                return HttpNotFound();
            }
            return View(mpost);
        }

        // POST: Admin/Post/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(FormCollection collection, Mpost mpost)
        {
            int user_id = (!Session["user_id"].Equals("")) ? Convert.ToInt32(Session["user_id"].ToString()) : 1;
            XString str = new XString();
            if (ModelState.IsValid)
            {
                mpost.TopId = collection["ListTopics"];
                mpost.Slug = str.ToAscii(mpost.Title);
                mpost.Created_at = DateTime.Now;
                mpost.Created_by = user_id;
                mpost.Updated_at = DateTime.Now;
                mpost.Updated_by = user_id;
                db.Entry(mpost).State = EntityState.Modified;
                var file = Request.Files["fileimg"];
                if (file != null && file.ContentLength > 0)
                {
                    mpost.Img = file.FileName.ToString();
                    string path = Server.MapPath("~/Images/product/") + file.FileName.ToString();
                    file.SaveAs(path);
                    db.SaveChanges();
                }
                else
                {
                    db.Entry(mpost).State = EntityState.Modified;
                    db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            ViewBag.ListTopics = new SelectList(db.Topics, "Id", "Name");
            return View(mpost);
        }

        // GET: Admin/Post/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mpost mpost = db.Posts.Find(id);
            if (mpost == null)
            {
                return HttpNotFound();
            }
            return View(mpost);
        }

        // POST: Admin/Post/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Mpost mpost = db.Posts.Find(id);
            db.Posts.Remove(mpost);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
        public string ShowStatus(int id)
        {
            string strStatus = "";
            Mpost mpost = db.Posts.Find(id);
            if (mpost.Status == 1)
            {
                strStatus = "<span class='btn btn-info btn-sm' ><i class='fas fa-toggle-on'></i>TT</span>";
            }
            else
            {
                strStatus = "<span class='btn btn-danger btn-sm' ><i class=' fas fa-toggle-off'></i>TT</span>";
            }
            return strStatus;
        }

        public ActionResult Status(int id)
        {
            Mpost mpost = db.Posts.Find(id);
            if (mpost.Status == 1)
            {
                mpost.Status = 2;
            }
            else
            {
                mpost.Status = 1;
            }
            db.Entry(mpost).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Deltrash(int id)
        {
            Mpost mpost = db.Posts.Find(id);
            mpost.Status = 0;
            db.Entry(mpost).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index", "Post");
        }
        public ActionResult Retrash(int id)
        {
            Mpost mpost = db.Posts.Find(id);
            mpost.Status = 2;
            db.Entry(mpost).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Trash", "Post");
        }
        
        public string NameTps(int id) // tên topic
        {
            Mtopic item = db.Topics.Find(id);
            if (item != null)
            {
                return item.Name.ToString();
            }
            return "None";
        }
    }
}
