using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public class LoginManager
{
    private Dictionary<string, User> users = new Dictionary<string, User>();
    private const string filePath = "C:\\Users\\Flavius\\source\\repos\\Magazin\\users.txt";

    public LoginManager()
    {
        LoadUsers();
    }

    private void LoadUsers()
    {
        if (File.Exists(filePath))
        {
            var lines = File.ReadAllLines(filePath);
            foreach (var line in lines)
            {
                var user = User.FromString(line);
                users[user.Username] = user;
            }
        }
    }

    private void SaveUsers()
    {
        using (StreamWriter sw = new StreamWriter(filePath, false))
        {
            foreach (var user in users.Values)
            {
                sw.WriteLine(user.ToString());
            }
        }
    }

    public bool AddUser(string username, string password, string firstName, string lastName, string address, string email, UserType userType)
    {
        if (!users.ContainsKey(username))
        {
            if (userType == UserType.Client)
            {
                users[username] = new Client(username, password, firstName, lastName, address, email);
            }
            else if (userType == UserType.Employee)
            {
                users[username] = new Employee(username, password, firstName, lastName, address, email);
            }
            SaveUsers();  
            return true;
        }
        else
        {
            Console.WriteLine("Utilizatorul deja exista.");
            return false;
        }
    }

    public bool Authenticate(string username, string password, out User user)
    {
        user = null;
        if (users.ContainsKey(username) && users[username].Password == password)
        {
            user = users[username];
            return true;
        }
        return false;
    }
}
