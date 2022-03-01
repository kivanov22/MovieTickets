namespace MovieTickets.Data
{
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;

    public class MovieTicketsDbContext: IdentityDbContext
    {
        public MovieTicketsDbContext(DbContextOptions<MovieTicketsDbContext> options)
           : base(options)
        {
        }
    }
}
