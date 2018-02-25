using System.Collections.Generic;

public interface IAddCollection
{
    List<string> collection { get; set; }
    int Add(string item);
}
