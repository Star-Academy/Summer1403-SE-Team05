namespace Phase01_StudentAverage
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string studentsFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Assets", "Students.json");
            string coursesFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Assets", "Courses.json");

            TopStudentsCalculator topStudentsCalculator = new TopStudentsCalculator(studentsFilePath, coursesFilePath);
            topStudentsCalculator.PrintTopNStudents(3);
        }
    }
}
