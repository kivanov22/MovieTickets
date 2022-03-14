using Microsoft.EntityFrameworkCore;
using MovieTickets.Data;
using MovieTickets.Data.Models;
using MovieTickets.Services.Contracts;

namespace MovieTickets.Services.Services
{
    public class OrderService : IOrderService
    {
        private readonly MovieTicketsDbContext _context;

        public OrderService(MovieTicketsDbContext context)
        {
            _context = context;
        }

        public async Task<List<Order>> GetOrdersByUserIdAsync(string userId)
        {
            var orders = await _context.Orders
                .Include(o => o.OrderItems)
                .ThenInclude(m => m.Movie)
                .Where(u => u.UserId == userId)
                .ToListAsync();

            return orders;
        }

        public Task StoreOrderAsync(List<ShoppingCartItem> items, string userId, string userEmailAddress)
        {
            throw new NotImplementedException();
        }
    }
}
