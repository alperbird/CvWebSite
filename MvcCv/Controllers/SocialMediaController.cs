using MvcCv.Models.Entity;
using MvcCv.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCv.Controllers
{
    public class SocialMediaController : Controller
    {
        // GET: SocialMedia
        GenericRepository<tbl_SocialMedia> repo = new GenericRepository<tbl_SocialMedia>();
        public ActionResult Index()
        {
            var sm = repo.List();
            return View(sm);
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(tbl_SocialMedia s)
        {
            repo.TAdd(s);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Update(int id)
        {
            var calc = repo.Find(x => x.Id == id);
            return View(calc);
        }

        [HttpPost]
        public ActionResult Update(tbl_SocialMedia p)
        {
            var calc = repo.Find(x => x.Id == p.Id);
            calc.Name = p.Name;
            calc.Link = p.Link;
            calc.Status = true;
            repo.TUpdate(calc);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var sm = repo.Find(x => x.Id == id);
            sm.Status = false;
            repo.TUpdate(sm);
            return RedirectToAction("Index");
        }
    }
}