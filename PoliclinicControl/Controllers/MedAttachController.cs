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

            IEnumerable<MedAttach> MedAttachs = db.MedAttachs.Include(p => p.Team);
            ViewBag.MedAttachs = MedAttachs;

            return View();
        }
    }
}