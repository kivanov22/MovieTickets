using Microsoft.EntityFrameworkCore;
using MovieTickets.Data;
using MovieTickets.Data.Data.Common;
using MovieTickets.Data.Models;
using MovieTickets.Services.Contracts;
using MovieTickets.Services.ViewModel.Actors;

namespace MovieTickets.Services.Services
{
    public class ActorService :EntityBaseRepository<Actor>, IActorService
    {
        private readonly MovieTicketsDbContext _context;
        public ActorService(MovieTicketsDbContext context):base(context)
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

            await _context.Actors.AddAsync(newActor);
            await _context.SaveChangesAsync();

            //foreach (var actorId in data.ActorIds)
            //{
            //    var newMovieActor = new MovieActor
            //    {
            //        MovieId = newMovie.Id,
            //        ActorId = actorId,
            //    };
            //    await _context.MovieActors.AddAsync(newMovieActor);
            //}
        }

        public async Task<Actor> GetActorByIdAsync(int id)
        {
            var actorDetails = await _context.Actors
                 .FirstOrDefaultAsync(n => n.Id == id);

            return actorDetails;
        }

        public async Task UpdateActorAsync(ActorViewModel data)
        {
            var dbActor = await _context.Actors.FirstOrDefaultAsync(x => x.Id == data.ActorId);

            if (dbActor != null)
            {

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
