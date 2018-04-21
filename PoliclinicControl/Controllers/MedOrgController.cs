using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PoliclinicControl.Models;
using System.Data.Entity;

namespace PoliclinicControl.Controllers
{
    public class MedOrgController : Controller
    {
        // создаем контекст данных
        MedContext db = new MedContext();

        // GET: MedOrg
        public ActionResult Index()
        {
            IEnumerable<MedOrg> med_orgs = db.MedOrgs;
            ViewBag.med_orgs = med_orgs;

            return View();
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
                return HttpNotFound();

            MedOrg med_org = db.MedOrgs.Find(id);
            if (med_org == null)
                return HttpNotFound();

            return View(med_org);
        }
        [HttpPost]
        public ActionResult Edit(MedOrg med_org)
        {
            db.Entry(med_org).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }


}