using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phase01_StudentAverage
{
    internal class Course
    {
        public Course(int studentNumber, string lesson, double score)
        {
            StudentNumber = studentNumber;
            Lesson = lesson;
            Score = score;
        }
        public int StudentNumber { get; set; }
        public string Lesson { get; set; }
        public double Score { get; set; }
    }
}
