    public class Citizen : IPerson, IResident
    {
        private string _name;
        public string Age { get; set; }

    public Citizen(string name, string country, string age)
    {
        this.Age = age;
        this._name = name;
        this.Country = country;
    }

        string IPerson.Name => this._name;
        string IResident.Name => this._name;
    public string Country { get; set; }
        string IResident.GetName()
        {
            return $"Mr/Ms/Mrs {this._name}";
        }

        string IPerson.GetName()
        {
            return this._name;
        }
    }
