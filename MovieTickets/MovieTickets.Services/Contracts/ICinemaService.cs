using MovieTickets.Data.Data.Common;
using MovieTickets.Data.Models;
using MovieTickets.Services.ViewModel.Cinemas;

namespace MovieTickets.Services.Contracts
{
    public interface ICinemaService:IEntityBaseRepository<Cinema>
    {
        Task<Cinema> GetCinemaByIdAsync(int id);
        Task AddNewCinemaAsync(CinemaViewModel data);
        Task UpdateCinemaAsync(CinemaViewModel data);

        Task DeleteCinemaAsync(int id);
    }
}
