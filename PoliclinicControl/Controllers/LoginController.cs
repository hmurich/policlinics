using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.Mvc;
using PoliclinicControl.Models;
using System.Data.Entity;

namespace PoliclinicControl.Controllers
{
    public class LoginController : Controller
    {
        MedContext db = new MedContext();

        // GET: Login
        public ActionResult Index()
        {
            
            return View();
        }

        public string CheckLogin()
        {
            string result = "Вы не авторизованы";
            if (User.Identity.IsAuthenticated)
            {
                result = "Ваш логин: " + User.Identity.Name;
            }
            return result;
        }

        [HttpPost]
        public ActionResult Login()
        {
            string login = Request["Name"];
            string password = Request["Password"];
            db.Users.Add(new User { Login = login, Password = password });
            db.SaveChanges();

            User user = db.Users.Where(u => u.Login == login && u.Password == password).FirstOrDefault();

            user = db.Users.FirstOrDefault(u => u.Login == login);
            if (user != null)
            {
                FormsAuthentication.SetAuthCookie(login, true);
                return RedirectToAction("Index", "Home");
            }

            return RedirectToAction("Index");
        }

        public ActionResult Logoff()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Login");
        }
    }
}