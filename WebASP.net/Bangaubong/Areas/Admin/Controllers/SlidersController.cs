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
    public class SlidersController : Controller
    {
        private BangaubongDBContext db = new BangaubongDBContext();

        // GET: Admin/Sliders
        public ActionResult Index()
        {
            var list = db.Sliders.Where(m => m.Status != 0).ToList();
            return View(list);
        }

        // GET: Admin/Sliders/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mslider mslider = db.Sliders.Find(id);
            if (mslider == null)
            {
                return HttpNotFound();
            }
            return View(mslider);
        }

        // GET: Admin/Sliders/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Sliders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create( Mslider mslider)
        {
            int user_id = (!Session["user_id"].Equals("")) ? Convert.ToInt32(Session["user_id"].ToString()) : 1;
            XString mystr = new XString();
            if (ModelState.IsValid)
            {
               
                mslider.Link = mystr.ToAscii(mslider.Name);
                mslider.Created_at = DateTime.Now;
                mslider.Created_by = user_id;
                mslider.Updated_at = DateTime.Now;
                mslider.Updated_by = user_id;
                db.Sliders.Add(mslider);
                db.SaveChanges();
                return RedirectToAction("Index");
            }


            return View(mslider);
        }

        // GET: Admin/Sliders/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mslider mslider = db.Sliders.Find(id);
            if (mslider == null)
            {
                return HttpNotFound();
            }
            return View(mslider);
        }

        // POST: Admin/Sliders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Link,Position,Img,Orders,Created_at,Created_by,Updated_at,Updated_by,Status")] Mslider mslider)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mslider).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(mslider);
        }

        // GET: Admin/Sliders/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mslider mslider = db.Sliders.Find(id);
            if (mslider == null)
            {
                return HttpNotFound();
            }
            return View(mslider);
        }

        // POST: Admin/Sliders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Mslider mslider = db.Sliders.Find(id);
            db.Sliders.Remove(mslider);
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
            Mslider mslider = db.Sliders.Find(id);
            if (mslider.Status == 1)
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
            Mslider mslider = db.Sliders.Find(id);
            if (mslider.Status == 1)
            {
                mslider.Status = 2;
            }
            else
            {
                mslider.Status = 1;
            }
            db.Entry(mslider).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        //code tu go
        public ActionResult Deltrash(int id)
        {
            Mslider mslider = db.Sliders.Find(id);
            mslider.Status = 0;
            db.Entry(mslider).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index", "Sliders");
        }
        public ActionResult Retrash(int id)
        {
            Mslider mslider = db.Sliders.Find(id);
            mslider.Status = 2;
            db.Entry(mslider).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Trash", "Sliders");
        }
        public ActionResult Trash()
        {
            var list = db.Sliders.Where(m => m.Status == 0).ToList();
            return View(list);
        }

    }
}
