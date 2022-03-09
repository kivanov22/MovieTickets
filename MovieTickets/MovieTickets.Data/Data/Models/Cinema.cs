using MovieTickets.Data.Data.Common;
using System.ComponentModel.DataAnnotations;

namespace MovieTickets.Data.Models
{
    using static DataConstants;
    public class Cinema: IEntityBase
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Logo { get; set; }

        [Required]
        [MaxLength(CinemaNameMaxLenght)]
        public string CinemaName { get; set; }

        [Required]
        [MaxLength(CityNameMaxLenght)]
        public string City { get; set; }

        [Required]
        //[MaxLength(CinemaAddressMaxLenght)]
        public string CinemaAddress { get; set; }
       
        public virtual ICollection<Movie> Movies { get; set; } = new List<Movie>();

    }
}
