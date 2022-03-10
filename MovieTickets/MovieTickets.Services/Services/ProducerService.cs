using MovieTickets.Data;
using MovieTickets.Data.Data.Common;
using MovieTickets.Data.Models;
using MovieTickets.Services.Contracts;

namespace MovieTickets.Services.Services
{
    public class ProducerService: EntityBaseRepository<Producer>, IProducerService
    {
        public ProducerService(MovieTicketsDbContext context): base(context) { }
        
    }
}
