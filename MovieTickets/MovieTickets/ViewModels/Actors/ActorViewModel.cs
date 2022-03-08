namespace MovieTickets.Web.Models.Actors
{
    using MovieTickets.Data.Models;
    using System.ComponentModel.DataAnnotations;
    using static Data.DataConstants;
    public class ActorViewModel
    {
        [Key]
        public int ActorId { get; set; }

        [Required(ErrorMessage =ProfilePictureError)]
        [Display(Name =DisplayProfilePicture)]
        public string ProfilePicture { get; set; }

        [Required(ErrorMessage =FullNameError)]
        [StringLength(FullNameMaxLength,
            MinimumLength = FullNameMinLength,
            ErrorMessage = "Full Name must be between {2} and {1} chars")]
        public string FullName { get; set; }

        [Range(AgeMinLength,AgeMaxLength)]
        [Display(Name =DisplayAge)]
        public int Age { get; set; }

        [Required(ErrorMessage = BiographyError)]
        [StringLength(BiographyMaxLength,
            MinimumLength = BiographyMinLength,
            ErrorMessage = "Biography must be between {2} and {1} chars")]
        public string Biography { get; set; }

        public ICollection<MovieActor> MovieActors { get; set; } = new List<MovieActor>();

    }
}
