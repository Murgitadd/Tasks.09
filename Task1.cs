using System;

class Employee
{
    public static string Name { get; set; } = "Murad";
    public static double Salary { get; set; } = 500;
    public bool IsSuccessful { get; set; }

    public void GetFeedback()
    {
        Console.WriteLine("Did you like the employee? (Enter 'true' or 'false')");
        if (bool.TryParse(Console.ReadLine(), out bool liked))
        {
            IsSuccessful = liked;

            if (IsSuccessful)
            {
                Salary += 100;
                Console.WriteLine("Employee's salary increased by 100.");
            }
            else
            {
                Console.WriteLine("Employee's salary remains the same.");
            }
        }
        else
        {
            Console.WriteLine("Invalid input for feedback. Employee's salary remains the same.");
        }
    }
}

class Program
{
    static void Main()
    {
        Console.WriteLine($"Employee: {Employee.Name}");
        Console.WriteLine($"Salary: {Employee.Salary}");

        Employee employee = new Employee();
        employee.GetFeedback();

        Console.WriteLine($"Updated Salary: {Employee.Salary}");
        Console.WriteLine($"Is Successful: {employee.IsSuccessful}");

        Console.WriteLine("Press any key to exit...");
        Console.ReadKey();
    }
}
