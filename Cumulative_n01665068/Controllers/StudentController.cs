using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Cumulative_n01665068.Models;


namespace Cumulative_n01665068.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// This method is used to list the Names of all the Students in the List View
        /// </summary>
        /// <returns>A View that displays the Full Names of all Students</returns>
        public ActionResult List()
        {
            StudentDataController controller = new StudentDataController();
            List<Student> Students = controller.ListStudents();
            return View(Students);
        }


        /// <summary>
        /// This method is used to show the details of the selected Student
        /// </summary>
        /// <returns>A View that displays all the Details of the Student selected in the List View</returns>
        public ActionResult Show(int Id)
        {
            StudentDataController controller = new StudentDataController();
            Student NewStudent = controller.FindStudent(Id);

            return View(NewStudent);
        }
    }
}