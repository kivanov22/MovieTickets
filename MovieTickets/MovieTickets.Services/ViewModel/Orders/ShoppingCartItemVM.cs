using MovieTickets.Data.Models;
using System.ComponentModel.DataAnnotations;

namespace MovieTickets.Services.ViewModel.Orders
{
    public class ShoppingCartItemVM
    {
        [Key]
        public int Id { get; set; }

        public virtual Movie Movie { get; set; }

        public int Quantity { get; set; }

        public string ShoppingCartId { get; set; }
    }
}
