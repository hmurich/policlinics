using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PoliclinicControl.Models;
using System.Data.Entity;

namespace PoliclinicControl.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        // создаем контекст данных
        MedContext db = new MedContext();

        public ActionResult Index()
        {
            IEnumerable<Client> Clients = db.Clients.Where(x => x.IsAttached == true).Include(p => p.MedOrgs);
            ViewBag.Clients = Clients;

            return View();
        }
    }
}