using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebEnter.Models;

namespace WebEnter.Utils
{
    public class XSession
    {
        public static Master Master
        {
            get
            {
                return HttpContext.Current.Session["Master"] as Master;
            }
            set
            {
                HttpContext.Current.Session["Master"] = value;
            }
        }
        public static void RemoveAdmin()
        {
            HttpContext.Current.Session.Remove("Master");
        }
        public static Turtor Tutor
        {
            get
            {
                return HttpContext.Current.Session["Tutor"] as Turtor;
            }
            set
            {
                HttpContext.Current.Session["Tutor"] = value;
            }
        }
        public static void RemoveTutor()
        {
            HttpContext.Current.Session.Remove("Tutor");
        }
        public static Student Student
        {
            get
            {
                return HttpContext.Current.Session["Student"] as Student;
            }
            set
            {
                HttpContext.Current.Session["Student"] = value;
            }
        }
        public static void RemoveStudent()
        {
            HttpContext.Current.Session.Remove("Student");
        }
    }
}