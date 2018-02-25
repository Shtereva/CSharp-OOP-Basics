public class Citizen : IHabitat, IBirthdate
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string Birthdate { get; set; }

    private int age;

    public Citizen(string name, int age, string id, string birthdate)
    {
        this.Id = id;
        this.Birthdate = birthdate;
        this.Name = name;
        this.age = age;
    }

}
