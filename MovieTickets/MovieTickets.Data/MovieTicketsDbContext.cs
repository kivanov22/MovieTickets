namespace MovieTickets.Data
{
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using MovieTickets.Data.Models;

    public class MovieTicketsDbContext : IdentityDbContext<ApplicationUser>
    {
        public MovieTicketsDbContext(DbContextOptions<MovieTicketsDbContext> options)
           : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<MovieActor>()
                 .HasKey(ma => new { ma.ActorId, ma.MovieId });

            builder.Entity<MovieActor>().HasOne(m=>m.Movie).WithMany(ma=>ma.MovieActors).HasForeignKey(ma=>ma.MovieId);
            builder.Entity<MovieActor>().HasOne(m=>m.Actor).WithMany(ma=>ma.MovieActors).HasForeignKey(ma=>ma.ActorId);

            base.OnModelCreating(builder);
        }
        public DbSet<Producer> Producers { get; set; }
        public DbSet<Actor> Actors { get; set; }

        public DbSet<MovieActor> MovieActors { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Cinema> Cinemas { get; set; }
        public DbSet<Ticket> Tickets { get; set; }

        //orders
        public DbSet<Order> Orders { get; set; }

        public DbSet<OrderItem> OrderItems { get; set; }

        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }
    }
}
