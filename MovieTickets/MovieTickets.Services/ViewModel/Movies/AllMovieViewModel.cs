namespace MovieTickets.Services.ViewModel.Movies
{
    public class AllMovieViewModel
    {
        public IEnumerable<MovieViewModel> Movies { get; set; }

        public string CinemaName { get; set; }
    }
}
