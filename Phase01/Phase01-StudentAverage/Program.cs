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

            TopStudentsCalculator topStudentsCalculator = new TopStudentsCalculator(studentsFilePath, coursesFilePath);
            topStudentsCalculator.PrintTopNStudents(3);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.ToString());
        }
    }
}
