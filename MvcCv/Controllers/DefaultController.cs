using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCv.Models.Entity;

namespace MvcCv.Controllers
{
    [AllowAnonymous]
    public class DefaultController : Controller
    {
        // GET: Default
        UdemyCvEntities db = new UdemyCvEntities();
        public ActionResult Index()
        {
            var degerler = db.tbl_About.ToList();
            return View(degerler);
        }

        public PartialViewResult SocialMedia()
        {
            var sm = db.tbl_SocialMedia.Where(x => x.Status == true).ToList();
            return PartialView(sm);
        }

        public PartialViewResult Experience()
        {
            var experiences = db.tbl_Experiences.ToList();
            return PartialView(experiences);
        }
        public PartialViewResult Education()
        {
            var educations = db.tbl_Education.ToList();
            return PartialView(educations);
        }
        public PartialViewResult Skill()
        {
            var skills = db.tbl_Skills.ToList();
            return PartialView(skills);
        }
        public PartialViewResult Hobby()
        {
            var hobbies = db.tbl_Hobbies.ToList();
            return PartialView(hobbies);
        }
        public PartialViewResult Certificate()
        {
            var certificates = db.tbl_Certificate.ToList();
            return PartialView(certificates);
        }
        [HttpGet]
        public PartialViewResult Contact() //Bizim gördüğümüz kısım
        { 
            return PartialView();
        }
        [HttpPost]
        public PartialViewResult Contact(tbl_Contact c) //Arka planda çalışacak olan kısım
        {
            c.Date = DateTime.Parse(DateTime.Now.ToShortDateString());
            db.tbl_Contact.Add(c);
            db.SaveChanges();
            return PartialView();
        }

    }
}