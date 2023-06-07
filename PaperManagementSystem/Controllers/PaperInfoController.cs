using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PaperManagementSystem.Models;

namespace PaperManagementSystem.Controllers
{
    public class PaperInfoController : Controller
    {
        private PaperManagementEntities1 db = new PaperManagementEntities1();

        // GET: PaperInfoes
        public ActionResult Index()
        {
            return View(db.PaperInfoes.ToList());
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
