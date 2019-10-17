using Microsoft.EntityFrameworkCore;

namespace DatabaseCode
{
    public class DatabaseContext
        : DbContext
    {
        private readonly string _threadId;

        public DatabaseContext(string threadId)
        {
            _threadId = threadId;
        }

        public DbSet<Person> Persons { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseInMemoryDatabase($"{nameof(DatabaseCode)}.{nameof(DatabaseContext)}({_threadId})");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Person>().HasKey(nameof(Person.FirstName), nameof(Person.LastName));
        }
    }
}
