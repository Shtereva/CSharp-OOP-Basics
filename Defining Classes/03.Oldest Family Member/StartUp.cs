using System;
    public class StartUp
    {
        public static void Main()
        {
            int lines = int.Parse(Console.ReadLine());
            var family = new Family();

            for (int i = 0; i < lines; i++)
            {
                var input = Console.ReadLine().Split();

                string name = input[0];
                int age = int.Parse(input[1]);

                var person = new Person(name, age);

                family.AddMember(person);
            }

            var oldestMember = family.GetOldestMember();

            Console.WriteLine($"{oldestMember.Name} {oldestMember.Age}");
        }
    }

