using MovieTickets.Web.ViewModels.Movies;

namespace MovieTickets.Services.ViewModel.Movies
{
    public class AllMovieViewModel
    {
        public IEnumerable<MovieVM> Movies { get; set; }

        public string CinemaName { get; set; }
    }
}
