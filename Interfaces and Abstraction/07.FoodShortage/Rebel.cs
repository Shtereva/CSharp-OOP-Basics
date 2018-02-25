public class Rebel : IBuyer 
{
    public string Name { get; set; }
    public int Age { get; set; }

    private string group;
    public int Food { get; set; }

    public Rebel(string name, int age, string group)
    {
        this.Name = name;
        this.Age = age;
        this.group = group;
        this.Food = 0;
    }


    public void BuyFood()
    {
        this.Food += 5;
    }

}
