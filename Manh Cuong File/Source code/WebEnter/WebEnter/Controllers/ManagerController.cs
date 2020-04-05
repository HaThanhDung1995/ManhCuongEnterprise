using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebEnter.Filters;
using WebEnter.Models;
using WebEnter.Utils;

namespace WebEnter.Controllers
{
    public class ManagerController : Controller
    {
       DataContext dbc =new DataContext();
        // GET: Manager
[Custom(PermissionNames = "Admin")]
        public ActionResult Index()
        {
            ViewBag.StudentId = dbc.Students.ToList();
            ViewBag.TutorId = new SelectList(dbc.Turtors, "Id", "Fullname");
            return View();
        }
        [Custom(PermissionNames = "Admin")]
        [HttpPost]
        public ActionResult Index(int[] StudentId, int TutorId)
        {
            ViewBag.StudentId = dbc.Students.ToList();
            ViewBag.TutorId = new SelectList(dbc.Turtors, "Id", "Fullname");
            foreach (var student in StudentId)
            {
                Arranx dung = new Arranx
                {
                    StudentId = student,
                    TutorId = TutorId
                };
                dbc.Arranges.Add(dung);
            }

            dbc.SaveChanges();
            return View();
        }
        public ActionResult Login(string ReturnUrl,string Message)
        {
            ModelState.AddModelError("", Message);
            return View();
        }
        [HttpPost]
        public ActionResult Login(String id, String password,string ReturnUrl)
        {
            var manager = dbc.Masters.SingleOrDefault(m => m.Username == id&&m.Pass==password);
            if (manager == null)
            {
                ModelState.AddModelError("", "Wrong ID!");
            }
            else
            {
                ModelState.AddModelError("", "Login Successfully!");
                XSession.Master = manager;
                if (ReturnUrl != null)
                {
                    ViewBag.ReturnUrl = ReturnUrl;
                    return Redirect(ReturnUrl);
                }
                return View();
            }

            return View();
        }
        [Custom(PermissionNames = "Admin")]
        public ActionResult ManagerStudent()
        {
            ViewBag.Items = dbc.Students.ToList();
            var model = new Student();
            return View(model);
        }
        [Custom(PermissionNames = "Admin")]
        public ActionResult Edit(int Id)
        {
            ViewBag.Items = dbc.Students.ToList();
            var model = dbc.Students.Find(Id);
            return View("Index", model);
        }
        [Custom(PermissionNames = "Admin")]
        public ActionResult Delete(int Id)
        {
            var model = dbc.Students.Find(Id);
            
                dbc.Students.Remove(model);
                dbc.SaveChanges();
                TempData["Message"] = "Delete Successfully!";
                return RedirectToAction("Index");
            
          
            
        }
        [Custom(PermissionNames = "Admin")]
        public ActionResult Logout()
        {
            XSession.RemoveAdmin();
            return RedirectToAction("Login");



        }
        [Custom(PermissionNames = "Admin")]
        public ActionResult ManagerPost()
        {
            var list = dbc.Reports.ToList();
            
            return View(list);
        }
        [Custom(PermissionNames = "Admin")]
        public ActionResult ManagerFeedback()
        {
            var list = dbc.Feedbacks.ToList();

            return View(list);
        }
    }
}