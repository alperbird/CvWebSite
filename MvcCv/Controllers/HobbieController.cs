using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCv.Models.Entity;
using MvcCv.Repositories;

namespace MvcCv.Controllers
{
    public class HobbieController : Controller
    {
        GenericRepository<tbl_Hobbies> repo = new GenericRepository<tbl_Hobbies>();
        // GET: Hobbie
        [HttpGet]
        public ActionResult Index()
        {
            var hobbies = repo.List();
            return View(hobbies);
        }

        [HttpPost]
        public ActionResult Index(tbl_Hobbies p)
        {
            var hobi = repo.Find(x => x.Id == p.Id); 
            hobi.Description = p.Description;
            hobi.Description2 = p.Description2;
            repo.TUpdate(hobi);
            return RedirectToAction("Index");
        }

    }
}