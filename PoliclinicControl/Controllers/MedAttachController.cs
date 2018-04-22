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
    public class MedAttachController : Controller
    {
        // создаем контекст данных
        MedContext db = new MedContext();

        // GET: MedAttach
        public ActionResult Index()
        {
            Dictionary<int, string> StatusAr = new Dictionary<int, string>();

            StatusAr[1] = "Создан/В обработке";
            StatusAr[2] = "Одобрен.Прикреплен";
            StatusAr[3] = "Отказан.Не прикреплен";
            ViewBag.StatusAr = StatusAr;

            SelectList MedOrgs = new SelectList(db.MedOrgs, "Id", "Name", null);
            ViewBag.MedOrgs = MedOrgs;


            IEnumerable<Client> Clients = db.Clients.Include(p => p.MedOrgs);
            ViewBag.Clients = Clients;

            return View();
        }

        [HttpPost]
        public ActionResult GetAjaxClients()
        {
            String find = Request["find"];
            System.Data.SqlClient.SqlParameter param = new System.Data.SqlClient.SqlParameter("@name", "%"+ find + "%");
            var Clients = db.Database.SqlQuery<Client>("SELECT * FROM Clients WHERE FName LIKE @name OR LName LIKE @name OR PName LIKE @name OR Iin LIKE @name", param);

            var json = new JavaScriptSerializer().Serialize(Clients);

            return Content(json, "application/json");
        }

        [HttpPost]
        public ActionResult Save(MedAttach med_attach)
        {
            int ClientId = Int32.Parse(Request["Client"]);
            med_attach.ClientId = ClientId;
            int MedOrgs = Int32.Parse(Request["MedOrgs"]);
            med_attach.MedOrgId = MedOrgs;

            med_attach.StatusId = 1;
            med_attach.DateCreated = DateTime.Now;
            db.Entry(med_attach).State = EntityState.Added;
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}