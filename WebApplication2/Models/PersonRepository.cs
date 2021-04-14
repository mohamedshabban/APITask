using System.Collections.Generic;

namespace WebApplication2.Models
{
    public class PersonRepository : IPersonRepository
    {
        private List<Person> items;
        private List<Hoppy> hoppies;
        public PersonRepository()
        {
            hoppies = new List<Hoppy>
            {
                new Hoppy {HoppyId = 1, Name = "football"},
                new Hoppy {HoppyId = 2, Name = "tennis"}
            };
            items= new List<Person>
            {
                new Person{Age=22,Name = "mohamed",Hoppies = hoppies}
            };
        }


        public IEnumerable<Person> GetAllPersons()
        {
            return items;
        }
    }
}