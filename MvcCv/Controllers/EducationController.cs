using MvcCv.Models.Entity;
using MvcCv.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCv.Controllers
{
    public class EducationController : Controller
    {
        // GET: Education
        GenericRepository<tbl_Education> repo = new GenericRepository<tbl_Education>();


        public ActionResult Index()
        {
            var education = repo.List();
            return View(education);
        }

        [HttpGet]
        public ActionResult AddEducation()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddEducation(tbl_Education p)
        {
            if(!ModelState.IsValid)
            {
                return View("AddEducation");
            }
            repo.TAdd(p);
            return RedirectToAction("Index");
        }
        public ActionResult DeleteEducation(int id)
        {
            tbl_Education t = repo.Find(x => x.Id == id);
            repo.TDelete(t);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult GetEducation(int id)
        {
            tbl_Education t = repo.Find(x => x.Id == id);
            return View(t);
        }
        [HttpPost]
        public ActionResult GetEducation(tbl_Education p)
        {
            if (!ModelState.IsValid)
            {
                return View("GetEducation");
            }
            tbl_Education t = repo.Find(x => x.Id == p.Id);
            p.Title = t.Title;
            p.Subtitle = t.Subtitle;
            p.Subtitle2 = t.Subtitle2;
            p.Gno = t.Gno;
            p.Date = t.Date;
            repo.TUpdate(t);
            return RedirectToAction("Index");
        }
    }
}