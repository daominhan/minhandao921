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
    public class UsersController : Controller
    {
        private BangaubongDBContext db = new BangaubongDBContext();

        // GET: Admin/Users
        public ActionResult Index()
        {
            var list = db.Users.Where(m => m.Status != 0).ToList();
            return View(list);
        }

        // GET: Admin/Users/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Muser muser = db.Users.Find(id);
            if (muser == null)
            {
                return HttpNotFound();
            }
            return View(muser);
        }

        // GET: Admin/Users/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Users/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Muser muser)
        {
            int user_id = (!Session["user_id"].Equals("")) ? Convert.ToInt32(Session["user_id"].ToString()) : 1;
            if (ModelState.IsValid)
            {
                muser.Created_at = DateTime.Now;
                muser.Created_by = user_id;
                muser.Updated_at = DateTime.Now;
                muser.Updated_by = user_id;
                db.Users.Add(muser);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(muser);
        }

        // GET: Admin/Users/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Muser muser = db.Users.Find(id);
            if (muser == null)
            {
                return HttpNotFound();
            }
            return View(muser);
        }

        // POST: Admin/Users/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Muser muser)
        {
            int user_id = (!Session["user_id"].Equals("")) ? Convert.ToInt32(Session["user_id"].ToString()) : 1;
            if (ModelState.IsValid)
            {
                muser.Created_at = DateTime.Now;
                muser.Created_by = user_id;
                muser.Updated_at = DateTime.Now;
                muser.Updated_by = user_id;
                db.Entry(muser).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(muser);
        }

        // GET: Admin/Users/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Muser muser = db.Users.Find(id);
            if (muser == null)
            {
                return HttpNotFound();
            }
            return View(muser);
        }

        // POST: Admin/Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Muser muser = db.Users.Find(id);
            db.Users.Remove(muser);
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
       
         public string ShowGender(int id)
        {
            string strGender = "";
            Muser muser = db.Users.Find(id);
            if (muser.Gender == 1)
            {
                strGender = "Nam";
            }
            else
            {
                strGender = "Nữ";
            }
            return strGender;
        }
        public string ShowStatus(int id)
        {
            string strStatus = "";
            Muser muser = db.Users.Find(id);
            if (muser.Status == 1)
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
            Muser muser = db.Users.Find(id);
            if (muser.Status == 1)
            {
                muser.Status = 2;
            }
            else
            {
                muser.Status = 1;
            }
            db.Entry(muser).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Deltrash(int id)
        {
            Muser muser = db.Users.Find(id);
            muser.Status = 0;
            db.Entry(muser).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index", "Users");
        }
        public ActionResult Retrash(int id)
        {
            Muser muser = db.Users.Find(id);
            muser.Status = 2;
            db.Entry(muser).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Trash", "Users");
        }
        public ActionResult Trash()
        {
            var list = db.Users.Where(m => m.Status == 0).ToList();
            return View(list);
        }
    }
}
