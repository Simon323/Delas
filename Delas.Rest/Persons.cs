using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delas.Rest
{
    public partial class Persons
    {
        private static readonly Persons _instance = new Persons();
        private Persons() { }
        public static Persons Instance
        {
            get { return _instance; }
        }
        public List<Person> PersonList
        {
            get { return persons; }
        }

        private List<Person> persons = new List<Person>()
        {
            new Person() {PersonId = 1, Name = "jan kwalski", Age = 32 }
        };
    }
}
