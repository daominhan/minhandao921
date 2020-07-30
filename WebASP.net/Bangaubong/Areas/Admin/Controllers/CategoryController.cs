using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Bangaubong.Models;
using PagedList;

namespace Bangaubong.Areas.Admin.Controllers
{
    public class CategoryController : Controller
    {
        private BangaubongDBContext db = new BangaubongDBContext();

        // GET: Admin/Category
        public ActionResult Index(int? page)
        {
            var pageNumber = (page ?? 1);
            var pageSize = 10;
            var list=db.Categories.Where(m=>m.Status!=0).OrderByDescending(m=>m.Updated_at).ToPagedList(pageNumber,pageSize);
            return View(list);
        }

        // GET: Admin/Category/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mcategory mcategory = db.Categories.Find(id);
            if (mcategory == null)
            {
                return HttpNotFound();
            }
            return View(mcategory);
        }

        // GET: Admin/Category/Create
        public ActionResult Create()
        {
            ViewBag.Listcat = new SelectList(db.Categories, "Id", "Name");
            return View();
        }

        // POST: Admin/Category/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(FormCollection collection, Mcategory model)
        {
            int user_id = (!Session["user_id"].Equals("")) ? Convert.ToInt32(Session["user_id"].ToString()) : 1;
            XString mystr = new XString();
            if (ModelState.IsValid)
            {
                model.ParentId = Convert.ToInt32(collection["Listcat"]);
                model.Slug = mystr.ToAscii(model.Name);
                model.Created_at = DateTime.Now;
                model.Created_by = user_id;
                model.Updated_at = DateTime.Now;
                model.Updated_by = user_id;
                db.Categories.Add(model);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Listcat = new SelectList(db.Categories, "id", "Name");

            return View(model);
        }

        // GET: Admin/Category/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mcategory mcategory = db.Categories.Find(id);
            if (mcategory == null)
            {
                return HttpNotFound();
            }
            ViewBag.ListCat = new SelectList(db.Categories, "id", "Name");
            return View(mcategory);
        }

        // POST: Admin/Category/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Mcategory mcategory)
        {
            int user_id = (!Session["user_id"].Equals("")) ? Convert.ToInt32(Session["user_id"].ToString()) : 1;
            XString mystr = new XString();
            if (ModelState.IsValid)
            {
                mcategory.Slug = mystr.ToAscii(mcategory.Name);
                mcategory.Created_at = DateTime.Now;
                mcategory.Created_by = user_id;
                mcategory.Updated_at = DateTime.Now;
                mcategory.Updated_by = user_id;
                db.Entry(mcategory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(mcategory);
        }

        // GET: Admin/Category/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mcategory mcategory = db.Categories.Find(id);
            if (mcategory == null)
            {
                return HttpNotFound();
            }
            return View(mcategory);
        }

        // POST: Admin/Category/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Mcategory mcategory = db.Categories.Find(id);
            db.Categories.Remove(mcategory);
            db.SaveChanges();
            return RedirectToAction("Trash");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
        //code tu go
        public string ShowStatus(int id)
        {
            string strStatus="";
            Mcategory mcategory = db.Categories.Find(id);
            if(mcategory.Status==1)
            {
                strStatus = "<span class='btn btn-info btn-sm' ><i class='fas fa-toggle-on'></i>TT</span>";
            }
            else
            {
                strStatus = "<span class='btn btn-danger btn-sm' ><i class=' fas fa-toggle-off'></i>TT</span>";
            }
            return strStatus;
        }
        public ActionResult status(int id)
        {
            Mcategory mcategory = db.Categories.Find(id);
            if (mcategory.Status == 1)
            {
                mcategory.Status = 2;
            }
            else
            {
                mcategory.Status = 1;
            }
            db.Entry(mcategory).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Deltrash(int id)
        {
            Mcategory mcategory = db.Categories.Find(id);
            mcategory.Status = 0;
            db.Entry(mcategory).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index","Category");
        }
        public ActionResult Retrash(int id)
        {
            Mcategory mcategory = db.Categories.Find(id);
            mcategory.Status = 2;
            db.Entry(mcategory).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Trash", "Category");
        }
        public ActionResult Trash()
        {
            var list = db.Categories.Where(m => m.Status == 0).ToList();
            return View(list);
        }
       
    }
}
