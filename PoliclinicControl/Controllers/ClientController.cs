using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PoliclinicControl.Models;
using System.Data.Entity;
using System.Web.Script.Serialization;

namespace PoliclinicControl.Controllers
{
    [Authorize]
    public class ClientController : Controller
    {
        // создаем контекст данных
        MedContext db = new MedContext();

        // GET: Clients
        [HttpGet]
        public ActionResult Index()
        {
            IEnumerable<Client> clients = db.Clients;
            ViewBag.clients = clients;

            return View();
        }
        [HttpPost]
        public ActionResult GetAjaxObject(int? id)
        {
            if (id == null)
                return HttpNotFound();

            Client client = db.Clients.Find(id);
            if (client == null)
                return HttpNotFound();
            var json = new JavaScriptSerializer().Serialize(client);

            return Content(json, "application/json");
        }

        [HttpPost]
        public ActionResult Save(Client client)
        {
            using (var context = new MedContext())
            {
                context.Entry(client).State = client.Id == 0 ?
                                           EntityState.Added :
                                           EntityState.Modified;

                context.SaveChanges();
            }

            return RedirectToAction("Index");
        }
    }
}