using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using FacilitatorSystem.Models;
using System.Web.Security;

namespace FacilitatorSystem.Controllers
{
    public class LoginController : Controller
    {
        StudentsEntities1 db = new StudentsEntities1();

        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Login login)
        {
            bool userExist = db.EmployeeTables.Any(x => x.EmployeeName == login.EmployeeName && x.Password == login.Password);
            EmployeeTable u = db.EmployeeTables.FirstOrDefault(x => x.EmployeeName == login.EmployeeName && x.Password == login.Password);    
            
            if (userExist)
            {
                FormsAuthentication.SetAuthCookie(u.EmployeeName, false);
                return RedirectToAction("Index", "StudentsTables");
            }
            ModelState.AddModelError("", "Username or password is incorrect!");

            return View();
        }


    }
}