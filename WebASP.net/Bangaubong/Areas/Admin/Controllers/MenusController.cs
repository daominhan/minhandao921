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
    public class MenusController : Controller
    {
        private BangaubongDBContext db = new BangaubongDBContext();

        // GET: Admin/Menus
        public ActionResult Index()
        {
            var list = db.Menus.Where(m => m.Status != 0).ToList();
            return View(list);
        }

        // GET: Admin/Menus/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mmenu mmenu = db.Menus.Find(id);
            if (mmenu == null)
            {
                return HttpNotFound();
            }
            return View(mmenu);
        }

        // GET: Admin/Menus/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Menus/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Link,Types,TableId,ParentId,Orders,Created_at,Created_by,Updated_at,Updated_by,Status")] Mmenu mmenu)
        {
            if (ModelState.IsValid)
            {
                db.Menus.Add(mmenu);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(mmenu);
        }

        // GET: Admin/Menus/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mmenu mmenu = db.Menus.Find(id);
            if (mmenu == null)
            {
                return HttpNotFound();
            }
            return View(mmenu);
        }

        // POST: Admin/Menus/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Mmenu mmenu)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mmenu).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(mmenu);
        }

        // GET: Admin/Menus/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mmenu mmenu = db.Menus.Find(id);
            if (mmenu == null)
            {
                return HttpNotFound();
            }
            return View(mmenu);
        }

        // POST: Admin/Menus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Mmenu mmenu = db.Menus.Find(id);
            db.Menus.Remove(mmenu);
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
            string strStatus = "";
            Mmenu mmenu = db.Menus.Find(id);
            if (mmenu.Status == 1)
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
            Mmenu mmenu = db.Menus.Find(id);
            if (mmenu.Status == 1)
            {
                mmenu.Status = 2;
            }
            else
            {
                mmenu.Status = 1;
            }
            db.Entry(mmenu).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Deltrash(int id)
        {
            Mmenu mmenu = db.Menus.Find(id);
            mmenu.Status = 0;
            db.Entry(mmenu).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index", "menus");
        }
        public ActionResult Retrash(int id)
        {
            Mmenu mmenu = db.Menus.Find(id);
            mmenu.Status = 2;
            db.Entry(mmenu).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Trash", "menus");
        }
        public ActionResult Trash()
        {
            var list = db.Menus.Where(m => m.Status == 0).ToList();
            return View(list);
        }
    }
}
