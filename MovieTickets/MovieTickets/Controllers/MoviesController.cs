using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MovieTickets.Data.Data.Static;
using MovieTickets.Services.Contracts;
using MovieTickets.Services.ViewModel;

namespace MovieTickets.Web.Controllers
{
    [Authorize(Roles = UserRoles.Admin)]
    public class MoviesController : Controller
    {
        private readonly IMovieService _service;


        public MoviesController(IMovieService service)
        {
            _service = service;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var allMovies = await _service.GetAllAsync(n => n.Cinema);

            return View(allMovies);
        }

        public async Task<IActionResult> Filter(string searchString)
        {
            var allMovies = await _service.GetAllAsync(n => n.Cinema);

            if (!string.IsNullOrEmpty(searchString))
            {
                var filteredResult = allMovies
                    .Where(n => n.Title.Contains(searchString)
                    || n.Description.Contains(searchString)).ToList();

                return View("Index", filteredResult);

            }

            return View("Index", allMovies);
        }


        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            var movieDetail = await _service.GetMovieByIdAsync(id);

            return View(movieDetail);
        }

        public async Task<IActionResult> Create()
        {
            var movieDropdownsData = await _service.GetNewMovieDropdownsValues();

            ViewBag.CinemaId = new SelectList(movieDropdownsData.Cinemas, "Id", "CinemaName");
            ViewBag.ProducerId = new SelectList(movieDropdownsData.Producers, "Id", "FullName");
            ViewBag.ActorIds = new SelectList(movieDropdownsData.Actors, "Id", "FullName");//ActorId maybe

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(NewMovieVM movie)
        {
            if (!ModelState.IsValid)
            {
                return View(movie);
            }

            await _service.AddNewMovieAsync(movie);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var movieDetails = await _service.GetMovieByIdAsync(id);

            if (movieDetails == null)
            {
                return View("NotFound");
            }

            var response = new NewMovieVM()
            {
                Id = movieDetails.Id,
                Title = movieDetails.Title,
                Description = movieDetails.Description,
                Language = movieDetails.Language,
                Duration = movieDetails.Duration,
                Price = movieDetails.Price,
                ImageUrl = movieDetails.ImageUrl,
                Genre = movieDetails.Genre,
                Resolution = movieDetails.Resolution,
                CinemaId = movieDetails.CinemaId,
                ProducerId = movieDetails.ProducerId,
                ActorIds = movieDetails.MovieActors.Select(x => x.ActorId).ToList(),
            };

            var movieDropdownsData = await _service.GetNewMovieDropdownsValues();

            ViewBag.CinemaId = new SelectList(movieDropdownsData.Cinemas, "Id", "CinemaName");
            ViewBag.ProducerId = new SelectList(movieDropdownsData.Producers, "Id", "FullName");
            ViewBag.ActorIds = new SelectList(movieDropdownsData.Actors, "Id", "FullName");//ActorId maybe

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, NewMovieVM movie)
        {
            if (id != movie.Id)
            {
                return View("NotFound");
            }

            if (!ModelState.IsValid)
            {
                var movieDropdownsData = await _service.GetNewMovieDropdownsValues();

                ViewBag.CinemaId = new SelectList(movieDropdownsData.Cinemas, "Id", "CinemaName");
                ViewBag.ProducerId = new SelectList(movieDropdownsData.Producers, "Id", "FullName");
                ViewBag.ActorIds = new SelectList(movieDropdownsData.Actors, "Id", "FullName");//ActorId maybe

                return View(movie);
            }
            await _service.UpdateMovieAsync(movie);
            return RedirectToAction(nameof(Index));
        }
    }
}
