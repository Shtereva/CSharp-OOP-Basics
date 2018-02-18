using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class FamilyTreeBuilder
{
    private List<Person> familyTree;
    private Person mainPerson;

    public FamilyTreeBuilder(string mainPersonInput)
    {
        this.familyTree = new List<Person>();
        this.mainPerson = Person.CreatePerson(mainPersonInput);
        this.familyTree.Add(mainPerson);
    }

    public void ParseInput(string command)
    {
        string[] tokens = command.Split(" - ");
        if (tokens.Length > 1)
        {
            string parentInput = tokens[0];
            string childInput = tokens[1];

            SetParentChildRelation(parentInput, childInput);
        }
        else
        {
            tokens = tokens[0].Split();
            string name = $"{tokens[0]} {tokens[1]}";
            string birthday = tokens[2];

            SetFullInfo(name, birthday);
        }
    }

    private void SetFullInfo(string name, string birthday)
    {
        var person = this.familyTree.FirstOrDefault(p => p.Name == name || p.Birthday == birthday);
        if (person == null)
        {
            person = new Person();
            this.familyTree.Add(person);
        }
        person.Name = name;
        person.Birthday = birthday;

        CheckForDublicate(person);
    }

    private void CheckForDublicate(Person person)
    {
        string name = person.Name;
        string birthday = person.Birthday;

        Person dublicate = this.familyTree
                    .Where(p => p.Name == name || p.Birthday == birthday)
                    .Skip(1)
                    .FirstOrDefault();

        if (dublicate != null)
        {
            RemoveDublicate(person, dublicate);
        }
    }

    private void RemoveDublicate(Person person, Person dublicate)
    {
        this.familyTree.Remove(dublicate);
        person.Parents.AddRange(dublicate.Parents);
        person.Parents = person.Parents.Distinct().ToList();

        foreach (var parent in dublicate.Parents)
        {
            ReplaceDublicate(parent.Children, person, dublicate);
        }

        person.Children.AddRange(dublicate.Children);
        person.Children = person.Children.Distinct().ToList();

        foreach (var child in dublicate.Children)
        {
            ReplaceDublicate(child.Parents, person, dublicate);
        }
    }

    private void SetParentChildRelation(string parentInput, string childInput)
    {
        Person currentPerson = this.familyTree.FirstOrDefault(p => p.Birthday == parentInput || p.Name == parentInput);

        if (currentPerson == null)
        {
            currentPerson = Person.CreatePerson(parentInput);

            this.familyTree.Add(currentPerson);
        }

        SetChild(currentPerson, childInput);
    }

    private void ReplaceDublicate(List<Person> people, Person person, Person dublicate)
    {
        int copyPersonIndex = people.IndexOf(dublicate);
        if (copyPersonIndex > -1)
        {
            people[copyPersonIndex] = person;
        }
        else
        {
            people.Add(person);
        }
    }
    private void SetChild(Person parent, string childInput)
    {
        var child = this.familyTree.FirstOrDefault(c => c.Name == childInput || c.Birthday == childInput);

        if (child == null)
        {
            child = Person.CreatePerson(childInput);

            this.familyTree.Add(child);
        }

        parent.Children.Add(child);
        child.Parents.Add(parent);
    }

    public override string ToString()
    {
        var result = new StringBuilder();

        result.AppendLine(this.mainPerson.ToString());
        result.AppendLine("Parents:");

        foreach (var parent in this.mainPerson.Parents)
        {
            result.AppendLine(parent.ToString());
        }

        result.AppendLine("Children:");

        foreach (var child in this.mainPerson.Children)
        {
            result.AppendLine(child.ToString());
        }

        return result.ToString();
    }
}
