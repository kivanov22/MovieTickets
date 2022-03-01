using System.ComponentModel.DataAnnotations;

namespace MovieTickets.Data.Models
{
    public class Actor
    {
        [Key]
        public int ActorId { get; set; }

        [Required]
        public string ProfilePicture { get; set; }

        [Required]
        public string FullName { get; set; }

        [Required]
        public string Bio { get; set; }
    }
}
