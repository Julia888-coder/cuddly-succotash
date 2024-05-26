using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace MyWinFormsApp
{
    /*
     * Создать миграцию:
     * 1. Открыть "Средства" -> "Диспетчер пакетов NuGet" -> "Консоль диспетчера пакетов"
     * 2. Add-Migration InitialCreate
     */
    public class ApplicationContext : DbContext
    {
        public DbSet<Person> Persons => Set<Person>();

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }
    }

    public class ApplicationContextFactory : IDesignTimeDbContextFactory<ApplicationContext>
    {
        public ApplicationContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationContext>();
            optionsBuilder.UseSqlite("Data Source=persons.db");
            return new ApplicationContext(optionsBuilder.Options);
        }
    }

}
