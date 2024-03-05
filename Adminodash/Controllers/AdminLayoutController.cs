using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Adminodash.Controllers
{
    public class AdminLayoutController : Controller
    {
        // GET: AdminLayout
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Dashboard()
        {
            return View();
        }

        public PartialViewResult HeadPartial()
        {
            return PartialView();
        }

        public PartialViewResult NavBarPartial()
        {
            return PartialView();
        }

        public ActionResult NewTaskPartial()
        {
            return PartialView();
        }

        public ActionResult PageVisitPartial()
        {
            return PartialView();
        }

        public ActionResult ScriptPartial()
        {
            return PartialView();
        }

    }
}