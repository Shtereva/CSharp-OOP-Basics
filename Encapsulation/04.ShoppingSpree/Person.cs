using System;
using System.Collections.Generic;

public class Person
{
    private string name;
    private decimal money;
    private List<Product> products;

    public Person(string name, decimal money)
    {
        this.Name = name;
        this.Money = money;
        this.products = new List<Product>();
    }

    public string Name
    {
        get => this.name;
        set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Name cannot be empty");
            }
            this.name = value;
        }
    }

    public decimal Money
    {
        get => this.money;
        set
        {
            if (value < 0)
            {
                throw new ArgumentException("Money cannot be negative");
            }
            this.money = value;
        }
    }

    public bool CheckIfPersonCanAffortProduct(decimal cost)
    {
        return this.Money - cost >= 0;
    }
    public void AddProduct(Product product)
    {
        this.money -= product.Cost;
        this.products.Add(product);
    }

    public override string ToString()
    {
        var products = this.products.Count == 0 ? "Nothing bought" : string.Join(", ", this.products);
        return $"{this.Name} - {products}";
    }
}
