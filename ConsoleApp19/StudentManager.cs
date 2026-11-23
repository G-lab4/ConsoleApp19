namespace ConsoleApp19;

public sealed class StudentManager
{
    private readonly List<Student> students = [];

    public bool AddStudent(string name, int score)
    {
        if (students.Any(student => string.Equals(student.Name, name, StringComparison.OrdinalIgnoreCase)))
        {
            return false;
        }

        students.Add(new Student(name, score));
        return true;
    }

    public Student? FindStudent(string name)
    {
        return students.FirstOrDefault(student =>
            string.Equals(student.Name, name, StringComparison.OrdinalIgnoreCase));
    }

    public bool UpdateScore(string name, int score)
    {
        Student? student = FindStudent(name);
        if (student is null)
        {
            return false;
        }

        student.Score = score;
        return true;
    }

    public IReadOnlyList<Student> GetAllStudents()
    {
        return students;
    }
}
