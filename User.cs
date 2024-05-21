using System;

public enum UserType
{
    Client,
    Employee
}

public class User
{
    public string Username { get; set; }
    public string Password { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Address { get; set; }
    public string Email { get; set; }
    public UserType UserType { get; set; }

    public User(string username, string password, string firstName, string lastName, string address, string email, UserType userType)
    {
        Username = username;
        Password = password;
        FirstName = firstName;
        LastName = lastName;
        Address = address;
        Email = email;
        UserType = userType;
    }


    public override string ToString()
    {
        return $"{Username},{Password},{FirstName},{LastName},{Address},{Email},{UserType}";
    }


    public static User FromString(string userData)
    {
        var data = userData.Split(',');
        var userType = (UserType)Enum.Parse(typeof(UserType), data[6]);
        if (userType == UserType.Client)
        {
            return new Client(data[0], data[1], data[2], data[3], data[4], data[5]);
        }
        else if (userType == UserType.Employee)
        {
            return new Employee(data[0], data[1], data[2], data[3], data[4], data[5]);
        }
        return null;
    }
}