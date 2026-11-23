namespace ConsoleApp19;

public sealed class Student
{
    public Student(string name, int score)
    {
        Name = name;
        Score = score;
    }

    public string Name { get; }

    public int Score { get; set; }
}
