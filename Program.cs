using System;

delegate double CalcDelegate(double a, double b, char sign);

class CalcProgram
{
    static double Cale(double a, double b, char sign)
    {
        switch (sign)
        {
            case '+':
                return a + b;
            case '-':
                return a - b;
            case '*':
                return a * b;
            case '/':
                if (b == 0)
                {
                    return 0; 
                }
                return a / b;
            default:
                Console.WriteLine("Error: Invalid operation.");
                return 0;
        }
    }

    public static CalcDelegate funcCalc = new CalcDelegate(Cale);
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter first number:");
        double a = Convert.ToDouble(Console.ReadLine());

        Console.WriteLine("Enter second number:");
        double b = Convert.ToDouble(Console.ReadLine());

        Console.WriteLine("Results:");
        Console.WriteLine($"Addition: {CalcProgram.funcCalc(a, b, '+')}");
        Console.WriteLine($"Subtraction: {CalcProgram.funcCalc(a, b, '-')}");
        Console.WriteLine($"Multiplication: {CalcProgram.funcCalc(a, b, '*')}");
        Console.WriteLine($"Division: {CalcProgram.funcCalc(a, b, '/')}");
    }
}
