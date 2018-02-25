public abstract class SoldierGeneral : ISoldier
{
    public string Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }

    protected SoldierGeneral(string id, string firstName, string lastName)
    {
       this.Id = id;
       this.FirstName = firstName;
       this.LastName = lastName;
    }

    public override string ToString()
    {
        return $"Name: {this.FirstName} {this.LastName} Id: {this.Id}";
    }
}
