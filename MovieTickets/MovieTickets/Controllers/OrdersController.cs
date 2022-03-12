using Microsoft.AspNetCore.Mvc;
using MovieTickets.Services.Cart;
using MovieTickets.Services.Contracts;
using MovieTickets.Web.ViewModels.Orders;

namespace MovieTickets.Web.Controllers
{
    public class OrdersController:Controller
    {
        private readonly IMovieService _moviesService;
        private readonly ShoppingCart _shoppingCart;

        public OrdersController(IMovieService moviesService,
            ShoppingCart shoppingCart)
        {
            _moviesService = moviesService;
            _shoppingCart = shoppingCart;
        }

        public IActionResult Index()
        {
            var items = _shoppingCart.GetShoppingCartItems();

            _shoppingCart.ShoppingCartItems = items; 

            var response = new ShoppingCartViewModel()
            {
                ShoppingCart = _shoppingCart,
                ShoppingCartTotal = _shoppingCart.GetShoppingCartTotal()
            };

            return View(response);
        }
    }
}
