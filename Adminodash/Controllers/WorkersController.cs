using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Adminodash.Repository;

namespace Adminodash.Controllers
{
    public class WorkersController : Controller
    {
        // GET: Workers
        
        WorkerRepository db = new WorkerRepository();
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult TeamMembersPartial()
        {
            var value = db.List();
            return PartialView(value);
        }
    }
}