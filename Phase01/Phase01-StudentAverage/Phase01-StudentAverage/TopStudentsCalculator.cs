using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Phase01_StudentAverage
{
    internal class TopStudentsCalculator
    {
        private List<Student>? _studentList;
        private List<Course>? _courseList;
        public TopStudentsCalculator(string studentsJsonPath, string coursesJsonPath)
        {
            _studentList = JsonConvert.DeserializeObject<List<Student>>(File.ReadAllText(studentsJsonPath));
            _courseList = JsonConvert.DeserializeObject<List<Course>>(File.ReadAllText(coursesJsonPath));


        }

        public CalcSum()
        {
            top3Student = from s in _studentList
                          join c in _courseList on s.StudentNumber equals c.StudentNumber
                          group s by s.StudentNumber into g
                          select new
                          {
                              FirstName = g.First().FirstName,
                              LastName = g.First().LastName,
                              Total = g.Avg(x => x.Score)
                          }
                        orderby Total descending
                        take 3;
        }

        public void printAll()
        {
            foreach (var student in _studentList)
            {
                Console.WriteLine($"{student.FirstName}");
            }
            foreach (var course in _courseList)
            {
                Console.WriteLine($"{course.Lesson}");
            }
        }
    }
}
