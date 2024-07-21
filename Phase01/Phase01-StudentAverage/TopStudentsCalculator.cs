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

        private IEnumerable<dynamic> GetTop3Students()
        {
            return (from student in _studentList
                    join course in _courseList on student.StudentNumber equals course.StudentNumber
                    group new { student.FirstName, student.LastName, course.Score } by student.StudentNumber into studentGroup
                    let avgScore = studentGroup.Average(x => x.Score)
                    orderby avgScore descending
                    select new
                    {
                        FirstName = studentGroup.First().FirstName,
                        LastName = studentGroup.First().LastName,
                        AverageScore = avgScore
                    }).Take(3);
        }

        public void PrintTop3Students()
        {
            var top3Students = GetTop3Students();
            foreach (var student in top3Students)
            {
                Console.WriteLine($"Name: {student.FirstName} {student.LastName}, Average Score: {student.AverageScore}");
            }
        }
    }
}
