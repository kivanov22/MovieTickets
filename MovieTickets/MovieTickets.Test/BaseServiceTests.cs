using Microsoft.EntityFrameworkCore;
using MovieTickets.Data;
using System;

namespace MovieTickets.Test
{
    public class BaseServiceTests
    {
        public static MovieTicketsDbContext GetDb()
        {
            var options = new DbContextOptionsBuilder<MovieTicketsDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;
            var db = new MovieTicketsDbContext(options);

            return db;
        }
    }
}
