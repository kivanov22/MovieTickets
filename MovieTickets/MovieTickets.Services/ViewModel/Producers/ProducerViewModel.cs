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
        [StringLength(FullNameMaxLength,
            MinimumLength = FullNameMinLength,
            ErrorMessage = "Full Name must be between {2} and {1} chars")]
        
        public string FullName { get; set; }

        [Display(Name = DisplayAge)]
        [Required(ErrorMessage = AgeError)]
        public int Age { get; set; }

        [Display(Name = DisplayBiography)]
        [Required(ErrorMessage = BiographyError)]
        public string Biography { get; set; }

        //Relationships
        public List<Movie> Movies { get; set; }
    }
}
