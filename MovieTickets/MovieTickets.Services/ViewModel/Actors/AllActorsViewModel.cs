namespace MovieTickets.Services.ViewModel.Actors
{
    public class AllActorsViewModel
    {
        public IEnumerable<ActorViewModel> Actors { get; set; }

        public string ProfilePicture { get; set; }

        public string FullName { get; set; }

        public string Biography { get; set; }
    }
}
