using Microsoft.EntityFrameworkCore;
using MovieTickets.Data;
using MovieTickets.Data.Data.Common;
using MovieTickets.Data.Models;
using MovieTickets.Services.Contracts;
using MovieTickets.Services.ViewModel.Actors;

namespace MovieTickets.Services.Services
{
    public class ActorService : EntityBaseRepository<Actor>, IActorService
    {
        private readonly MovieTicketsDbContext _context;
        public ActorService(MovieTicketsDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task AddNewActorAsync(ActorViewModel data)
        {
            var newActor = new Actor()
            {
                ProfilePicture = data.ProfilePicture,
                FullName = data.FullName,
                Age = data.Age,
                Biography = data.Biography,

            };

            if (newActor == null)
            {
                throw new ArgumentException("Unknown actor");
            }

            if (string.IsNullOrWhiteSpace(data.Biography))
            {
                throw new ArgumentException("Biography is required");
            }

            await _context.Actors.AddAsync(newActor);
            await _context.SaveChangesAsync();

        }



        public async Task<Actor> GetActorByIdAsync(int id)
        {
            var actorDetails = await _context.Actors
                 .FirstOrDefaultAsync(n => n.Id == id);

            return actorDetails;
        }

        public async Task UpdateActorAsync(ActorViewModel data)
        {
            var dbActor = await _context.Actors.FirstOrDefaultAsync(x => x.Id == data.Id);

            if (dbActor != null)
            {
                //dbActor.Id = data.ActorId;
                dbActor.ProfilePicture = data.ProfilePicture;
                dbActor.FullName = data.FullName;
                dbActor.Age = data.Age;
                dbActor.Biography = data.Biography;

                await _context.SaveChangesAsync();
            }

            await _context.SaveChangesAsync();
        }
    }
}
