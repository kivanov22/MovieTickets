using MovieTickets.Data.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace MovieTickets.Services.ViewModel.Movies
{
    using static Data.DataConstants;
    public class NewMovieVM
    {
        public int Id { get; set; }

        [Display(Name = DisplayMovieName)]
        [Required(ErrorMessage = NameError)]
        public string Title { get; set; }

        [Display(Name = DisplayMovieDescription)]
        [Required(ErrorMessage = DescriptionError)]
        public string Description { get; set; }

        [Display(Name = DisplayMovieLanguage)]
        [Required(ErrorMessage = LanguageError)]
        public string Language { get; set; }

        [Display(Name = DisplayMovieDuration)]
        [Required(ErrorMessage = DurationError)]
        public int Duration { get; set; }

        [Display(Name = DisplayMoviePrice)]
        [Required(ErrorMessage = PriceError)]
        public double Price { get; set; }

        [Display(Name = DisplayMovieUrl)]
        [Required(ErrorMessage = PosterError)]
        public string ImageUrl { get; set; }

        [Display(Name = DisplayMovieStartDate)]
        [Required(ErrorMessage = StartDateError)]
        public DateTime StartDate { get; set; }

        [Display(Name = DisplayMovieEndDate)]
        [Required(ErrorMessage = EndDateError)]
        public DateTime EndDate { get; set; }

        [Display(Name = DisplayMovieGenre)]
        [Required(ErrorMessage = GenreError)]
        public Genre Genre { get; set; }

        [Display(Name = DisplayMovieResolution)]
        [Required(ErrorMessage = ResolutionError)]
        public Resolution Resolution { get; set; }

        //Relationships
        [Display(Name = DisplayMovieActors)]
        [Required(ErrorMessage = ActorsError)]
        public List<int> ActorIds { get; set; }

        [Display(Name = DisplayMovieCinema)]
        [Required(ErrorMessage = CinemaError)]
        public int CinemaId { get; set; }

        [Display(Name = DisplayMovieProducer)]
        [Required(ErrorMessage = ProducerError)]
        public int ProducerId { get; set; }
    }
}
