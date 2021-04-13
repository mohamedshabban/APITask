using System;
using System.Data.Entity;
using System.Linq;

namespace WebApplication2.Models
{
    public class AppDbContext : DbContext
    {
        
        public AppDbContext()
            : base("name=AppDbContext")
        {

        }

        public virtual DbSet<Hoppy>Hoppies { get; set; }
        public virtual DbSet<Person> Persons { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //student =person
            //hoppy=course
            modelBuilder.Entity<Person>()
                .HasMany<Hoppy>(s => s.Hoppies)
                .WithMany(c => c.Persons)
                .Map(cs =>
                {
                    cs.MapLeftKey("PersonRefId");
                    cs.MapRightKey("HoppyRefId");
                    cs.ToTable("PersonHoppy");
                });

        }
    }

}