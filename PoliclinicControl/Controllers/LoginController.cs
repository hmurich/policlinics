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

            User user = db.Users.Where(u => u.Login == login && u.Password == password).FirstOrDefault();
            if (user != null)
            {
                FormsAuthentication.SetAuthCookie(login, true);
                Session["IsAdmin"] = user.IsAdmin;
                Session["IsAttach"] = user.IsAttach;
                Session["IsControl"] = user.IsControl;
                Session["IsReport"] = user.IsReport;

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