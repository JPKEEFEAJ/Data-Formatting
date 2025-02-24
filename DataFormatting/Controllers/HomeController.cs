using DataFormatting.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Drawing;
using System.IO;

namespace DataFormatting.Controllers
{
    public class HomeController : Controller
    {
        private static string filePath = "textFileToFormat.txt";

        public IActionResult Index()
        {
            StudentData model = new()
            {
                ActiveStudents = [],
                InactiveStudents = []
            };
            string line;
            Student student;

            StreamReader sr = new StreamReader(filePath);
            line = sr.ReadLine();
            while ((line = sr.ReadLine()) != null) 
            {
                string[] values = line.Split(", ");
                student = new Student()
                {
                    StudentId = Convert.ToInt32(values[0]),
                    StudentName = values[1],
                    StudentAge = Convert.ToInt32(values[2]),
                    StudentGradePointAverage = Convert.ToDouble(values[3]),
                    StudentJoinDate = DateOnly.Parse(values[4]),
                    StudentActive = Convert.ToBoolean(values[5])
                };
                if (student.StudentActive)
                {
                    model.ActiveStudents.Add(student);
                }
                else
                {
                    model.InactiveStudents.Add(student);
                }
            }
            sr.Close();

            model.AverageActiveAge = 0;
            model.AverageActiveGPA = 0;
            foreach (Student activeStudent in model.ActiveStudents)
            {
                model.AverageActiveAge += activeStudent.StudentAge;
                model.AverageActiveGPA += activeStudent.StudentGradePointAverage;
            }
            model.AverageActiveAge = Math.Round(model.AverageActiveAge / model.ActiveStudents.Count, 2);
            model.AverageActiveGPA = Math.Round(model.AverageActiveGPA / model.ActiveStudents.Count, 2);

            model.AverageInactiveAge = 0;
            model.AverageInactiveGPA = 0;
            foreach (Student inactiveStudent in model.InactiveStudents)
            {
                model.AverageInactiveAge += inactiveStudent.StudentAge;
                model.AverageInactiveGPA += inactiveStudent.StudentGradePointAverage;
            }
            model.AverageInactiveAge = Math.Round(model.AverageInactiveAge / model.InactiveStudents.Count, 2);
            model.AverageInactiveGPA = Math.Round(model.AverageInactiveGPA / model.InactiveStudents.Count, 2);

            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}
