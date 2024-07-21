using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phase01_StudentAverage
{
    internal class Course
    {
        public int StudentNumber { get; set; } = 0;
        public string Lesson { get; set; } = string.Empty;
        public double Score { get; set; } = 0.0;
        public Course(int studentNumber, string lesson, double score)
        {
            StudentNumber = studentNumber;
            Lesson = lesson;
            Score = score;
        }
    }
}
