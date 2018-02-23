using System;

public static class Factory
{
    public static Animal CreateInstance(string input)
    {
        var animalInfo = Console.ReadLine().Split();
        if (animalInfo == null)
        {
            throw new ArgumentException("Invalid input!");
        }
        string name = animalInfo[0];
        string age = animalInfo[1];
        string gender = animalInfo[2];

        if (input.Equals("Cat", StringComparison.InvariantCultureIgnoreCase))
        {
            return new Cat(name, age, gender);
        }
        if (input.Equals("Dog", StringComparison.InvariantCultureIgnoreCase))
        {
            return new Dog(name, age, gender);
        }
        if (input.Equals("Frog", StringComparison.InvariantCultureIgnoreCase))
        {
            return new Frog(name, age, gender);
        }
        if (input.Equals("Kitten", StringComparison.InvariantCultureIgnoreCase))
        {
            return new Kitten(name, age, gender);
        }

        if (input.Equals("Tomcat", StringComparison.InvariantCultureIgnoreCase))
        {
            return new Tomcat(name, age, gender);
        }

        return null;
    }
}
