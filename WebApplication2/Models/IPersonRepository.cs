using System.Collections.Generic;

namespace WebApplication2.Models
{
    public interface IPersonRepository
    {
        IEnumerable<Person> GetAllPersons();
    }
}