using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Cumulative_n01665068.Models;
using MySql.Data.MySqlClient;
namespace Cumulative_n01665068.Controllers
{
    public class ClassDataController : ApiController
    {
        private SchoolContext School = new SchoolContext();

        /// <summary>
        /// Connects to the Database and provides the details of the various classes. 
        /// </summary>
        /// <returns>The details about the classes that is stored in the Database.</returns>
        /// <example>
        /// localhost.xx/api/ClassData -> The List of Classes in an XML File.
        /// </example>

        [HttpGet]
        [Route("api/ClassData")] //This will display Class Data in an XML File
        public List<Class> ListClasses()
        {
            //Create an instance of the connection
            MySqlConnection Conn = School.AccessDatabase();

            //Open the connection between the web server and the database
            Conn.Open();

            //Establish a new command 
            MySqlCommand cmd = Conn.CreateCommand();

            //Query to Execute
            cmd.CommandText = "SELECT * FROM classes";

            //Gather the result set into a variable
            MySqlDataReader ResultSet = cmd.ExecuteReader();

            //Create a list of Teachers' Details that will be stored later
            List<Class> Classes = new List<Class> { };

            //Loop Through the Result Set
            while (ResultSet.Read())
            {
                //Access The Table Column by Column Names
                string ClassName = ResultSet["classname"].ToString();
                int ClassID = Convert.ToInt32(ResultSet["classid"]);
                int TeacherId = Convert.ToInt32(ResultSet["teacherid"]);
                string ClassCode = ResultSet["classcode"].ToString();
                DateTime StartDate = Convert.ToDateTime(ResultSet["startdate"]);
                DateTime FinishDate = Convert.ToDateTime(ResultSet["finishdate"]);


                //Creating a New Object to store the data
                Class NewClass = new Class();

                //Adding the Class Details to the List created above
                NewClass.ClassName = ClassName;
                NewClass.ClassID = ClassID;
                NewClass.TeacherId = TeacherId;
                NewClass.ClassCode = ClassCode;
                NewClass.StartDate = StartDate;
                NewClass.FinishDate = FinishDate;


                Classes.Add(NewClass);

            }

            //Close the connection between the Database and the Web Server
            Conn.Close();

            //Return the list of Teachers' Names
            return Classes;


        }


        /// <summary>
        /// Connects to the Database and provides all the Details about a Student (using their TeacherID) 
        /// </summary>
        /// <returns>All Details of the specific Student in the database</returns>
        /// <example>
        /// localhost.xx/api/StudentsData/FindStudent/4 -> Displays EmpNumber, HireDate, Salary, TeacherID and Full Name of Jessica Morris. 
        /// (I tried to copy and paste the XML output, but the tags in XML started throwing errors in the code)
        /// </example>

        [HttpGet]
        [Route("api/ClassData/FindClass/{Id}")]

        public Class FindClass(int Id)
        {

            //Create an instance of the connection
            MySqlConnection Conn = School.AccessDatabase();

            //Open the connection between the web server and the database
            Conn.Open();

            //Establish a new command 
            MySqlCommand cmd = Conn.CreateCommand();

            //Query to Execute
            cmd.CommandText = "SELECT * FROM classes where classid = " + Id;

            //Gather the result set into a variable
            MySqlDataReader ResultSet = cmd.ExecuteReader();


            //Creating a New Object to store the data
            Class NewClass = new Class();

            //Loop Through the Result Set
            while (ResultSet.Read())
            {
                //Access The Table Column by Column Names
                string ClassName = ResultSet["classname"].ToString();
                int ClassID = Convert.ToInt32(ResultSet["classid"]);
                int TeacherId = Convert.ToInt32(ResultSet["teacherid"]);
                string ClassCode = ResultSet["classcode"].ToString();
                DateTime StartDate = Convert.ToDateTime(ResultSet["startdate"]);
                DateTime FinishDate = Convert.ToDateTime(ResultSet["finishdate"]);

                //Adding details to the Object
                NewClass.ClassName = ClassName;
                NewClass.ClassID = ClassID;
                NewClass.TeacherId = TeacherId;
                NewClass.ClassCode = ClassCode;
                NewClass.StartDate = StartDate;
                NewClass.FinishDate = FinishDate;
            }

            return NewClass;

        }
    }
}
