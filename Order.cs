public class Order
{
    private static int idCounter = 1;
    public int OrderId { get; }
    private Dictionary<Product, int> products;
    public bool IsProcessed { get; private set; }

    public Order(Dictionary<Product, int> products)
    {
        OrderId = idCounter++;
        this.products = products;
        IsProcessed = false;
    }

    public void Process()
    {
        IsProcessed = true;
    }

    public void DisplayOrder()
    {
        Console.WriteLine($"Order ID: {OrderId}");
        double total = 0;
        foreach (var item in products)
        {
            Console.WriteLine($"{item.Key.Name} x {item.Value} = ${item.Key.Price * item.Value}");
            total += item.Key.Price * item.Value;
        }
        Console.WriteLine($"Total: ${total}");
        Console.WriteLine($"Status: {(IsProcessed ? "Processed" : "Pending")}");
    }
}