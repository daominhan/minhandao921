using Bangaubong.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Bangaubong.Controllers
{
    public class TintucController : Controller
    {
        BangaubongDBContext db = new BangaubongDBContext();
        // GET: Tintuc
        public ActionResult Index()
        {
           
            var model = db.Posts.Where(m => m.TopId == "2").ToList();
            return View(model);
       
        }
            
    }
}
