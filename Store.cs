using System;
using System.Collections.Generic;

public class Store
{
    private List<Product> products = new List<Product>();
    private List<Order> orders = new List<Order>();
    private LoginManager loginManager = new LoginManager();

    public Store()
    {
        products.Add(new Product("Tricou", 19.99, "M"));
        products.Add(new Product("Blugi", 49.99, "32"));
        products.Add(new Product("Geacă", 99.99, "XL"));
        products.Add(new Product("Pantaloni scurti", 14.99, "36"));
        products.Add(new Product("Trening", 69.99, "L"));
        products.Add(new Product("Sapca", 9.99, "S"));
        products.Add(new Product("Bluza", 19.99, "M"));
        products.Add(new Product("Hoodie", 59.99, "L"));
    }

    public void Run()
    {
        User currentUser = null;

        while (currentUser == null)
        {
            Console.WriteLine("1. Login");
            Console.WriteLine("2. Inregistrare");
            Console.WriteLine("3. Iesire");
            Console.Write("Selectati o optiune: ");
            string option = Console.ReadLine();
            Console.WriteLine(" ");

            if (option == "1")
            {
                Console.Write("Introduceti numele de utilizator: ");
                string username = Console.ReadLine();
                Console.Write("Introduceti parola: ");
                string password = Console.ReadLine();

                if (loginManager.Authenticate(username, password, out currentUser))
                {
                    Console.WriteLine("Autentificare reusita!");
                    break;
                }
                else
                {
                    Console.WriteLine("Nume de utilizator sau parola incorecta.");
                }
            }
            else if (option == "2")
            {
                Console.Write("Introduceti un nume de utilizator: ");
                string username = Console.ReadLine();
                Console.Write("Introduceti o parola: ");
                string password = Console.ReadLine();
                Console.Write("Introduceti prenumele: ");
                string firstName = Console.ReadLine();
                Console.Write("Introduceti numele: ");
                string lastName = Console.ReadLine();
                Console.Write("Introduceti adresa: ");
                string address = Console.ReadLine();
                Console.Write("Introduceti email: ");
                string email = Console.ReadLine();
                Console.WriteLine("Tip utilizator: 1. Client, 2. Angajat");
                string userTypeInput = Console.ReadLine();

                UserType userType;
                if (userTypeInput == "1")
                {
                    userType = UserType.Client;
                }
                else if (userTypeInput == "2")
                {
                    userType = UserType.Employee;
                }
                else
                {
                    Console.WriteLine("Optiune invalida. Va rugam sa incercati din nou.");
                    continue;
                }

                if (loginManager.AddUser(username, password, firstName, lastName, address, email, userType))
                {
                    Console.WriteLine("Inregistrare reusita!");
                }
                else
                {
                    Console.WriteLine("Inregistrarea a esuat. Utilizatorul exista deja.");
                }
            }
            else if (option == "3")
            {
                return;
            }
            else
            {
                Console.WriteLine("Optiune invalida. Va rugam sa incercati din nou.");
            }

            Console.WriteLine();
        }

        if (currentUser is Client client)
        {
            RunClient(client);
        }
        else if (currentUser is Employee employee)
        {
            RunEmployee(employee);
        }
    }

    private void RunClient(Client client)
    {
        while (true)
        {
            Console.WriteLine("1. Vizualizeaza produse");
            Console.WriteLine("2. Adauga produs in cos");
            Console.WriteLine("3. Vizualizeaza cos");
            Console.WriteLine("4. Plaseaza comanda");
            Console.WriteLine("5. Iesire");
            Console.Write("Selectati o optiune: ");
            string option = Console.ReadLine();

            if (option == "1")
            {
                foreach (var product in products)
                {
                    Console.WriteLine(product);
                }
            }
            else if (option == "2")
            {
                Console.Write("Introduceti numele produsului: ");
                string productName = Console.ReadLine();
                Product product = products.Find(p => p.Name.Equals(productName, StringComparison.OrdinalIgnoreCase));
                if (product != null)
                {
                    Console.Write("Introduceti cantitatea: ");
                    if (int.TryParse(Console.ReadLine(), out int quantity))
                    {
                        Console.Write("Introduceti marimea: ");
                        string productSize = Console.ReadLine();
                        Product product1 = products.Find(p => p.Size.Equals(productSize, StringComparison.OrdinalIgnoreCase));
                        if (product1 != null)
                        {
                            client.AddToCart(product, quantity);
                            Console.WriteLine("Produs adaugat in cos.");
                        }
                        else
                        {
                            Console.WriteLine("Marimea nu este in stoc.");
                        }
                       
                    }
                    else
                    {
                        Console.WriteLine("Cantitate invalida.");
                    }
                    
                }
                else
                {
                    Console.WriteLine("Produsul nu exista.");
                }
            }
            else if (option == "3")
            {
                client.ViewCart();
            }
            else if (option == "4")
            {
                var order = new Order(client.Cart.GetItems());
                orders.Add(order);
                client.Checkout();
                Console.WriteLine("Comanda a fost plasata.");
            }
            else if (option == "5")
            {
                break;
            }
            else
            {
                Console.WriteLine("Optiune invalida. Va rugam sa incercati din nou.");
            }

            Console.WriteLine();
        }
    }

    private void RunEmployee(Employee employee)
    {
        while (true)
        {
            Console.WriteLine("1. Vizualizeaza comenzi neprocesate");
            Console.WriteLine("2. Proceseaza comanda");
            Console.WriteLine("3. Iesire");
            Console.Write("Selectati o optiune: ");
            string option = Console.ReadLine();

            if (option == "1")
            {
                bool unprocessedOrdersExist = false;
                foreach (var order in orders)
                {
                    if (!order.IsProcessed)
                    {
                        order.DisplayOrder();
                        unprocessedOrdersExist = true;
                    }
                }
                if (!unprocessedOrdersExist)
                {
                    Console.WriteLine("Nu exista comenzi neprocesate.");
                }
            }
            else if (option == "2")
            {
                Console.Write("Introduceti ID-ul comenzii: ");
                if (int.TryParse(Console.ReadLine(), out int orderId))
                {
                    Order order = orders.Find(o => o.OrderId == orderId);
                    if (order != null && !order.IsProcessed)
                    {
                        employee.ProcessOrder(order);
                        order.ProcessOrder();
                    }
                    else
                    {
                        Console.WriteLine("Comanda nu exista sau a fost deja procesata.");
                    }
                }
                else
                {
                    Console.WriteLine("ID comanda invalid.");
                }
            }
            else if (option == "3")
            {
                break;
            }
            else
            {
                Console.WriteLine("Optiune invalida. Va rugam sa incercati din nou.");
            }

            Console.WriteLine();
        }
    }
}
