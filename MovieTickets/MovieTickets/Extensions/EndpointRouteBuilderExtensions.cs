using MovieTickets.Web.Controllers;

namespace MovieTickets.Web.Extensions
{
    public static class EndpointRouteBuilderExtensions
    {
        public static void MapDefaultRoutes(this IEndpointRouteBuilder endpoints)
        {
            endpoints.MapControllerRoute(
                "Movie Details",
                "/Movies/Details/{id}",
                defaults: new
                {
                    controller = typeof(MoviesController).GetControllerName(),
                    action = nameof(MoviesController.Details),
                });

            //endpoints.MapControllerRoute(
            //   "Movie Edit",
            //   "/Movies/Edit/{id}",
            //   defaults: new
            //   {
            //       controller = typeof(MoviesController).GetControllerName(),
            //       action = nameof(MoviesController.Edit),
            //   });

            //Actors
            //Producers
            //Cinemas
        }
    }
}
//https://localhost:7186/Movies/Details/0