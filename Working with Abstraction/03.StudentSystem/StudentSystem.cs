using System;
using System.Collections.Generic;

public class StudentSystem
{
    private Dictionary<string, Student> students;

    public StudentSystem()
    {
        this.students = new Dictionary<string, Student>();
    }

    public void ParseCommand()
    {
        var args = Console.ReadLine().Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

        string command = args[0];
        string name = args.Length > 1 ? args[1] : String.Empty;
        int age = args.Length > 2 ? int.Parse(args[2]) : 0;
        double grade = args.Length > 2 ? double.Parse(args[3]) : 0;

        switch (command)
        {
            case "Create":
                Create(name, age, grade);
                break;
            case "Show":
                Show(name);
                break;
            case "Exit":
                Environment.Exit(0);
                break;
        }
    }

    private void Show(string name)
    {
        if (this.students.ContainsKey(name))
        {
            Console.WriteLine(this.students[name]);
        }
    }

    private void Create(string name, int age, double grade)
    {
        if (!this.students.ContainsKey(name))
        {
            this.students[name] = new Student(name, age, grade);
        }
    }
}
