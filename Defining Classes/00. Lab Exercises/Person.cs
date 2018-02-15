using System.Collections.Generic;
using System.Linq;

public class Person
{
    private string name;
    private int age;
    private List<BankAccount> accounts;

    public Person(string name, int age)
    {
        this.Age = age;
        this.Name = name;
        this.Accounts = new List<BankAccount>();
    }

    public Person(string name, int age,  List<BankAccount> accounts) : this(name, age)
    {
        this.Accounts = accounts;
    }

    public int Age
    {
        get => this.age;
        set { this.age = value; }
    }

    public string Name
    {
        get => this.name;
        set { this.name = value; }
    }

    public List<BankAccount> Accounts
    {
        get => this.accounts;
        set { this.accounts = value; }
    }

    public  decimal GetBalance()
    {
        return this.Accounts.Sum(a => a.Balance);
    }
}
