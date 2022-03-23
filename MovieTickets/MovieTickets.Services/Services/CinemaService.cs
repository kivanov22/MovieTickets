using Microsoft.EntityFrameworkCore;
using MovieTickets.Data;
using MovieTickets.Data.Data.Common;
using MovieTickets.Data.Models;
using MovieTickets.Services.Contracts;
using MovieTickets.Services.ViewModel.Cinemas;

namespace MovieTickets.Services.Services
{
    public class CinemaService : EntityBaseRepository<Cinema>,ICinemaService
    {
        private readonly MovieTicketsDbContext _context;
        public CinemaService(MovieTicketsDbContext context) :base(context)
        {
            _context = context;
        }

        public async Task AddNewCinemaAsync(CinemaViewModel data)
        {
            var newCinema = new Cinema()
            {
                Logo = data.Logo,
                CinemaName = data.CinemaName,
                City = data.City,
                CinemaAddress = data.CinemaAddress,
                //Movies
            };

            await _context.Cinemas.AddAsync(newCinema);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteCinemaAsync(int id)
        {

            var dbCinema = await _context.Cinemas.FirstOrDefaultAsync(x => x.Id == id);

             _context.Remove<Cinema>(dbCinema);
            await _context.SaveChangesAsync();
           
        }

        public async Task<Cinema> GetCinemaByIdAsync(int id)
        {
            var cinemaDetails = await _context.Cinemas
                .FirstOrDefaultAsync(n => n.Id == id);

            return cinemaDetails;
        }

        public async Task UpdateCinemaAsync(CinemaViewModel data)
        {
            var dbCinema = await _context.Cinemas.FirstOrDefaultAsync(x => x.Id == data.Id);

            if (dbCinema != null)
            {

                dbCinema.Logo = data.Logo;
                dbCinema.CinemaName = data.CinemaName;
                dbCinema.City = data.City;
                dbCinema.CinemaAddress = data.CinemaAddress;
                //dbCinema.Movies = data.Movies.ToList();

                await _context.SaveChangesAsync();
            }

            await _context.SaveChangesAsync();
        }
    }
}
