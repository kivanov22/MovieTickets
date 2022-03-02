namespace MovieTickets.Data
{
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using MovieTickets.Data.Models;

    public class MovieTicketsDbContext: IdentityDbContext
    {
        public MovieTicketsDbContext(DbContextOptions<MovieTicketsDbContext> options)
           : base(options)
        {
        }

        public DbSet<Actor> Actors { get; set; }
        public DbSet<Cinema> Cinemas { get; set; }
        public DbSet<Producer> Producers { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Movie> Movies { get; set; }
    }
}
