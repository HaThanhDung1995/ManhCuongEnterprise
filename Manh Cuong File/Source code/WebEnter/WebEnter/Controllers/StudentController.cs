using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebEnter.Filters;
using WebEnter.Models;
using WebEnter.Utils;

namespace WebEnter.Controllers
{
    public class StudentController : Controller
    {
        DataContext dbc = new DataContext();
        // GET: Student
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(Student model)
        {
            try
            {
                dbc.Students.Add(model);
                dbc.SaveChanges();
                ModelState.AddModelError("", "Regist Successfully !");
            }
            catch
            {
                ModelState.AddModelError("", "Regist Fail!");
            }
            return View();
        }
        public ActionResult Login(string ReturnUrl, string Message)
        {
            if (ReturnUrl != null)
            {
                ViewBag.ReturnUrl = ReturnUrl;
            }
            ModelState.AddModelError("", Message);
            return View();
        }
        [HttpPost]
        public ActionResult Login(string id, string password,string ReturnUrl)
        {
            var manager = dbc.Students.SingleOrDefault(m => m.Username == id && m.Pass == password);
            if (manager == null)
            {
                ModelState.AddModelError("", "Wrong ID!");
            }
            else
            {
                ModelState.AddModelError("", "Login Successfully!");
                XSession.Student = manager;
                if (ReturnUrl != null)
                {
                    return Redirect(ReturnUrl);
                }
                return View();
            }

            return View();
        }
        public ActionResult Logout()
        {
            XSession.RemoveStudent();
            return View("Login");
        }
        [StudentAuthenticate]
        public ActionResult FeedBack()
        {
            ViewBag.TutorId = new SelectList(dbc.Turtors, "Id", "Fullname");
            return View();
        }
        [StudentAuthenticate]
        [HttpPost]
        public ActionResult FeedBack(Feedback model)
        {
            model.StudentId = XSession.Student.Id;
            dbc.Feedbacks.Add(model);
            dbc.SaveChanges();
            return RedirectToAction("FeedBack");
        }
    }
}