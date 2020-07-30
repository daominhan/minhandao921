using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bangaubong.Models;

namespace Bangaubong.Controllers
{
    public class GioithieuController : Controller
    {
        BangaubongDBContext db = new BangaubongDBContext();
        // GET: Gioithieu
        public ActionResult Index()
        {
            return View();
        }

    }
}