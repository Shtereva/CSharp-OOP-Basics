using System;
using System.Collections.Generic;
using System.Linq;
public class StartUp
{
    public static new List<Person> people;
    public static void Main()
    {
        string input = String.Empty;
        people = new List<Person>();

        while ((input = Console.ReadLine()) != "End")
        {
            var personInfo = input.Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            string personName = personInfo[0];

            AddPersonInfo(personInfo, personName);
        }

        string name = Console.ReadLine();
        Console.WriteLine(people.Find(p => p.Name == name));
    }

    private static void AddPersonInfo(string[] personInfo, string personName)
    {
        var currentPerson = people.SingleOrDefault(p => p.Name == personName);

        switch (personInfo[1])
        {
            case "company":
                string name = personInfo[2];
                string department = personInfo[3];
                decimal salary = decimal.Parse(personInfo[4]);

                if (currentPerson == null)
                {
                    people.Add(new Person(personName, new Company(name, department, salary)));
                    break;
                }

                currentPerson.Company = new Company(name, department, salary);
                break;
            case "pokemon":
                string pokemonName = personInfo[2];
                string type = personInfo[3];

                if (currentPerson == null)
                {
                    var person = new Person(personName);
                    person.Pokemons.Add(new Pokemon(pokemonName, type));
                    people.Add(person);
                    break;
                }

                currentPerson.Pokemons.Add(new Pokemon(pokemonName, type));
                break;
            case "parents":
                string parentName = personInfo[2];
                string birthday = personInfo[3];

                if (currentPerson == null)
                {
                    var person = new Person(personName);
                    person.Parents.Add(new Parent(parentName, birthday));
                    people.Add(person);
                    break;
                }

                currentPerson.Parents.Add(new Parent(parentName, birthday));
                break;
            case "children":
                string childName = personInfo[2];
                string childBirthday = personInfo[3];

                if (currentPerson == null)
                {
                    var person = new Person(personName);
                    person.Children.Add(new Children(childName, childBirthday));
                    people.Add(person);
                    break;
                }

                currentPerson.Children.Add(new Children(childName, childBirthday));
                break;
            case "car":
                string model = personInfo[2];
                int speed = int.Parse(personInfo[3]);

                if (currentPerson == null)
                {
                    people.Add(new Person(personName, new Car(model, speed)));
                    break;
                }

                currentPerson.Car = new Car(model, speed);
                break;
        }
    }
}
