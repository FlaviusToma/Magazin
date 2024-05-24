public class Employee : User
{
    public Employee(string username, string password, string firstName, string lastName, string address, string email)
        : base(username, password, firstName, lastName, address, email, UserType.Employee)
    {
    }

    public void ProcessOrder(Order order)
    {
        order.ProcessOrder();
        Console.WriteLine($"Order {order.OrderId} processed.");
    }
}
