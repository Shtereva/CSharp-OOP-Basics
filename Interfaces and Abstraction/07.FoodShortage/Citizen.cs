public class Citizen : IHabitat, IBirthdate, IBuyer
{
    public string Id { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }

    public string Birthdate { get; set; }
    public int Food { get; set; }

    public Citizen(string name, int age, string id, string birthdate)
    {
        this.Id = id;
        this.Birthdate = birthdate;
        this.Name = name;
        this.Age = age;
        this.Food = 0;
    }

    public void BuyFood()
    {
        this.Food += 10;
    }

}
