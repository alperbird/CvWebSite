using MvcCv.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.Mvc;
using System.Web.Security;

namespace MvcCv.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        // GET: Login
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(tbl_Admin p)
        {
            UdemyCvEntities db = new UdemyCvEntities();

            var info = db.tbl_Admin.FirstOrDefault(x => x.Username == p.Username && x.Password == p.Password);

            if (info != null)
            {
                FormsAuthentication.SetAuthCookie(info.Username, false);
                Session["Username"] = info.Username.ToString();
                return RedirectToAction("Index", "Experience");
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon(); // TERK ET DEMEK
            return RedirectToAction("Index", "Login");
        }
    }
}