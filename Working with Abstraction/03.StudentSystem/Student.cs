using System;

public class Student
{
    private string name;
    private int age;
    private double grade;

    public Student(string name, int age, double grade)
    {
        this.name = name;
        this.age = age;
        this.grade = grade;
    }

    public override string ToString()
    {
        string comment = String.Empty;
        if (this.grade >= 5)
        {
            comment = "Excellent student.";
        }
        else if (this.grade < 5 && this.grade >= 3.5)
        {
            comment = "Average student.";
        }
        else
        {
            comment = "Very nice person.";
        }

        return $"{this.name} is {this.age} years old. {comment}";
    }
}
