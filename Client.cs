public class Client : User
{
    public Cart Cart { get; private set; }

    public Client(string username, string password, string firstName, string lastName, string address, string email)
        : base(username, password, firstName, lastName, address, email, UserType.Client)
    {
        Cart = new Cart();
    }

    public void AddToCart(Product product, int quantity)
    {
        Cart.AddProduct(product, quantity);
    }

    public void ViewCart()
    {
        Cart.DisplayCart();
    }

    public void Checkout()
    {
        Console.WriteLine("Finalizarea comenzii:");
        Cart.DisplayCart();
        double total = Cart.GetTotal();
        Console.WriteLine($"Total de plată: {total:C}");
        Cart.Clear();
        Console.WriteLine("Comanda a fost procesată și coșul a fost golit.");
    }
}
