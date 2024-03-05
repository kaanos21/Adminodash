using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Adminodash.Repository;
using Adminodash.Entities;

namespace Adminodash.Controllers
{
    public class PageVisitController : Controller
    {
        // GET: PageVisit
        PageVisitRepository db = new PageVisitRepository();
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult PageVisitPartial()
        {
            var value=db.List();
            return PartialView(value);
        }

        [HttpGet]
        public ActionResult PageVisitAdd()
        {
            return View();
        }

        [HttpPost]
        public ActionResult PageVisitAdd(PageVisit t)
        {
            t.PageStatus = true;
            db.Tadd(t);
            return RedirectToAction("Index", "Default");
        }

        public ActionResult PageVisitDelete(int id)
        {
            var value = db.find(x=>x.PageId==id);
            db.Tdelete(value);
            return RedirectToAction("Index", "Default");
        }
        [HttpGet]
        public ActionResult PageVisitUpdate(int id)
        {
            var value = db.find(x => x.PageId == id);
            return View(value);
        }

        [HttpPost]
        public ActionResult PageVisitUpdate(PageVisit t)
        {
            var value = db.find(x => x.PageId == t.PageId);
            value.PageName = t.PageName;
            value.PageStatus = t.PageStatus;
            value.PageValue = t.PageValue;
            value.PageViews = t.PageViews;
            value.BounceRate = t.BounceRate;
            db.TUpdate(value);
            return RedirectToAction("Index", "Default");
        }
    }
}