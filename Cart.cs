using System;
using System.Collections.Generic;
using System.Linq;

public class Cart
{
    private List<(Product, int)> items = new List<(Product, int)>();

    public void AddProduct(Product product, int quantity)
    {
        items.Add((product, quantity));
    }

    public void DisplayCart()
    {
        foreach (var item in items)
        {
            Console.WriteLine($"{item.Item1} x {item.Item2}");
        }
        Console.WriteLine($"Total: {GetTotal():C}");
    }

    public double GetTotal()
    {
        return items.Sum(item => item.Item1.Price * item.Item2);
    }

    public void Clear()
    {
        items.Clear();
    }

    public List<(Product, int)> GetItems()
    {
        return items;
    }
}
