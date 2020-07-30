using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Bangaubong.Models;
using Bangaubong.Lib;
namespace Bangaubong.Areas.Admin.Controllers
{
    public class AuthController : Controller
    {
        Encryptor encty = new Encryptor();
        BangaubongDBContext db = new BangaubongDBContext();
        // GET: Admin/Auth
        public ActionResult Login(Muser auth)
        {
            ViewBag.Message = "";
            if (ModelState.IsValid)
            {
                auth.Password = encty.MD5Hash(auth.Password); //mã hóa mật khẩu
                if (!db.Users.Where(m => m.UserName == auth.UserName).Count().Equals(0))
                {
                    if (!db.Users.Where(m => m.UserName == auth.UserName && m.Password == auth.Password).Count().Equals(0))
                    {
                        var user_login = db.Users.Where(m => m.UserName == auth.UserName && m.Password == auth.Password).First();
                        Session["user_admin"] = user_login.UserName;
                        Session["user_id"] = user_login.Id;
                        Session["user_fullname"] = user_login.FullName;
                        Session["user_img"] = user_login.Img;
                        Session["user_acess"] = user_login.Access;
                        return RedirectToAction("Index", "Dashboard");

                    }
                    else
                    {
                        ViewBag.Message = "Mật Khẩu không chính Xác";
                    }
                }
                else
                {
                    ViewBag.Message = "Tên tài khoản không tồn tại";
                }
            }
            return View();
        }

        public ActionResult Logout()
        {
            Session["user_admin"] = null;
            return new RedirectResult("~/Admin/Auth/Login");
        }
    }
}
