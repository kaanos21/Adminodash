using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Adminodash.Repository;
using Adminodash.Context;
using Adminodash.Entities;
using Adminodash.ValidationRules;
using FluentValidation.Results;

namespace Adminodash.Controllers
{
    public class ProjectController : Controller
    {
        
        // GET: Project
        ProjectRepository db = new ProjectRepository();
        AdminContext admincontext = new AdminContext();
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ProjectsPartial()
        {
            var value=db.List();
            return PartialView(value);
        }
        

        [HttpGet]
        public ActionResult ProjectAdd()
        {
            List<SelectListItem> ccc = (from x in admincontext.projectCategories.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = x.CategoryName,
                                                 Value = x.ProjectCategoryId.ToString()
                                             }).ToList();
            ViewBag.category = ccc;
            List<SelectListItem> ddd = (from x in admincontext.projectStatuses.ToList()
                                        select new SelectListItem
                                        {
                                            Text = x.ProjectStatusName,
                                            Value = x.ProjectStatusId.ToString()
                                        }).ToList();
            ViewBag.status = ddd;
            return View();
        }
        [HttpPost]

        public ActionResult ProjectAdd(Project t)
        {
            ProjectValidatior vvv = new ProjectValidatior();
            ValidationResult results = vvv.Validate(t);
            if (results.IsValid)
            {
                db.Tadd(t);
                return RedirectToAction("Index", "Default");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            ViewBag.category = (from x in admincontext.projectCategories.ToList()
                                select new SelectListItem
                                {
                                    Text = x.CategoryName,
                                    Value = x.ProjectCategoryId.ToString()
                                }).ToList();

            ViewBag.status = (from x in admincontext.projectStatuses.ToList()
                              select new SelectListItem
                              {
                                  Text = x.ProjectStatusName,
                                  Value = x.ProjectStatusId.ToString()
                              }).ToList();
            return View();
        }

        public ActionResult ProjectDelete(int id)
        {
            var value = db.find(x => x.ProjectId == id);
            db.Tdelete(value);
            return RedirectToAction("Index", "Default");
        }
        [HttpGet]

        public ActionResult ProjectUpdate(int id)
        {
            List<SelectListItem> ccc = (from x in admincontext.projectCategories.ToList()
                                        select new SelectListItem
                                        {
                                            Text = x.CategoryName,
                                            Value = x.ProjectCategoryId.ToString()
                                        }).ToList();
            ViewBag.category = ccc;
            List<SelectListItem> ddd = (from x in admincontext.projectStatuses.ToList()
                                        select new SelectListItem
                                        {
                                            Text = x.ProjectStatusName,
                                            Value = x.ProjectStatusId.ToString()
                                        }).ToList();
            ViewBag.status = ddd;
            var value = db.find(x => x.ProjectId == id);
            return View(value);
        }
        [HttpPost]

        public ActionResult ProjectUpdate(Project t)
        {
            var value = db.find(x => x.ProjectId == t.ProjectId);
            value.ProjectName = t.ProjectName;
            value.ProjectDescription = t.ProjectDescription;
            value.ProjectCategoryId = t.ProjectCategoryId;
            value.ProjectStatusId = t.ProjectStatusId;
            value.ProjectProgress = t.ProjectProgress;
            db.TUpdate(value);
            return RedirectToAction("Index", "Default");
        }
        

    }
}