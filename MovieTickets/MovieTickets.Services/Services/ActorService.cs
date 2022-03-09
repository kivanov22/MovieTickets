using MovieTickets.Data;
using MovieTickets.Data.Data.Common;
using MovieTickets.Data.Models;
using MovieTickets.Services.Contracts;

namespace MovieTickets.Services.Services
{
    public class ActorService :EntityBaseRepository<Actor>, IActorService
    {

        public ActorService(MovieTicketsDbContext context):base(context){ }

       
    }
}
