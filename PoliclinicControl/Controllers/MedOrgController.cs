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
    public class MedOrgController : Controller
    {
        // создаем контекст данных
        MedContext db = new MedContext();

        // GET: MedOrg
        [HttpGet]
        public ActionResult Index()
        {
            IEnumerable<MedOrg> med_orgs = db.MedOrgs;
            ViewBag.med_orgs = med_orgs;

            return View();
        }
        [HttpPost]
        public ActionResult GetAjaxObject(int? id)
        {
            if (id == null)
                return HttpNotFound();

            MedOrg med_org = db.MedOrgs.Find(id);
            if (med_org == null)
                return HttpNotFound();
            var json = new JavaScriptSerializer().Serialize(med_org);

            return Content(json, "application/json");
        }

        [HttpPost]
        public ActionResult Save(MedOrg med_org)
        {
            using (var context = new MedContext())
            {
                context.Entry(med_org).State = med_org.Id == 0 ?
                                           EntityState.Added :
                                           EntityState.Modified;

                context.SaveChanges();
            }

            return RedirectToAction("Index");
        }
    }


}