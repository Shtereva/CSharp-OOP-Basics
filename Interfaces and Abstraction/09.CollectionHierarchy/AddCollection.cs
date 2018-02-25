using System.Collections.Generic;

public class AddCollection<T> : IAddCollection
{
    public List<string> collection { get; set; }

    public AddCollection()
    {
        this.collection = new List<string>(100);
    }
    public int Add(string item)
    {
        collection.Add(item);
        return collection.Count - 1;
    }
}
