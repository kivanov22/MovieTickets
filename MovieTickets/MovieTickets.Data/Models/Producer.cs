using System.ComponentModel.DataAnnotations;

namespace MovieTickets.Data.Models
{
    public class Producer
    {
        [Key]

        public int ProducerId { get; set; }

        [Required]
        public string ProfilePicture { get; set; }

        [Required]
        public string FullName { get; set; }

        [Required]
        public string Biography { get; set; }


    }
}
