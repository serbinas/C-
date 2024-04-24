using System;

public class Employee
{
    internal string name;
    private DateTime hiringDate;

    public Employee(string name, DateTime hiringDate)
    {
        this.name = name;
        this.hiringDate = hiringDate;
    }

    public int Experience()
{
    DateTime currentDate = DateTime.Now;
    int experience = currentDate.Year - hiringDate.Year;
    if (currentDate.Month < hiringDate.Month || (currentDate.Month == hiringDate.Month && currentDate.Day < hiringDate.Day))
    {
        experience--;
    }

    if (experience < 0)
    {
        experience = 0;
    }

    return experience;
}

    public void ShowInfo()
    {
        Console.WriteLine($"{name} has {Experience()} year(s) of experience.");
    }
}

public class Developer : Employee
{
    private string programmingLanguage;

    public Developer(string name, DateTime hiringDate, string programmingLanguage) : base(name, hiringDate)
    {
        this.programmingLanguage = programmingLanguage;
    }

    public new void ShowInfo()
    {
        base.ShowInfo();
        Console.WriteLine($"{name} is a {programmingLanguage} programmer.");
    }
}

public class Tester : Employee
{
    private bool isAutomation;

    public Tester(string name, DateTime hiringDate, bool isAutomation) : base(name, hiringDate)
    {
        this.isAutomation = isAutomation;
    }

    public new void ShowInfo()
    {
        base.ShowInfo();
        if (isAutomation)
        {
            Console.WriteLine($"{name} is an automated tester.");
        }
        else
        {
            Console.WriteLine($"{name} is a manual tester.");
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter developer's name:");
        string devName = Console.ReadLine();

        Console.WriteLine("Enter developer's hiring date (YYYY-MM-DD):");
        DateTime devHiringDate = DateTime.Parse(Console.ReadLine());

        Console.WriteLine("Enter developer's programming language:");
        string devLanguage = Console.ReadLine();

        Developer dev = new Developer(devName, devHiringDate, devLanguage);

        Console.WriteLine("\nEnter tester's name:");
        string testerName = Console.ReadLine();

        Console.WriteLine("Enter tester's hiring date (YYYY-MM-DD):");
        DateTime testerHiringDate = DateTime.Parse(Console.ReadLine());

        Console.WriteLine("Is the tester automated? (true/false):");
        bool isTesterAutomated = bool.Parse(Console.ReadLine());

        Tester tester = new Tester(testerName, testerHiringDate, isTesterAutomated);

        Console.WriteLine("\nDeveloper Information:");
        dev.ShowInfo();

        Console.WriteLine("\nTester Information:");
        tester.ShowInfo();
    }
}
