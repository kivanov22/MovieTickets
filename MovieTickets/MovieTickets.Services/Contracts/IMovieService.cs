using MovieTickets.Data.Data.Common;
using MovieTickets.Data.Models;
using MovieTickets.Services.ViewModel;
using MovieTickets.Services.ViewModel.Movies;

namespace MovieTickets.Services.Contracts
{
    public interface IMovieService:IEntityBaseRepository<Movie>
    {
        Task<Movie> GetMovieByIdAsync(int id);

        Task<NewMovieDropdownsVM> GetNewMovieDropdownsValues();

        Task AddNewMovieAsync(NewMovieVM data);
        Task UpdateMovieAsync(NewMovieVM data);
    }
}
