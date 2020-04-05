using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebEnter.Models;

namespace WebEnter.Controllers
{
    public class TestController : Controller
    {
        DataContext dbc =new DataContext();
        // GET: Test
        public ActionResult Index()
        {
            ViewBag.StudentId = dbc.Students.ToList();
            ViewBag.TutorId = new SelectList(dbc.Turtors, "Id", "Fullname");
            return View();
        }

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
    }
}