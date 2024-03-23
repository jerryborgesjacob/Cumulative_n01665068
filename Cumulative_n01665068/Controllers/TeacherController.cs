using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Cumulative_n01665068.Models;


namespace Cumulative_n01665068.Controllers
{
    public class TeacherController : Controller
    {
        // GET: Teacher
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// This method is used to list the Names of all the Teacher in the List View
        /// </summary>
        /// <returns>A View that displays the Full Names of all Teachers</returns>
        public ActionResult List()
        {
            TeacherDataController controller = new TeacherDataController();
            List <Teacher> Teachers = controller.ListTeachers();
            return View(Teachers);
        }


        /// <summary>
        /// This method is used to show the details of the selected teacher
        /// </summary>
        /// <returns>A View that displays all the Details of the teacher selected in the List View</returns>
        public ActionResult Show(int Id)
        {
            TeacherDataController controller = new TeacherDataController();
            Teacher NewTeacher = controller.FindTeacher(Id);

            return View(NewTeacher);
        }
    }
}