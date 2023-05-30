using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using FacilitatorSystem.Models;

namespace FacilitatorSystem.Controllers
{
    public class RegisterController : Controller
    {
        // GET: Register
        StudentsEntities1 db = new StudentsEntities1();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(EmployeeTable employee, Register reg)
        {
            if (reg.Password == reg.ConfirmPassword)
            {
                db.EmployeeTables.Add(employee);
                db.SaveChanges();
                return RedirectToAction("Index", "Login");
            }
            ModelState.AddModelError("", "Passwords don't match");

            return View();

        }
    }
}