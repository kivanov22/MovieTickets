using Microsoft.EntityFrameworkCore;
using MovieTickets.Data;
using MovieTickets.Data.Data.Common;
using MovieTickets.Data.Models;
using MovieTickets.Services.Contracts;
using MovieTickets.Services.ViewModel.Producers;

namespace MovieTickets.Services.Services
{
    public class ProducerService: EntityBaseRepository<Producer>, IProducerService
    {
        private readonly MovieTicketsDbContext _context;
        public ProducerService(MovieTicketsDbContext context): base(context) 
        { 
            _context = context;
        }

        public async Task AddNewProducerAsync(ProducerViewModel data)
        {
            var newProducer = new Producer()
            {
                ProfilePicture = data.ProfilePicture,
                FullName = data.FullName,
                Age = data.Age,
                Biography = data.Biography,
                //Movies = data.Movies.ToList()
            };

            //var movie = new MovieViewModel
            //{

            //};

            await _context.Producers.AddAsync(newProducer);
            await _context.SaveChangesAsync();
        }

        public async Task<Producer> GetProducerByIdAsync(int id)
        {
            var producerDetails = await _context.Producers
                 .FirstOrDefaultAsync(n => n.Id == id);

            return producerDetails;
        }

        public async Task UpdateProducerAsync(ProducerViewModel data)
        {
            var dbProducer = await _context.Producers.FirstOrDefaultAsync(x => x.Id == data.Id);

            if (dbProducer != null)
            {

                dbProducer.ProfilePicture = data.ProfilePicture;
                dbProducer.FullName = data.FullName;
                dbProducer.Age = data.Age;
                dbProducer.Biography = data.Biography;

                await _context.SaveChangesAsync();
            }

            await _context.SaveChangesAsync();
        }
    }
}
