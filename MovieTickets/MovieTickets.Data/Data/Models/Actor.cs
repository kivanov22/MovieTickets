using MovieTickets.Data.Data.Common;
using System.ComponentModel.DataAnnotations;

namespace MovieTickets.Data.Models
{
    using static DataConstants;
    public class Actor: IEntityBase
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string ProfilePicture { get; set; }

        [Required]
        [MaxLength(FullNameMaxLength)]
        public string FullName { get; set; }

        public int Age { get; set; }

        [Required]
        [MaxLength(BiographyMaxLength)]
        public string Biography { get; set; }

        public virtual ICollection<MovieActor> MovieActors { get; set; } = new List<MovieActor>();
    }
}
