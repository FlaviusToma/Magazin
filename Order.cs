using System;
using System.Collections.Generic;

public class Order
{
    private static int nextOrderId = 1;
    public int OrderId { get; private set; }
    public List<(Product, int)> Items { get; private set; }
    public bool IsProcessed { get; private set; }

    public Order(List<(Product, int)> items)
    {
        OrderId = nextOrderId++;
        Items = new List<(Product, int)>(items);
        IsProcessed = false;
    }

    public void DisplayOrder()
    {
        Console.WriteLine($"Comanda ID: {OrderId}");
        foreach (var item in Items)
        {
            Console.WriteLine($"{item.Item1} x {item.Item2}");
        }
    }

    public void ProcessOrder()
    {
        IsProcessed = true;
        Console.WriteLine($"Comanda {OrderId} a fost procesată.");
    }
}
