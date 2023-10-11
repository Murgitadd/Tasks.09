using System;
using System.Text.RegularExpressions;

class Program
{
    static void Main(string[] args)
    {
        string name = GetName();
        byte age = GetAge();
        int grade = GetGrade();

        if (name == null || age == 0 || grade == -1)
        {
            Console.WriteLine("Invalid input. Exiting the program.");
            return;
        }

        Student student = new Student
        {
            Name = name,
            Age = age,
            Grade = grade
        };

        Console.WriteLine($"Student Name: {student.Name}");
        Console.WriteLine($"Student Age: {student.Age}");
        Console.WriteLine($"Student Grade: {student.Grade}");
    }

    static string GetName()
    {
        string name;
        do
        {
            Console.WriteLine("Enter your name:");
            name = Console.ReadLine();
            name = NameChecker(name);
        } while (name == null);

        return name;
    }

    static byte GetAge()
    {
        byte age;
        do
        {
            Console.WriteLine("Enter your age:");
            if (byte.TryParse(Console.ReadLine(), out age))
            {
                age = AgeChecker(age);
            }
            else
            {
                Console.WriteLine("Invalid age. Please enter a valid age.");
            }
        } while (age == 0);

        return age;
    }

    static int GetGrade()
    {
        int grade;
        do
        {
            Console.WriteLine("Enter your grade (0-100):");
            if (int.TryParse(Console.ReadLine(), out grade))
            {
                grade = GradeChecker(grade);
            }
            else
            {
                Console.WriteLine("Invalid grade. Please enter a valid grade.");
            }
        } while (grade == -1);

        return grade;
    }

    static string NameChecker(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            Console.WriteLine("Please fill the input");
            return null;
        }
        else
        {
            name = Regex.Replace(name, "\\s", "");

            if (Regex.IsMatch(name, "^[A-Z][a-z]*$"))
            {
                return name;
            }
            else
            {
                name = name.ToLower();
                name = char.ToUpper(name[0]) + name.Substring(1);
                return name;
            }
        }
    }

    static byte AgeChecker(byte age)
    {
        if (age <= 0)
        {
            Console.WriteLine("Invalid age. Please enter a valid age.");
            return 0;
        }
        return age;
    }

    static int GradeChecker(int grade)
    {
        if (grade < 0 || grade > 100)
        {
            Console.WriteLine("Invalid grade.");
            return -1;
        }
        return grade;
    }
}

public class Student
{
    private string name;
    private byte age;
    private int grade;

    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    public byte Age
    {
        get { return age; }
        set { age = value; }
    }

    public int Grade
    {
        get { return grade; }
        set { grade = value; }
    }
}
