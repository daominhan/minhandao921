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
    public class ProductController : Controller
    {
        private BangaubongDBContext db = new BangaubongDBContext();

        // GET: Admin/Product
        public ActionResult Index()
        {
            var list = db.Products.Where(m => m.Status != 0).ToList();
            return View(list);
        }


        // GET: Admin/Product/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mproduct mproduct = db.Products.Find(id);
            if (mproduct == null)
            {
                return HttpNotFound();
            }
            return View(mproduct);
        }

        // GET: Admin/Product/Create
        public ActionResult Create()
        {
            var Listcat = db.Categories.Where(m => m.Status == 1).ToList();
            ViewBag.listCatId = new SelectList(Listcat, "Id", "Name");
            return View();
        }

        // POST: Admin/Product/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(FormCollection collection, Mproduct mproduct)
        {

            int user_id = (!Session["user_id"].Equals("")) ? Convert.ToInt32(Session["user_id"].ToString()) : 1;
            XString mystr = new XString();
            if (ModelState.IsValid)
            {
                mproduct.CatId = Convert.ToInt32(collection["Listcat"]);
                string strslug = mystr.ToAscii(mproduct.Name);
                mproduct.Slug = strslug;
                mproduct.Created_at = DateTime.Now;
                mproduct.Created_by = user_id;
                mproduct.Updated_at = DateTime.Now;
                mproduct.Updated_by = user_id;

                //upload file
                var file = Request.Files["fileimg"];
                if (file != null && file.ContentLength > 0)
                {
                    //string phammorong = file.FileName.Substring(file.FileName.LastIndexOf("."));
                    mproduct.Img = file.FileName.ToString();
                    string path = Server.MapPath("~/images/product/") + file.FileName.ToString();
                    file.SaveAs(path);
                    //lưu
                    db.Products.Add(mproduct);
                    db.SaveChanges();
                }

                return RedirectToAction("Index");
            }

            var list = db.Categories.Where(m => m.Status != 0).ToList();
            ViewBag.Listcat = new SelectList(list, "id", "Name");
            return View(mproduct);

        }

        // GET: Admin/Product/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mproduct mproduct = db.Products.Find(id);
            var Listcat = db.Categories.Where(m => m.Status == 1).ToList();
            //.OrderByDescending(m => m.Created_at)
            ViewBag.listCatId = new SelectList(Listcat, "Id", "Name");
            if (mproduct == null)
            {
                return HttpNotFound();
            }
            return View(mproduct);
        }

        // POST: Admin/Product/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(FormCollection collection, Mproduct mproduct)
        {
            int user_id = (!Session["user_id"].Equals("")) ? Convert.ToInt32(Session["user_id"].ToString()) : 1;
            XString mystr = new XString();
            if (ModelState.IsValid)
            {
                mproduct.CatId = Convert.ToInt32(collection["Listcat"]);
                string strslug = mystr.ToAscii(mproduct.Name);
                mproduct.Slug = strslug;
                mproduct.Created_at = DateTime.Now;
                mproduct.Created_by = user_id;
                mproduct.Updated_at = DateTime.Now;
                mproduct.Updated_by = user_id;
                db.Entry(mproduct).State = EntityState.Modified;



                //upload file
                var file = Request.Files["fileimg"];
                if (file != null && file.ContentLength > 0)
                {
                    //string phammorong = file.FileName.Substring(file.FileName.LastIndexOf("."));
                    mproduct.Img = file.FileName.ToString();
                    string path = Server.MapPath("~/images/product/") + file.FileName.ToString();
                    file.SaveAs(path);
                    //lưu

                    db.SaveChanges();
                }

                return RedirectToAction("Index");
            }

            var list = db.Categories.Where(m => m.Status != 0).ToList();
            ViewBag.Listcat = new SelectList(list, "id", "Name");
            return View(mproduct);
        }

        // GET: Admin/Product/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mproduct mproduct = db.Products.Find(id);
            if (mproduct == null)
            {
                return HttpNotFound();
            }
            return View(mproduct);
        }

        // POST: Admin/Product/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Mproduct mproduct = db.Products.Find(id);
            db.Products.Remove(mproduct);
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
            Mproduct mproduct = db.Products.Find(id);
            if (mproduct.Status == 1)
            {
                strStatus = "<span class ='btn btn-info btn-sm'><i class='fas fa-toggle-on'></i></span>";
            }
            else
            {
                strStatus = "<span class ='btn btn-danger btn-sm'><i class='fas fa-toggle-off'></i></span>";
            }
            return strStatus;
        }
        public ActionResult status(int id)
        {
            Mproduct mproduct = db.Products.Find(id);
            if (mproduct.Status == 1)
            {
                mproduct.Status = 0;
            }
            else
            {
                mproduct.Status = 1;
            }
            db.Entry(mproduct).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Deltrash(int id)
        {
            Mproduct mproduct = db.Products.Find(id);
            mproduct.Status = 0;
            db.Entry(mproduct).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index", "Product");
        }
        public ActionResult Retrash(int id)
        {
            Mproduct mproduct = db.Products.Find(id);
            mproduct.Status = 2;
            db.Entry(mproduct).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Trash", "Product");
        }


        public string NameCategory(int? catid)
        {
            var item = db.Categories.Where(m => m.Id == catid).Select(m => m.Name).First();
            if (item != null)
            {
                return item;
            }
            return "uncategory";

        }
        public ActionResult Trash()
        {
            var list = db.Products.Where(m => m.Status == 0).ToList();
            return View(list);
        }

    }
}