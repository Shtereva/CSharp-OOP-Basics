public class Robot : IHabitat
{
    public string Id { get; set; }

    private string model;

    public Robot(string model, string id)
    {
        this.Id = id;
        this.model = model;
    }
}
