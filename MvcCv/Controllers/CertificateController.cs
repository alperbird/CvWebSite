using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCv.Models.Entity;
using MvcCv.Repositories;

namespace MvcCv.Controllers
{
    public class CertificateController : Controller
    {
        // GET: Certificate
        GenericRepository<tbl_Certificate> repo = new GenericRepository<tbl_Certificate>();
        public ActionResult Index()
        {
            var certificates = repo.List();
            return View(certificates);
        }

        [HttpGet]
        public ActionResult GetCertificates(int id)
        {
            var certificate = repo.Find(x => x.Id == id);
            ViewBag.id = id;
            return View(certificate);
        }

        [HttpPost]
        public ActionResult GetCertificates(tbl_Certificate t) //ekstra güncelliyor falan
        {
            var certificate = repo.Find(x => x.Id == t.Id);
            certificate.Description = t.Description;
            certificate.Date = t.Date;
            repo.TUpdate(certificate);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult AddCertificate()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddCertificate(tbl_Certificate t)
        {
            repo.TAdd(t);
            return RedirectToAction("Index");
        }

        public ActionResult DeleteCertificate(int id)
        {
            var t = repo.Find(x => x.Id == id);
            repo.TDelete(t);
            return RedirectToAction("Index");
        }
    }
}