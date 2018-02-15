using System.Collections.Generic;
using System.Linq;

    public class Family
    {
        private List<Person> people;

        public Family()
        {
            this.people = new List<Person>();
        }

        public List<Person> People => this.people;

        public void AddMember(Person member)
        {
            this.People.Add(member);
        }

        public Person GetOldestMember()
        {
            var oldestMemner = this.People.OrderByDescending(p => p.Age).First();

            return oldestMemner;
        }
    }

