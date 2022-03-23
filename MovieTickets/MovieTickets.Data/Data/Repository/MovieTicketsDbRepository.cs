namespace MovieTickets.Data.Data.Repository
{
    public class MovieTicketsDbRepository: Repository, IMovieTicketsDbRepository
    {
        public MovieTicketsDbRepository(MovieTicketsDbContext context)
        {
            this.Context = context;
        }
    }
}
