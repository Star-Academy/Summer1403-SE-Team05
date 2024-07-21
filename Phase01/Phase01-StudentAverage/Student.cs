using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phase01_StudentAverage
{
    internal class Student
    {
        public Student(int studentNumber, string firstName, string lastName)
        {
            StudentNumber = studentNumber;
            FirstName = firstName;
            LastName = lastName;
        }
        public int StudentNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
