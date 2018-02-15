    public class Person
    {
        private string name;
        private int age;

        public string Name => this.name;
        public int Age => this.age;

    public Person(string name, int age)
    {
        this.name = name;
        this.age = age;
    }
}

