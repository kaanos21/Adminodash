using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Adminodash.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult PageVisitPartial()
        {
            return PartialView();
        }

        public ActionResult TeamMembersPartial()
        {
            return PartialView();
        }

        public ActionResult ProjectsPartial()
        {
            return PartialView();
        }

       
    }
}