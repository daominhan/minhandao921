using Bangaubong.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;

namespace Bangaubong.Controllers
{
    public class SanphamController : Controller
    {
        BangaubongDBContext db = new BangaubongDBContext();
        // GET: Sanpham
        public ActionResult Index( int ? page)
        {
            int pageSize = 16;
            int pageIndex = page.HasValue ? Convert.ToInt32(page) : 1;
            var list = db.Products.Where(m => m.Status == 1)
                .OrderByDescending(m => m.Created_at)
                .ToPagedList(pageIndex, pageSize);
            return View(list);
        }
        public ActionResult Category(string slugcat, int? page)
        {
            var rowcat = db.Categories.Where(m => m.Slug == slugcat).First();
            int catid = rowcat.Id;
            ViewBag.title = rowcat.Name;
            List<int> listcatid = db.Categories.Where(m => m.Status == 1 && m.ParentId == catid).Select(m => m.Id).ToList();
            listcatid.Add(catid);
            ViewBag.Slug = catid.ToString();
            int pageSize = 8;
            int pageIndex = page.HasValue ? Convert.ToInt32(page) : 1;
            var list = db.Products.Where(m => m.Status == 1 && listcatid.Contains(m.CatId)).OrderByDescending(m => m.Created_at).ToPagedList(pageIndex, pageSize);
            return View(list);
        }
        public ActionResult ProductDetail(string slug, int slugcat)
        {
            var rowcat = db.Categories.Where(m => m.Id == slugcat).First();
            var model = db.Products.Where(m => m.Status == 1 && m.Slug == slug).First();
            return View(model);
        }
    }
}