using Newtonsoft.Json;

namespace Phase01_StudentAverage;

internal class TopStudentsCalculator
{
    private List<Student> _studentList = new List<Student>();
    private List<Course> _courseList = new List<Course>();
    public TopStudentsCalculator(string studentsJsonPath, string coursesJsonPath)
    {
        var deserializedStudentList = JsonConvert.DeserializeObject<List<Student>>(File.ReadAllText(studentsJsonPath));
        var deserializedCourseList = JsonConvert.DeserializeObject<List<Course>>(File.ReadAllText(coursesJsonPath));

        if (deserializedStudentList != null)
            _studentList.AddRange(deserializedStudentList);

        if (deserializedCourseList != null)
            _courseList.AddRange(deserializedCourseList);
    }

    private IEnumerable<dynamic> GetTopNStudents(int n)
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
                }).Take(n);
    }

    public void PrintTopNStudents(int n)
    {
        var topNStudents = GetTopNStudents(n);
        foreach (var student in topNStudents)
        {
            Console.WriteLine($"Name: {student.FirstName} {student.LastName}, Average Score: {student.AverageScore}");
        }
    }
}
