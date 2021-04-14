using System;
using System.Collections.Generic;

namespace WebApplication2.Models
{
    public class Person
    {
        public int PersonId { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        
        public virtual ICollection<Hoppy> Hoppies{ get; set; }

        public Person()
        {
            Hoppies = new HashSet<Hoppy>();
        }
    }
}