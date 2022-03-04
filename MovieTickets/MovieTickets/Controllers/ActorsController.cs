using Microsoft.AspNetCore.Mvc;
using MovieTickets.Data;

namespace MovieTickets.Web.Controllers
{
    public class ActorsController:Controller
    {
        private readonly MovieTicketsDbContext data;

        public ActorsController(MovieTicketsDbContext data)
        {
            this.data = data;
        }

        public IActionResult Index()
        {
            var actors = data.Actors.ToList();

            return View(actors);
        }

    }
}
