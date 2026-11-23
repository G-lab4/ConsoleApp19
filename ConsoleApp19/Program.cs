namespace ConsoleApp19;

internal class Program
{
    private static readonly StudentManager StudentManager = new();

    private static void Main()
    {
        bool running = true;

        while (running)
        {
            ShowMenu();
            string choice = Console.ReadLine()?.Trim() ?? string.Empty;

            switch (choice)
            {
                case "1":
                    AddStudent();
                    break;
                case "2":
                    SearchStudent();
                    break;
                case "3":
                    UpdateScore();
                    break;
                case "4":
                    ShowAllStudents();
                    break;
                case "0":
                    running = false;
                    Console.WriteLine("The program has ended.");
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }

    private static void ShowMenu()
    {
        Console.WriteLine("\n===== Student Management =====");
        Console.WriteLine("1. Add a student");
        Console.WriteLine("2. Search for a student");
        Console.WriteLine("3. Update a score");
        Console.WriteLine("4. Show all students");
        Console.WriteLine("0. Exit");
        Console.Write("Choose an operation: ");
    }

    private static void AddStudent()
    {
        Console.Write("Enter the student's name: ");
        string name = Console.ReadLine()?.Trim() ?? string.Empty;

        if (string.IsNullOrWhiteSpace(name))
        {
            Console.WriteLine("The name cannot be empty.");
            return;
        }

        if (StudentManager.FindStudent(name) is not null)
        {
            Console.WriteLine("A student with that name already exists.");
            return;
        }

        Console.Write("Enter the score: ");
        if (!int.TryParse(Console.ReadLine(), out int score))
        {
            Console.WriteLine("The score must be a whole number.");
            return;
        }

        StudentManager.AddStudent(name, score);
        Console.WriteLine("The student was added successfully.");
    }

    private static void SearchStudent()
    {
        Console.Write("Enter the student's name: ");
        string name = Console.ReadLine()?.Trim() ?? string.Empty;
        Student? student = StudentManager.FindStudent(name);

        if (student is not null)
        {
            Console.WriteLine($"{student.Name}'s score is {student.Score}.");
        }
        else
        {
            Console.WriteLine("Student not found.");
        }
    }

    private static void UpdateScore()
    {
        Console.Write("Enter the student's name: ");
        string name = Console.ReadLine()?.Trim() ?? string.Empty;

        if (StudentManager.FindStudent(name) is null)
        {
            Console.WriteLine("Student not found.");
            return;
        }

        Console.Write("Enter the new score: ");
        if (!int.TryParse(Console.ReadLine(), out int newScore))
        {
            Console.WriteLine("The score must be a whole number.");
            return;
        }

        StudentManager.UpdateScore(name, newScore);
        Console.WriteLine("The score was updated successfully.");
    }

    private static void ShowAllStudents()
    {
        IReadOnlyList<Student> students = StudentManager.GetAllStudents();

        if (students.Count == 0)
        {
            Console.WriteLine("The student list is empty.");
            return;
        }

        Console.WriteLine("\n--- Student List ---");
        foreach (Student student in students)
        {
            Console.WriteLine($"{student.Name} - {student.Score}");
        }
    }
}
