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
    public class AttachControlController : Controller
    {
        // создаем контекст данных
        MedContext db = new MedContext();

        // GET: AttachControl
        public ActionResult Index()
        {

            IEnumerable<MedAttach> MedAttach = db.MedAttachs.Include(p => p.Client).Include(p => p.MedOrgs).Include(p => p.Status);
            ViewBag.MedAttachs = MedAttach;

            return View();
        }
        public ActionResult Apply(int id) {
            MedAttach MedAttach = db.MedAttachs.Find(id);
            MedAttach.DateClosed = DateTime.Now;
            MedAttach.StatusId = 2;
            db.Entry(MedAttach).State = EntityState.Modified;

            Client Client = db.Clients.Find(MedAttach.ClientId);
            Client.IsAttached = true;
            Client.MedOrgId = MedAttach.MedOrgId;
            db.Entry(Client).State = EntityState.Modified;

            db.SaveChanges();

            return RedirectToAction("Index");
        }
        public ActionResult Cancel(int id)
        {
            MedAttach MedAttach = db.MedAttachs.Find(id);
            MedAttach.DateClosed = DateTime.Now;
            MedAttach.StatusId = 3;
            db.Entry(MedAttach).State = EntityState.Modified;
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}