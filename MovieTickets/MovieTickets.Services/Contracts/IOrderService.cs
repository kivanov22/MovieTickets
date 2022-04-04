using MovieTickets.Data.Models;
using MovieTickets.Services.ViewModel.Orders;

namespace MovieTickets.Services.Contracts
{
    public interface IOrderService
    {
        Task StoreOrderAsync(List<ShoppingCartItem> items, string userId, string userEmailAddress);

        Task<List<OrderViewModel>> GetOrdersByUserIdAndRoleAsync(string userId,string userRole);
    }
}
