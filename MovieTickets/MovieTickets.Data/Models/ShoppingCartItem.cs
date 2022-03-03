using System.ComponentModel.DataAnnotations;

namespace MovieTickets.Data.Models
{
    public class ShoppingCartItem
    {
        [Key]
        public int Id { get; set; }

        public Movie Movie { get; set; }

        public int Quantity { get; set; }

        public string ShoppingCartId { get; set; }
    }
}
