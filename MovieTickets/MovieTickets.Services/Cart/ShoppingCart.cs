using Microsoft.EntityFrameworkCore;
using MovieTickets.Data;
using MovieTickets.Data.Models;

namespace MovieTickets.Services.Cart
{
    public class ShoppingCart
    {
        public MovieTicketsDbContext _context { get; set; }

        public string ShoppingCartId { get; set; }

        public List<ShoppingCartItem> ShoppingCartItems { get; set; }

        public ShoppingCart(MovieTicketsDbContext context)
        {
            _context = context;
        }

        public List<ShoppingCartItem> GetShoppingCartItems()
        {
            return ShoppingCartItems ?? (ShoppingCartItems = _context.ShoppingCartItems.Where(n => n.ShoppingCartId == ShoppingCartId)
                .Include(n => n.Movie).ToList());
        }
    }
}
