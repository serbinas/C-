using System;

public class MyAccessModifiers
{
    private int birthYear;
    protected internal string personalInfo;
    internal string IdNumber;

    public MyAccessModifiers(int birthYear, string idNumber, string personalInfo)
    {
        this.birthYear = birthYear;
        this.IdNumber = idNumber;
        this.personalInfo = personalInfo;
    }

    public int Age
    {
        get
        {
            int currentYear = DateTime.Now.Year;
            return currentYear - birthYear;
        }
    }

    public static byte averageMiddleAge = 50;

    internal string Name { get; set; }

    private string nickName; 

    public string NickName
    {
        get { return nickName; }
        internal set { nickName = value; }
    }

    protected internal void HasLivedHalfOfLife(int age)
    {
        if (age >= 50)
        {
            Console.WriteLine("Has lived half of life");
        }
        else
        {
            Console.WriteLine("Has not lived half of life");
        }
    }

       
    public static bool operator ==(MyAccessModifiers obj1, MyAccessModifiers obj2)
    {
        if (ReferenceEquals(obj1, obj2))
        {
            return true;
        }

        if ((obj1 is null) || (obj2 is null))
        {
            return false;
        }

        return obj1.Name == obj2.Name && obj1.Age == obj2.Age && obj1.personalInfo == obj2.personalInfo;
    }

    public static bool operator !=(MyAccessModifiers obj1, MyAccessModifiers obj2)
    {
        return !(obj1 == obj2);
    }

  public class Person : MyAccessModifiers
{
    public Person(int birthYear, string idNumber, string personalInfo) : base(birthYear, idNumber, personalInfo)
    {
    }

    public new int Age
    {
        get
        {
            int currentYear = DateTime.Now.Year;
            return currentYear - birthYear;
        }
    }
}
}

 class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter birth year:");
        int birthYear = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Enter ID number:");
        string idNumber = Console.ReadLine();

        Console.WriteLine("Enter personal info:");
        string personalInfo = Console.ReadLine();

        Console.WriteLine("Enter name:");
        string name = Console.ReadLine();

        Console.WriteLine("Enter nickname:");
        string nickname = Console.ReadLine();

        MyAccessModifiers obj = new MyAccessModifiers(birthYear, idNumber, personalInfo);
        int age = obj.Age;
        obj.Name = name;
        obj.NickName = nickname;


        Console.WriteLine("\nEnter birth year for Person:");
        int personBirthYear = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Enter ID number for Person:");
        string personIdNumber = Console.ReadLine();

        Console.WriteLine("Enter personal info for Person:");
        string personPersonalInfo = Console.ReadLine();

         Console.WriteLine("Enter name for Person:");
        string personName = Console.ReadLine();

        Console.WriteLine("Enter nickname for Person:");
        string personNickname = Console.ReadLine();

        MyAccessModifiers.Person person = new MyAccessModifiers.Person(birthYear, idNumber, personalInfo);
        person.Name = personName;
        person.NickName = personNickname; 



        Console.WriteLine("\n\n--- Base Object ---");
        Console.WriteLine($"IdNumber: {obj.IdNumber}");
        Console.WriteLine($"Age: {age}");
        Console.WriteLine($"Name: {obj.Name}");
        Console.WriteLine($"NickName: {obj.NickName}");
        obj.HasLivedHalfOfLife(age);

        

        Console.WriteLine("\n--- Person Object ---");
        Console.WriteLine($"Personal Info of the person: {person.personalInfo}");
        Console.WriteLine($"IdNumber: {person.IdNumber}");
        Console.WriteLine($"Age: {person.Age}");
        Console.WriteLine($"Name: {person.Name}");
        Console.WriteLine($"NickName: {person.NickName}");
        person.HasLivedHalfOfLife(person.Age);
        
        if (obj == person)
        {
            Console.WriteLine("Objects are equal.");
        }
        else
        {
            Console.WriteLine("Objects are not equal.");
        }
    }
    }



