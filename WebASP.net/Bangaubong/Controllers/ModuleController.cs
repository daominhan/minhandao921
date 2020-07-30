using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bangaubong.Models;


namespace Bangaubong.Controllers
{
    public class ModuleController : Controller
    {
        BangaubongDBContext db = new BangaubongDBContext();
        // GET: Module
        public ActionResult MainMenu()
        {
            var model = db.Menus.Where(m => m.Status == 1).OrderBy(m => m.Orders);
            return View("_MainMenu", model.ToList());
        }
        public ActionResult SlideShow()
        {
            var list = db.Sliders.Where(x => x.Status == 1 && x.Position == "slideshow").OrderBy(m => m.Orders).ToList();
            return View("_Slider", list);
        }

        public ActionResult Listcategory()
        {
            var list = db.Categories.Where(x => x.Status == 1 && x.ParentId == 0).OrderBy(m => m.Orders).ToList();
            return View("_Listcategory", list);
        }
        public ActionResult ChildListcategory(int id)
        {
            int dem = db.Categories.Where(m => m.ParentId == id && m.Status == 1).Count();
            if (dem != 0)
            {
                var list = db.Categories.Where(x => x.Status == 1 && x.ParentId == id).OrderBy(m => m.Orders).ToList();
                return View("_ChildListcategory", list);
            }
            return null;
        }
    }
}