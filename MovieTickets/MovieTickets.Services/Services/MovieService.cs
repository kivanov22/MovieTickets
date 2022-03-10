using Microsoft.EntityFrameworkCore;
using MovieTickets.Data;
using MovieTickets.Data.Data.Common;
using MovieTickets.Data.Models;
using MovieTickets.Services.Contracts;
using MovieTickets.Services.ViewModel;

namespace MovieTickets.Services.Services
{
    public class MovieService : EntityBaseRepository<Movie>, IMovieService
    {
        private readonly MovieTicketsDbContext _context;
        public MovieService(MovieTicketsDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task AddNewMovieAsync(NewMovieVM data)
        {
            var newMovie = new Movie()
            {
                Title = data.Title,
                Description = data.Description,
                Language = data.Language,
                Duration = data.Duration,
                Price = data.Price,
                ImageUrl = data.ImageUrl,
                StartDate = data.StartDate,
                EndDate = data.EndDate,
                Genre = data.Genre,
                Resolution = data.Resolution,
                CinemaId = data.CinemaId,
                ProducerId = data.ProducerId
            };

            await _context.Movies.AddAsync(newMovie);
            await _context.SaveChangesAsync();

            foreach (var actorId in data.ActorIds)
            {
                var newMovieActor= new MovieActor
                {
                    MovieId = newMovie.Id,
                    ActorId = actorId,
                };
                await _context.MovieActors.AddAsync(newMovieActor);
            }
            await _context.SaveChangesAsync();
        }

        public async Task<Movie> GetMovieByIdAsync(int id)
        {
            var movieDetails = await _context.Movies
                 .Include(c => c.Cinema)
                 .Include(p => p.Producer)
                 .Include(ma => ma.MovieActors).ThenInclude(a => a.Actor)
                 .FirstOrDefaultAsync(n => n.Id == id);

            return movieDetails;
        }

        public async Task<NewMovieDropdownsVM> GetNewMovieDropdownsValues()
        {
            var response = new NewMovieDropdownsVM()
            {
                Actors = await _context.Actors.OrderBy(n => n.FullName).ToListAsync(),
                Cinemas = await _context.Cinemas.OrderBy(n => n.CinemaName).ToListAsync(),
                Producers = await _context.Producers.OrderBy(n => n.FullName).ToListAsync(),
            };

            return response;
        }

        public async Task UpdateMovieAsync(NewMovieVM data)
        {
            var dbMovie = await _context.Movies.FirstOrDefaultAsync(x => x.Id == data.Id);

            if (dbMovie != null)
            {

                dbMovie.Title = data.Title;
                dbMovie.Description = data.Description;
                dbMovie.Language = data.Language;
                dbMovie.Duration = data.Duration;
                dbMovie.Price = data.Price;
                dbMovie.ImageUrl = data.ImageUrl;
                dbMovie.StartDate = data.StartDate;
                dbMovie.EndDate = data.EndDate;
                dbMovie.Genre = data.Genre;
                dbMovie.Resolution = data.Resolution;
                dbMovie.CinemaId = data.CinemaId;
                dbMovie.ProducerId = data.ProducerId;

                await _context.SaveChangesAsync();
            }

            var existingActorsDb = _context.MovieActors.Where(x=>x.MovieId == data.Id).ToList();
            _context.MovieActors.RemoveRange(existingActorsDb);
            await _context.SaveChangesAsync();


            foreach (var actorId in data.ActorIds)
            {
                var newMovieActor = new MovieActor
                {
                    MovieId = data.Id,
                    ActorId = actorId,
                };
                await _context.MovieActors.AddAsync(newMovieActor);
            }
            await _context.SaveChangesAsync();
        }
    }
}
