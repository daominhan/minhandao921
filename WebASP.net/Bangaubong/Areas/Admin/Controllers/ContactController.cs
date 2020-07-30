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
    public class ContactController : Controller
    {
        private BangaubongDBContext db = new BangaubongDBContext();

        // GET: Admin/Contact
        public ActionResult Index()
        {
             var list = db.Contact.Where(m => m.Status != 0).ToList();
            return View(list);
        }

        // GET: Admin/Contact/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mcontact mcontact = db.Contact.Find(id);
            if (mcontact == null)
            {
                return HttpNotFound();
            }
            return View(mcontact);
        }

        // GET: Admin/Contact/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Contact/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FullName,Email,Phone,Title,Detail,Created_at,Updated_at,Updated_by,Status")] Mcontact mcontact)
        {
            if (ModelState.IsValid)
            {
                db.Contact.Add(mcontact);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(mcontact);
        }

        // GET: Admin/Contact/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mcontact mcontact = db.Contact.Find(id);
            if (mcontact == null)
            {
                return HttpNotFound();
            }
            return View(mcontact);
        }

        // POST: Admin/Contact/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FullName,Email,Phone,Title,Detail,Created_at,Updated_at,Updated_by,Status")] Mcontact mcontact)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mcontact).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(mcontact);
        }

        // GET: Admin/Contact/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mcontact mcontact = db.Contact.Find(id);
            if (mcontact == null)
            {
                return HttpNotFound();
            }
            return View(mcontact);
        }

        // POST: Admin/Contact/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Mcontact mcontact = db.Contact.Find(id);
            db.Contact.Remove(mcontact);
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
        public string ShowStatus(int id)
        {
            string strStatus = "";
            Mcontact mcontact = db.Contact.Find(id);
            if (mcontact.Status == 1)
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
            Mcontact mcontact = db.Contact.Find(id);
            if (mcontact.Status == 1)
            {
                mcontact.Status = 2;
            }
            else
            {
                mcontact.Status = 1;
            }
            db.Entry(mcontact).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        //code tu go
        public ActionResult Deltrash(int id)
        {
            Mcontact mcontact = db.Contact.Find(id);
            mcontact.Status = 0;
            db.Entry(mcontact).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index", "Contact");
        }
        public ActionResult Retrash(int id)
        {
            Mcontact mcontact = db.Contact.Find(id);
            mcontact.Status = 2;
            db.Entry(mcontact).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Trash", "Contact");
        }
        public ActionResult Trash()
        {
            var list = db.Contact.Where(m => m.Status == 0).ToList();
            return View(list);
        }
    }
}
