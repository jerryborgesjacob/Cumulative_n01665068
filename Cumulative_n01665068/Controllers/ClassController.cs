using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Cumulative_n01665068.Models;


namespace Cumulative_n01665068.Controllers
{
    public class ClassController : Controller
    {
        // GET: Class
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// This method is used to list the Names of all Classes in the List View
        /// </summary>
        /// <returns>A View that displays the Full Names of all CLasses</returns>
        public ActionResult List()
        {
            ClassDataController controller = new ClassDataController();
            List<Class> Classes = controller.ListClasses();
            return View(Classes);
        }


        /// <summary>
        /// This method is used to show the detials of a selected Class
        /// </summary>
        /// <returns>A View that displays all the Details of the Class selected in the List View</returns>
        public ActionResult Show(int Id)
        {
            ClassDataController controller = new ClassDataController();
            Class NewClass = controller.FindClass(Id);

            return View(NewClass);
        }
    }
}