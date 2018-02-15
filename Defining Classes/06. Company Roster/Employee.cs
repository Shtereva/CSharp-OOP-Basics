public class Employee
{
    private string name;
    private decimal salary;
    private string position;
    private string department;
    private string email;
    private int age;

    public Employee(string name, decimal salary, string position, string department)
    {
        this.name = name;
        this.salary = salary;
        this.position = position;
        this.department = department;
        this.email = "n/a";
        this.age = -1;
    }

    public Employee(string name, decimal salary, string position, string department, string email) : this(name, salary, position, department)
    {
        this.email = email;
    }

    public Employee(string name, decimal salary, string position, string department, int age) : this(name, salary, position, department)
    {
        this.age = age;
    }

    public Employee(string name, decimal salary, string position, string department, string email, int age) : this(name, salary, position, department, email)
    {
        this.age = age;
    }

    public decimal Salary => this.salary;

    public override string ToString()
    {
        return $"{this.name} {this.Salary:f2} {this.email} {this.age}";
    }
}

