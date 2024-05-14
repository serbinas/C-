using System;
using System.Collections.Generic;
using System.Linq;

public interface ISwimmable
{
    void Swim()
    {
        Console.WriteLine("I can swim!");
    }
}
public interface IFlyable
{
    int MaxHeight { get; }
    void Fly()
    {
        Console.WriteLine($"I can fly at {MaxHeight} meters height!");
    }
}
public interface IRunnable
{
    int MaxSpeed { get; }
    void Run()
    {
        Console.WriteLine($"I can run up to {MaxSpeed} kilometers per hour!");
    }
}
public interface IAnimal
{
    int LifeDuration { get; }
    void Voice()
    {
        Console.WriteLine("No voice!");
    }
    void ShowInfo()
    {
        Console.WriteLine($"I am a {this.GetType().Name} and I live approximately {LifeDuration} years.");
    }
}
public class Cat : IAnimal, IRunnable
{
    public int MaxSpeed { get; } = 20;
    public int LifeDuration { get; } = 12;

    public void Voice()
    {
        Console.WriteLine("Meow!");
    }
}
public class Eagle : IAnimal, IFlyable
{
    public int MaxHeight { get; } = 3000;
    public int LifeDuration { get; } = 25;
}
public class Shark : IAnimal, ISwimmable
{
    public int LifeDuration { get; } = 40;
}
public class Product
{
    public string Name { get; set; } = "";
    public decimal Price { get; set; }
    public string Category { get; set; } = "";
}

class Program
{
    public static void TotalPrice(ILookup<string, Product> lookup)
    {
        foreach (var group in lookup)
        {
            decimal totalPriceForCategory = group.Sum(prod => prod.Price);
            Console.WriteLine($"{group.Key}:");
            foreach (var product in group)
            {
                Console.WriteLine($"{product.Name} {product.Price}");
            }
            Console.WriteLine($"Total Price for {group.Key}: {totalPriceForCategory}");
        }
    }

    static void Main(string[] args)
    {
        var products = new List<Product>();
        products.Add(new Product { Name = "SmartTV", Price = 400, Category = "Electronics" });
        products.Add(new Product { Name = "Lenovo ThinkPad", Price = 1000, Category = "Electronics" });
        products.Add(new Product { Name = "Iphone", Price = 700, Category = "Electronics" });
        products.Add(new Product { Name = "Orange", Price = 2, Category = "Fruits" });
        products.Add(new Product { Name = "Banana", Price = 3, Category = "Fruits" });
        ILookup<string, Product> lookup = products.ToLookup(prod => prod.Category);
        TotalPrice(lookup);
        Console.ReadKey();
    }
}
