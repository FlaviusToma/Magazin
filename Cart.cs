public class Cart
{
    private Dictionary<Product, int> products = new Dictionary<Product, int>();

    public void AddProduct(Product product, int quantity)
    {
        if (products.ContainsKey(product))
        {
            products[product] += quantity;
        }
        else
        {
            products[product] = quantity;
        }
    }

    public void DisplayCart()
    {
        Console.WriteLine("Cart:");
        double total = 0;
        foreach (var item in products)
        {
            Console.WriteLine($"{item.Key.Name} x {item.Value} = ${item.Key.Price * item.Value}");
            total += item.Key.Price * item.Value;
        }
        Console.WriteLine($"Total: ${total}");
    }

    public Order Checkout()
    {
        return new Order(new Dictionary<Product, int>(products));
    }
}
