using MvcCv.Models.Entity;
using MvcCv.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCv.Controllers
{
    public class ExperienceController : Controller
    {
        // GET: Experience
        GenericRepository<tbl_Experiences> repo = new GenericRepository<tbl_Experiences>();

        
        public ActionResult Index()
        {
            var values = repo.List();
            return View(values);
        }

        [HttpGet]
        public ActionResult AddExperience()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddExperience(tbl_Experiences p) //ekleme işlemini yaptıktan sonra beni Index sayfasına yönlendir.
        {
            repo.TAdd(p);
            return RedirectToAction("Index");
        }
        public ActionResult DeleteExperience(int id)
        {
            tbl_Experiences t = repo.Find(x => x.Id == id);
            repo.TDelete(t);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult GetExperience(int id)
        {
            tbl_Experiences t = repo.Find(x => x.Id == id);
            return View(t);
        }

        [HttpPost]
        public ActionResult GetExperience(tbl_Experiences p)
        {
            tbl_Experiences t = repo.Find(x => x.Id == p.Id);
            // parametreden gelen değeri tablomuzdaki değerle güncelliyoruz.
            t.Title = p.Title;
            t.Subtitle = p.Subtitle;
            t.Date = p.Date;
            t.Description = p.Description;
            repo.TUpdate(t);
            return RedirectToAction("Index");
        }
    }
}