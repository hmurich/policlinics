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
    public class UserController : Controller
    {
        // создаем контекст данных
        MedContext db = new MedContext();

        // GET: MedOrg
        [HttpGet]
        public ActionResult Index()
        {
            IEnumerable<User> users = db.Users;
            ViewBag.users = users;

            return View();
        }
        [HttpPost]
        public ActionResult GetAjaxObject(int? id)
        {
            if (id == null)
                return HttpNotFound();

            User user = db.Users.Find(id);
            if (user == null)
                return HttpNotFound();
            var json = new JavaScriptSerializer().Serialize(user);

            return Content(json, "application/json");
        }

        [HttpPost]
        public ActionResult Save(User user)
        {
            using (var context = new MedContext())
            {
                context.Entry(user).State = user.Id == 0 ?
                                           EntityState.Added :
                                           EntityState.Modified;

                context.SaveChanges();
            }

            return RedirectToAction("Index");
        }
    }


}