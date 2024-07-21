namespace Phase01_StudentAverage
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TopStudentsCalculator topStudentsCalculator = new TopStudentsCalculator("Students.json", "Courses.json");
            topStudentsCalculator.PrintTop3Students();
        }
    }
}
