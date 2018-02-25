using System.Collections.Generic;

public class AddRemoveCollection<T> : IAddRemoveCollection
{
    public List<string> collection { get; set; }

    public AddRemoveCollection()
    {
        this.collection = new List<string>(100);
    }
    public int Add(string item)
    {
        collection.Insert(0, item);
        return 0;
    }

    public string Remove()
    {
        string item = this.collection[this.collection.Count - 1];
        this.collection.RemoveAt(this.collection.Count - 1);

        return item;
    }
}
