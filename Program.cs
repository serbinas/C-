using System;

public class ParallelUtils<T, TR>
{
    private Func<T, T, TR> operation;
    private T operand1;
    private T operand2;

    public TR Result { get; private set; }

    public ParallelUtils(Func<T, T, TR> operation, T operand1, T operand2)
    {
        this.operation = operation;
        this.operand1 = operand1;
        this.operand2 = operand2;
    }

    public void StartEvaluation()
    {
        Task.Run(() => ExecuteOperation());
    }

    public void Evaluate()
    {
        ExecuteOperation().Wait();
    }

    private async Task ExecuteOperation()
    {
        Result = await Task.Run(() => operation(operand1, operand2));
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter 1 operand:");
        int operand1 = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Enter 2 operand:");
        int operand2 = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Enter the operation (+ for addition, - for subtraction, * for multiplication, / for division):");
        string operationSymbol = Console.ReadLine();

        Func<int, int, int> operation = GetOperationFunction(operationSymbol);

        if (operation == null)
        {
            Console.WriteLine("Invalid operation symbol.");
            return;
        }

        ParallelUtils<int, int> utils = new ParallelUtils<int, int>(operation, operand1, operand2);

        utils.StartEvaluation();

        utils.Evaluate();

        Console.WriteLine("Result: " + utils.Result); 
    }

    static Func<int, int, int> GetOperationFunction(string symbol)
    {
        switch (symbol)
        {
            case "+":
                return (a, b) => a + b;
            case "-":
                return (a, b) => a - b;
            case "*":
                return (a, b) => a * b;
            case "/":
                return (a, b) => b != 0 ? a / b : throw new ArgumentException("Division by zero");
            default:
                return null;
        }
    }
}
