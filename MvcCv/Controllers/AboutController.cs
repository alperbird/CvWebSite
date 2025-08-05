using Microsoft.SqlServer.Server;
using MvcCv.Models.Entity;
using MvcCv.Repositories;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCv.Controllers
{
    public class AboutController : Controller
    {
        // GET: About
        UdemyCvEntities db = new UdemyCvEntities();
        GenericRepository<tbl_About> repo = new GenericRepository<tbl_About>();

        [HttpGet]
        public ActionResult Index()
        {
            var about = repo.List();
            return View(about);
        }

        [HttpPost]
        public ActionResult Index(tbl_About p)
        {
            if (Request.Files.Count > 0)
            {
                string fileName =  Path.GetFileName(Request.Files[0].FileName);
                string extent = Path.GetExtension(Request.Files[0].FileName);
                string path = "~/Image/" + fileName + extent;
                Request.Files[0].SaveAs(Server.MapPath(path));
                p.Image = "/Image/" + fileName + extent; 

            }

            var about = repo.Find(x => x.Id == 1); //buradaki id null geliyor bilere 1 yaptım sonra bakacağım...
            about.Name = p.Name;
            about.Surname = p.Surname;
            about.Address = p.Address;
            about.Phone = p.Phone;
            about.Mail = p.Mail;
            about.Image = p.Image;
            about.About = p.About;
            repo.TUpdate(about);
            return RedirectToAction("Index");
        }
    }
}