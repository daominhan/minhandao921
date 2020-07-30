using Bangaubong.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Bangaubong.Controllers
{
    public class TrangchuController : Controller
    {
        BangaubongDBContext db = new BangaubongDBContext();
        // GET: Trangchu
        public ActionResult Index()
        {
            var listcat = db.Categories.Where(m => m.Status == 1 && m.ParentId == 0).ToList();
            return View(listcat);
        }
        public ActionResult HomeProduct(int catid)
        {
            List<int> catlist = db.Categories.Where(m => m.ParentId == catid).Select(m => m.Id).ToList();
            catlist.Add(catid);
            var listproduct = db.Products.Where(m => m.Status == 1 && catlist.Contains(m.CatId)).Take(4).ToList();
            return View("_HomeProduct", listproduct);
        }
        public ActionResult ProductDetail(string slug, int slugcat)
        {
            var rowcat = db.Categories.Where(m => m.Id == slugcat).First();
            var model = db.Products.Where(m => m.Status == 1 && m.Slug == slug).First();
            return View(model);
        }
    }
}