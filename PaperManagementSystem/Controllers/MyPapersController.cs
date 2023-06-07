using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.SqlServer;
using System.Dynamic;
using System.Linq;
using System.Net;
using System.Runtime.Remoting;
using System.Web;
using System.Web.Mvc;
using PaperManagementSystem.Models;

namespace PaperManagementSystem.Controllers
{   
    [Authorize]
    public class MyPapersController : Controller
    {
        private PaperManagementEntity db = new PaperManagementEntity();
        
        // GET: MyPapers
        public ActionResult Index()
        {
            MyPaperViewModel model = new MyPaperViewModel();
            model.Paper = db.PaperInfoes;
            model.Topic = db.TopicInfoes;
            return View(model);
        }

        // GET: MyPapers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PaperInfo paperInfo = db.PaperInfoes.Find(id);
            if (paperInfo == null)
            {
                return HttpNotFound();
            }
            return View(paperInfo);
        }

        // GET: MyPapers/Create
        public ActionResult Create()
        {
            List<string> Topic = new List<string>();
            foreach (TopicInfo topic in db.TopicInfoes)
                Topic.Add(topic.Topic_Name);
            ViewBag.TopicList = Topic;
            return View();
        }

        // POST: MyPapers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PaperTitle,PaperAbstract,Topic_Name")] PaperInfo paperInfo)
        {
            int count = 0;
            int topicidCount = 0;
            string selected = "";
            foreach (PaperInfo last in db.PaperInfoes)
                if (count == last.PaperId)
                    count++;
                else
                    break;
            paperInfo.PaperId = count;
            paperInfo.PaperAuthor = User.Identity.Name;
            paperInfo.PaperDateSubmitted = DateTime.Now;
            selected = Request.Form["SelectedTopic"].ToString();
            foreach (TopicInfo topic in db.TopicInfoes)
            {
                if (topic.Topic_Name != selected)
                    topicidCount++;
                else
                    break;
            }
            paperInfo.TopicId = topicidCount+1;
            if (ModelState.IsValid)
            {
                db.PaperInfoes.Add(paperInfo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            if (!ModelState.IsValid)
            {
                List<string> Topic = new List<string>();
                foreach (TopicInfo topic in db.TopicInfoes)
                    Topic.Add(topic.Topic_Name);
                ViewBag.TopicList = Topic;
            }
            return View(paperInfo);
        }

        // GET: MyPapers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PaperInfo paperInfo = db.PaperInfoes.Find(id);
            if (paperInfo == null)
            {
                return HttpNotFound();
            }
            return View(paperInfo);
        }

        // POST: MyPapers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PaperId,PaperTitle,PaperAbstract,PaperAuthor,PaperDateSubmitted,TopicId")] PaperInfo paperInfo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(paperInfo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(paperInfo);
        }

        // GET: MyPapers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PaperInfo paperInfo = db.PaperInfoes.Find(id);
            if (paperInfo == null)
            {
                return HttpNotFound();
            }
            else
                ViewBag.DeleteMessage = "Paper " + id + "deleted successfully";
            return View(paperInfo);
        }

        // POST: MyPapers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PaperInfo paperInfo = db.PaperInfoes.Find(id);
            db.PaperInfoes.Remove(paperInfo);
            db.SaveChanges();
            return RedirectToAction("Index");
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
