using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Bangaubong.Areas.Admin.Controllers
{
    public class DashboardController : Controller
    {
        // GET: Admin/Dashboard
        public ActionResult Index()
        {
            if (Session["user_admin"] == null)
            {
                return RedirectToAction("Login", "Auth");
            }
            return View();
        }
    }
}