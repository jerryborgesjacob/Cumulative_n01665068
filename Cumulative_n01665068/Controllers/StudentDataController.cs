﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Cumulative_n01665068.Models;
using MySql.Data.MySqlClient;
namespace Cumulative_n01665068.Controllers
{
    public class StudentDataController : ApiController
    {
        private SchoolContext School = new SchoolContext();

        /// <summary>
        /// Connects to the Database and provides the details Of the Students 
        /// </summary>
        /// <returns>The Details of the Students</returns>
        /// <example>
        /// localhost.xx/api/StudentData -> The List of Students in an XML File
        /// </example>

        [HttpGet]
        [Route("api/StudentData")] //This will display the Students' Data in an XML File
        public List<Student> ListStudents()
        {
            //Create an instance of the connection
            MySqlConnection Conn = School.AccessDatabase();

            //Open the connection between the web server and the database
            Conn.Open();

            //Establish a new command 
            MySqlCommand cmd = Conn.CreateCommand();

            //Query to Execute
            cmd.CommandText = "SELECT * FROM students";

            //Gather the result set into a variable
            MySqlDataReader ResultSet = cmd.ExecuteReader();

            //Create a list of Students' Details that will be stored later
            List<Student> Students = new List<Student> { };

            //Loop Through the Result Set
            while (ResultSet.Read())
            {
                //Access The Table Column by Column Names
                string StudentName = ResultSet["studentfname"].ToString() + " " + ResultSet["studentlname"].ToString();
                int StudentID = Convert.ToInt32(ResultSet["studentid"]);
                string SdtNumber = ResultSet["studentnumber"].ToString();
                DateTime Enrol = Convert.ToDateTime(ResultSet["enroldate"]);


                //Creating a New Object to store the data
                Student NewStudent = new Student();

                //Adding the Students' Details to the List created above
                NewStudent.StudentID = StudentID;
                NewStudent.StudentName = StudentName;
                NewStudent.SdtNumber = SdtNumber;
                NewStudent.Enrol = Enrol;


                Students.Add(NewStudent);

            }

            //Close the connection between the Database and the Web Server
            Conn.Close();

            //Return the list of Students' Names
            return Students;


        }


        /// <summary>
        /// Connects to the Database and provides all the Details about a Student (using their StudentID) 
        /// </summary>
        /// <returns>All Details of the specific Student in the database</returns>
        /// <example>
        /// localhost.xx/api/StudentsData/FindStudent/4 -> Displays the Student's Full Name, StudentID, StudentNumber and Enrollment Date of Mario English
        /// </example>

        [HttpGet]
        [Route("api/StudentData/FindStudent/{Id}")]

        public Student FindStudent(int Id)
        {

            //Create an instance of the connection
            MySqlConnection Conn = School.AccessDatabase();

            //Open the connection between the web server and the database
            Conn.Open();

            //Establish a new command 
            MySqlCommand cmd = Conn.CreateCommand();

            //Query to Execute
            cmd.CommandText = "SELECT * FROM students where StudentID = " + Id;

            //Gather the result set into a variable
            MySqlDataReader ResultSet = cmd.ExecuteReader();


            //Creating a New Object to store the data
            Student NewStudent = new Student();

            //Loop Through the Result Set
            while (ResultSet.Read())
            {
                //Access The Table Column by Column Names
                string StudentName = ResultSet["studentfname"].ToString() + " " + ResultSet["studentlname"].ToString();
                int StudentID = Convert.ToInt32(ResultSet["studentid"]);
                string SdtNumber = ResultSet["studentnumber"].ToString();
                DateTime Enrol = Convert.ToDateTime(ResultSet["enroldate"]);

                //Adding the Students' Details to the List created above
                NewStudent.StudentID = StudentID;
                NewStudent.StudentName = StudentName;
                NewStudent.SdtNumber = SdtNumber;
                NewStudent.Enrol = Enrol;
            }

                return NewStudent;
            
        }
    }
}