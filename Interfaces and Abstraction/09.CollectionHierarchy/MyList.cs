using System.Collections.Generic;

public class MyList<T> : IMyList
{
    public List<string> collection { get; set; }

    public MyList()
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
        string item = this.collection[0];
        this.collection.RemoveAt(0);

        return item;
    }

    public int Used()
    {
        return collection.Count;
    }
}
