using System.Resources;

namespace Phase01_StudentAverage;

internal class Program
{
    static void Main()
    {
        try
        {
            string studentsFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, Resources.StudentsFilePath);
            string coursesFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, Resources.CoursesFilePath);

            var topStudentsCalculator = new TopStudentsCalculator(studentsFilePath, coursesFilePath);
            topStudentsCalculator.PrintTopNStudentAverageScore(3);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.ToString());
        }
    }
}
