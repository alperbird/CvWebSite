using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCv.Models.Entity;
using MvcCv.Repositories;

namespace MvcCv.Controllers
{
    public class SkillController : Controller
    {
        // GET: Skill
        GenericRepository<tbl_Skills> repository = new GenericRepository<tbl_Skills>();
        public ActionResult Index()
        {
            var skills = repository.List();
            return View(skills);
        }
        [HttpGet]
        public ActionResult AddSkill()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddSkill(tbl_Skills p)
        {
            repository.TAdd(p);
            return RedirectToAction("Index");
        }
        public ActionResult DeleteSkill(int id)
        {
            tbl_Skills t = repository.Find(x => x.Id == id);
            repository.TDelete(t);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult GetSkill(int id)
        {
            tbl_Skills t = repository.Find(x => x.Id == id);
            return View(t);
        }
        [HttpPost]
        public ActionResult GetSkill(tbl_Skills p)
        {
            tbl_Skills t = repository.Find(x => x.Id == p.Id);
            t.Skill = p.Skill;
            t.Percent = p.Percent;
            repository.TUpdate(t);
            return RedirectToAction("Index");
        }

    }
}