using MovieTickets.Services.ViewModel.Producers;

namespace MovieTickets.Services.ViewModel.Producers
{
    public class AllProducerViewModel
    {
        public IEnumerable<ProducerViewModel> Producers { get; set; }

        public string ProfilePicture { get; set; }

        public string FullName { get; set; }

        public int Age { get; set; }

        public string Biography { get; set; }
    }
}
