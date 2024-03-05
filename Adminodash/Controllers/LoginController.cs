using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Adminodash.Entities;
using Adminodash.Context;
using System.Web.Security;
using Adminodash.Repository;

namespace Adminodash.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        AdminContext db = new AdminContext();
        AdminRepository admindb = new AdminRepository();
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult LoginPage()
        {
            return View();
        }
        [HttpPost]
        public ActionResult LoginPage(Admin t)
        {
            var value = db.admins.FirstOrDefault(x => x.UserName == t.UserName && x.Password == t.Password);
            if (value!=null)
            {
                FormsAuthentication.SetAuthCookie(value.UserName, false);
                Session["UserName"] = value.UserName.ToString();
                return RedirectToAction("Index", "Default");
            }
            else
            {
                return RedirectToAction("LoginPage", "Login");
            }
        }
        [HttpGet]
        public ActionResult ResetPassowrdPage()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ResetPassowrdPage(Admin t)
        {
            var value = db.admins.FirstOrDefault(x => x.UserName == t.UserName && x.ResetPassword == t.ResetPassword);
            if (value != null)
            {
                value.Password = t.Password;
                admindb.TUpdate(value);
                return RedirectToAction("LoginPage");
            }
            else
            {
                return RedirectToAction("ResetPassowrdPage");
            }
        }
    }
}