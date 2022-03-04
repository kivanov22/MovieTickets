using System.ComponentModel.DataAnnotations;

namespace MovieTickets.Data.Models
{
    using static DataConstants;
    public class Actor
    {
        [Key]
        public int ActorId { get; set; }

        [Required]
        public string ProfilePicture { get; set; }

        [Required]
        [MaxLength(FullNameMaxLength)]
        public string FullName { get; set; }

        public int Age { get; set; }

        [Required]
        [MaxLength(BiographyMaxLength)]
        public string Biography { get; set; }

        public ICollection<MovieActor> MovieActors { get; set; } = new List<MovieActor>();
    }
}
