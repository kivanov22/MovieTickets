using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using MovieTickets.Data;

namespace MovieTickets.Test
{
    public class InMemoryDbContext
    {
        private readonly SqliteConnection connection;
        private readonly DbContextOptions<MovieTicketsDbContext> dbContextOptions;

        public InMemoryDbContext()
        {
            connection = new SqliteConnection("Filename=:memory:");
            connection.Open();

            dbContextOptions = new DbContextOptionsBuilder<MovieTicketsDbContext>()
                .UseSqlite(connection)
                .Options;

            using var context = new MovieTicketsDbContext(dbContextOptions);

            context.Database.EnsureCreated();
        }

        public MovieTicketsDbContext CreateContext() => new MovieTicketsDbContext(dbContextOptions);

        public void Dispose() => connection.Dispose();
    }
}
