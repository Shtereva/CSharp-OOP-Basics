public class Citizen : IHabitat
{
    public string Id { get; set; }
    private string name;
    private int age;

    public Citizen(string name, int age, string id)
    {
        this.Id = id;
        this.name = name;
        this.age = age;
    }
}
