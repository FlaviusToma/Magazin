public class Product
{
    public string Name { get; set; }
    public double Price { get; set; }
    public string Size { get; set; }

    public Product(string name, double price, string size)
    {
        Name = name;
        Price = price;
        Size = size;
    }

    public override string ToString()
    {
        return $"{Name} (Size: {Size}), Price: {Price:C}";
    }
}
