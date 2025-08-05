using MvcCv.Models.Entity;
using MvcCv.Repositories;
using System.Web.Mvc;

namespace MvcCv.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact

        GenericRepository<tbl_Contact> repo = new GenericRepository<tbl_Contact>();
        public ActionResult Index()
        {
            var contacts = repo.List();
            return View(contacts);
        }
    }
}