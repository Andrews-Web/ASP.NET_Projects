using PaperManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Data.SqlClient;

namespace PaperManagementSystem.Controllers
{
    public class LoginController : Controller
    {
        AdminEntities entity = new AdminEntities();
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(LoginViewModel credentials)
        {
            bool userExist = entity.Admins.Any(x => x.Name == credentials.Name && x.Password == credentials.Password);
            Admin u = entity.Admins.FirstOrDefault(x => x.Name == credentials.Name && x.Password == credentials.Password);

            if (userExist)
            {
                FormsAuthentication.SetAuthCookie(u.Name, false);
                Session["role"] = u.Role;
                return RedirectToAction("Index", "Home");
            }
            ModelState.AddModelError("", "Username or password is wrong");
            return View();
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session.Clear();
            return RedirectToAction("Index");
        }

        
    }
}