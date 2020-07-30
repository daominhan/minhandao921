using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Bangaubong.Models;
using Bangaubong;


namespace Bangaubong.Areas.Admin.Controllers
{
    public class TopicController : Controller
    {
        private BangaubongDBContext db = new BangaubongDBContext();

        // GET: Admin/Topic
        public ActionResult Index()
        {
            ViewBag.ListTopic = new SelectList(db.Topics, "Id", "Name");
            var model = db.Topics.Where(m => m.Status != 0);
            return View(model.ToList());
        }
        public ActionResult Trash()
        {
            ViewBag.ListTopic = new SelectList(db.Topics, "Id", "Name");
            var model = db.Topics.Where(m => m.Status == 0);
            return View(model.ToList());
        }

        // GET: Admin/Topic/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mtopic mtopic = db.Topics.Find(id);
            if (mtopic == null)
            {
                return HttpNotFound();
            }
            return View(mtopic);
        }

        // GET: Admin/Topic/Create
        public ActionResult Create()
        {
            List<SelectListItem> ListTopic = db.Topics.Select(x => new SelectListItem()
            {
                Value = x.Id.ToString(), // assumes Id is not already typeof string
                Text = x.Name
            }).ToList();
            ListTopic.Insert(0, new SelectListItem() { Value = "0", Text = "None" });
            ViewBag.ListTopic = ListTopic;
            return View();
        }

        // POST: Admin/Topic/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(FormCollection collection, Mtopic mtopic)
        {
            int user_id = (!Session["user_id"].Equals("")) ? Convert.ToInt32(Session["user_id"].ToString()) : 1;
            XString str = new XString();
            if (ModelState.IsValid)
            {
                mtopic.ParentId = Convert.ToInt32(collection["ListParentTopic"]);
                mtopic.Slug = str.ToAscii(mtopic.Name);
                mtopic.Created_at = DateTime.Now;
                mtopic.Updated_at = DateTime.Now;
                mtopic.Created_by = user_id;
                mtopic.Updated_by = user_id;
                db.Topics.Add(mtopic);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ListTopic = new SelectList(db.Topics, "Id", "Name");
            return View(mtopic);
        }

        // GET: Admin/Topic/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mtopic mtopic = db.Topics.Find(id);
            List<SelectListItem> ListTopic = db.Topics.Where(m => m.Status != 0).Select(x => new SelectListItem()
            {
                Value = x.Id.ToString(), // assumes Id is not already typeof string
                Text = x.Name
            }).ToList();
            ListTopic.Insert(0, new SelectListItem() { Value = "0", Text = "None" });
            ViewBag.ListTopic = ListTopic;
            if (mtopic == null)
            {
                return HttpNotFound();
            }
            return View(mtopic);
        }

        // POST: Admin/Topic/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(FormCollection collection, Mtopic mtopic)
        {
            int user_id = (!Session["user_id"].Equals("")) ? Convert.ToInt32(Session["user_id"].ToString()) : 1;
            XString str = new XString();
            if (ModelState.IsValid)
            {
                mtopic.ParentId = Convert.ToInt32(collection["ListParentTopic"]);
                mtopic.Slug = str.ToAscii(mtopic.Name);
                mtopic.Created_at = DateTime.Now;
                mtopic.Updated_at = DateTime.Now;
                mtopic.Created_by = user_id;
                mtopic.Updated_by = user_id;
                db.Entry(mtopic).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ListTopic = new SelectList(db.Topics, "Id", "Name");
            return View(mtopic);
        }

        // GET: Admin/Topic/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mtopic mtopic = db.Topics.Find(id);
            if (mtopic == null)
            {
                return HttpNotFound();
            }
            return View(mtopic);
        }

        // POST: Admin/Topic/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Mtopic mtopic = db.Topics.Find(id);
            db.Topics.Remove(mtopic);
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
            Mtopic mtopic = db.Topics.Find(id);
            if (mtopic.Status == 1)
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
            Mtopic mtopic = db.Topics.Find(id);
            if (mtopic.Status == 1)
            {
                mtopic.Status = 2;
            }
            else
            {
                mtopic.Status = 1;
            }
            db.Entry(mtopic).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Deltrash(int id)
        {
            Mtopic mtopic = db.Topics.Find(id);
            mtopic.Status = 0;
            db.Entry(mtopic).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index", "Topic");
        }
        public ActionResult Retrash(int id)
        {
            Mtopic mtopic = db.Topics.Find(id);
            mtopic.Status = 2;
            db.Entry(mtopic).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Trash", "Topic");
        }
        public string NameTopic(int id)
        {
            Mtopic mtopic = db.Topics.Find(id);
            if (mtopic != null)
            {
                return mtopic.Name.ToString();
            }
            return "None";
        }
    }
}
