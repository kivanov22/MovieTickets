using MovieTickets.Data;
using MovieTickets.Data.Data.Common;
using MovieTickets.Data.Models;
using MovieTickets.Services.Contracts;

namespace MovieTickets.Services.Services
{
    public class CinemaService : EntityBaseRepository<Cinema>,ICinemaService
    {
        public CinemaService(MovieTicketsDbContext context) :base(context)
        {

        }
    }
}
