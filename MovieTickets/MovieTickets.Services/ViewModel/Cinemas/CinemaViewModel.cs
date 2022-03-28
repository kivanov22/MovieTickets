using MovieTickets.Data.Models;
using System.ComponentModel.DataAnnotations;

namespace MovieTickets.Services.ViewModel.Cinemas
{
    using static Data.DataConstants;
    public class CinemaViewModel
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = DisplayCinemaLogo)]
        [Required(ErrorMessage = CinemaLogoError)]
        public string Logo { get; set; }

        [Display(Name = DisplayCinemaName)]
        [Required(ErrorMessage = CinemaNameError)]
        public string CinemaName { get; set; }

        [Display(Name =DisplayCity)]
        [Required(ErrorMessage = CinemaCityError)]
        public string City { get; set; }

        [Display(Name = DisplayCinemaAddress)]
        [Required(ErrorMessage = CinemaAddressError)]
        public string CinemaAddress { get; set; }

        //Relationships
        
        public List<Movie> Movies { get; set; }
    }
}
