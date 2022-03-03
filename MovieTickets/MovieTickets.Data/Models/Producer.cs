using System.ComponentModel.DataAnnotations;

namespace MovieTickets.Data.Models
{
    using static Data.DataConstants;
    public class Producer
    {
        [Key]

        public int ProducerId { get; set; }

        [Required]
        public string ProfilePicture { get; set; }

        [Required]
        [MaxLength(FullNameMaxLength)]
        public string FullName { get; set; }

        public int Age { get; set; }

        [Required]
        [MaxLength(BiographyMaxLength)]
        public string Biography { get; set; }


    }
}
