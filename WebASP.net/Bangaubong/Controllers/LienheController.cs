using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bangaubong.Models;

namespace Bangaubong.Controllers
{
    public class LienheController : Controller
    {
        BangaubongDBContext db = new BangaubongDBContext();
        // GET: Lienhe
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public RedirectResult Savecontact()
        {
            string fullname = Request.Form["FullName"];
            string email = Request.Form["Email"];
            string phone = Request.Form["Phone"];
            string title = Request.Form["Title"];
            string detail = Request.Form["Detail"];
            Mcontact contact = new Mcontact();
            contact.FullName = fullname;
            contact.Email = email;
            contact.Phone = phone;
            contact.Title = title;
            contact.Detail = detail;
            contact.Created_at = DateTime.Now;
            contact.Updated_at = DateTime.Now;
            contact.Updated_by = 1;
            contact.Status = 1;
            db.Contact.Add(contact);
            db.SaveChanges();
            return Redirect("~/lien-he");
        }
    }
}