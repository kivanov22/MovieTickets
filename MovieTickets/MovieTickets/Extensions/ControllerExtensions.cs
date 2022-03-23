using Microsoft.AspNetCore.Mvc;

namespace MovieTickets.Web.Extensions
{
    public static class ControllerExtensions
    {
        public static string GetControllerName(this Type controllerType)
            => controllerType.Name.Replace(nameof(Controller), string.Empty);
    }
}
