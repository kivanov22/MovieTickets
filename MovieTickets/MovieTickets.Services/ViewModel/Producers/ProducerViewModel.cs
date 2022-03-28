using MovieTickets.Data.Models;
using System.ComponentModel.DataAnnotations;

namespace MovieTickets.Services.ViewModel.Producers
{
    using static Data.DataConstants;
    public class ProducerViewModel
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = DisplayProfilePicture)]
        [Required(ErrorMessage = ProfilePictureError)]
        public string ProfilePicture { get; set; }

        [Display(Name = DisplayFullName)]
        [Required(ErrorMessage = FullNameError)]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Full Name must be between 3 and 50 chars")]
        public string FullName { get; set; }

        [Display(Name = "Age")]
        [Required(ErrorMessage = "Age is required")]
        public int Age { get; set; }

        [Display(Name = DisplayBiography)]
        [Required(ErrorMessage = BiographyError)]
        public string Biography { get; set; }

        //Relationships
        public List<Movie> Movies { get; set; }
    }
}
