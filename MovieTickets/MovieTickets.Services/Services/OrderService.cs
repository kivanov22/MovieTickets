using Microsoft.EntityFrameworkCore;
using MovieTickets.Data;
using MovieTickets.Data.Models;
using MovieTickets.Services.Contracts;
using MovieTickets.Services.ViewModel.Orders;

namespace MovieTickets.Services.Services
{
    public class OrderService : IOrderService
    {
        private readonly MovieTicketsDbContext _context;

        public OrderService(MovieTicketsDbContext context)
        {
            _context = context;
        }

        public async Task<List<OrderViewModel>> GetOrdersByUserIdAndRoleAsync(string userId,string userRole)
        {
            var orders = await _context.Orders
                .Include(o => o.OrderItems)
                .ThenInclude(m => m.Movie)
                .Include(u=>u.User)
                //.Where(u => u.UserId == userId)
                .Select(x => new OrderViewModel
                {
                    Id = x.Id,
                    Email = x.Email,
                    UserId = x.UserId,
                    User = x.User,
                    OrderItems = x.OrderItems
                })
                .ToListAsync();

            if (userRole != "Admin")
            {
                orders = orders.Where(u => u.UserId == userId).ToList();
            }

            return orders;
        }

        public async Task StoreOrderAsync(List<ShoppingCartItem> items, string userId, string userEmailAddress)
        {
            var order = new Order()
            {
                UserId = userId,
                Email = userEmailAddress
            };

            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();

            foreach (var item in items)
            {
                var orderItem = new OrderItem
                {
                    Quantity = item.Quantity,
                    MovieId = item.Movie.Id,
                    OrderId = order.Id,
                    Price = item.Movie.Price
                };
                await _context.OrderItems.AddAsync(orderItem);
            }

            await _context.SaveChangesAsync();
        }
    }
}
