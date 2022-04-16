using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MovieTickets.Data.Data.Static;
using MovieTickets.Services.Contracts;
using MovieTickets.Services.ViewModel.Movies;
using MovieTickets.Services.ViewModels.Movies;

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


            var movieQuery = allMovies
                .AsQueryable()
                .Select(x => new MovieVM
                {
                    Id = x.Id,
                    Title = x.Title,
                    Description = x.Description,
                    Language = x.Language,
                    Duration = x.Duration,
                    Price = x.Price,
                    ImageUrl = x.ImageUrl,
                    StartDate = x.StartDate,
                    EndDate = x.EndDate,
                    Genre = x.Genre.ToString(),
                    Resolution = x.Resolution.ToString(),
                    CinemaId = x.CinemaId,
                    ProducerId = x.ProducerId,
                    Cinema = x.Cinema,
                    Producer = x.Producer,
                    MovieActors = x.MovieActors
                })
                .ToList();

            var dto = new AllMovieViewModel
            {
                Movies = movieQuery,
            };
            return View(dto);
        }

        [AllowAnonymous]
        public async Task<IActionResult> Filter(string searchString)
        {
            var allMovies = await _service.GetAllAsync(n => n.Cinema);


            if (!string.IsNullOrEmpty(searchString))
            {
                var movieQuery = allMovies
               .AsQueryable()
               .Select(x => new MovieVM
               {
                   Id = x.Id,
                   Title = x.Title,
                   Description = x.Description,
                   Language = x.Language,
                   Duration = x.Duration,
                   Price = x.Price,
                   ImageUrl = x.ImageUrl,
                   StartDate = x.StartDate,
                   EndDate = x.EndDate,
                   Genre = x.Genre.ToString(),
                   Resolution = x.Resolution.ToString(),
                   CinemaId = x.CinemaId,
                   ProducerId = x.ProducerId,
                   Cinema = x.Cinema,
                   Producer = x.Producer,
                   MovieActors = x.MovieActors
               })
               .ToList();

                var filteredResult = movieQuery
                .Where(n => n.Title.Contains(searchString,StringComparison.InvariantCultureIgnoreCase)
                || n.Description.Contains(searchString,StringComparison.InvariantCultureIgnoreCase)).ToList();

                var dto = new AllMovieViewModel
                {
                    Movies = filteredResult,
                };

                return View("Index", dto);

            }

            return View("Index", allMovies);
        }


        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            var movieDetails = await _service.GetMovieByIdAsync(id);

            if (movieDetails == null)
            {
                return View("NotFound");
            }

            var response = new MovieVM()
            {
                Id = movieDetails.Id,
                Title = movieDetails.Title,
                Description = movieDetails.Description,
                Language = movieDetails.Language,
                Duration = movieDetails.Duration,
                Price = movieDetails.Price,
                ImageUrl = movieDetails.ImageUrl,
                StartDate = movieDetails.StartDate,
                EndDate = movieDetails.EndDate,
                Genre = movieDetails.Genre.ToString(),
                Resolution = movieDetails.Resolution.ToString(),
                CinemaId = movieDetails.CinemaId,
                ProducerId = movieDetails.ProducerId,
                Cinema = movieDetails.Cinema,
                Producer = movieDetails.Producer,
                MovieActors = movieDetails.MovieActors
            };


            return View(response);
        }

        public async Task<IActionResult> Create()
        {
            var movieDropdownsData = await _service.GetNewMovieDropdownsValues();

            ViewBag.Cinemas = new SelectList(movieDropdownsData.Cinemas, "Id", "CinemaName");
            ViewBag.Producers = new SelectList(movieDropdownsData.Producers, "Id", "FullName");
            ViewBag.Actors = new SelectList(movieDropdownsData.Actors, "Id", "FullName");//ActorId maybe

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(NewMovieVM movie)
        {
            if (!ModelState.IsValid)
            {
                var movieDropdownsData = await _service.GetNewMovieDropdownsValues();

                ViewBag.Cinemas = new SelectList(movieDropdownsData.Cinemas, "Id", "CinemaName");
                ViewBag.Producers = new SelectList(movieDropdownsData.Producers, "Id", "FullName");
                ViewBag.Actors = new SelectList(movieDropdownsData.Actors, "Id", "FullName");

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
                StartDate = movieDetails.StartDate,
                EndDate = movieDetails.EndDate,
                Genre = movieDetails.Genre,
                Resolution = movieDetails.Resolution,
                CinemaId = movieDetails.CinemaId,
                ProducerId = movieDetails.ProducerId,
                ActorIds = movieDetails.MovieActors.Select(x => x.ActorId).ToList(),
            };

            var movieDropdownsData = await _service.GetNewMovieDropdownsValues();

            ViewBag.Cinemas = new SelectList(movieDropdownsData.Cinemas, "Id", "CinemaName");
            ViewBag.Producers = new SelectList(movieDropdownsData.Producers, "Id", "FullName");
            ViewBag.Actors = new SelectList(movieDropdownsData.Actors, "Id", "FullName");

            return View(response);
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

                ViewBag.Cinemas = new SelectList(movieDropdownsData.Cinemas, "Id", "CinemaName");
                ViewBag.Producers = new SelectList(movieDropdownsData.Producers, "Id", "FullName");
                ViewBag.Actors = new SelectList(movieDropdownsData.Actors, "Id", "FullName");

                return View(movie);
            }
            await _service.UpdateMovieAsync(movie);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            var movieDetails = await _service.GetByIdAsync(id);
            if (movieDetails == null) return View("NotFound");

            var actorView = new MovieViewModel
            {
                Id = movieDetails.Id,
                Title = movieDetails.Title,
                Description = movieDetails.Description,
                Language = movieDetails.Language,
                Duration = movieDetails.Duration,
                Price = movieDetails.Price,
                ImageUrl = movieDetails.ImageUrl,
                Genre = movieDetails.Genre.ToString(),
                Resolution = movieDetails.Resolution.ToString(),
                CinemaId = movieDetails.CinemaId,
                ProducerId = movieDetails.ProducerId,
                Cinema = movieDetails.Cinema,
                Producer = movieDetails.Producer,
                MovieActors = movieDetails.MovieActors
            };

            return View(actorView);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var movieDetails = await _service.GetByIdAsync(id);
            if (movieDetails == null) return View("NotFound");

            var movieView = new MovieViewModel
            {
                Id = movieDetails.Id,
                Title = movieDetails.Title,
                Description = movieDetails.Description,
                Language = movieDetails.Language,
                Duration = movieDetails.Duration,
                Price = movieDetails.Price,
                ImageUrl = movieDetails.ImageUrl,
                Genre = movieDetails.Genre.ToString(),
                Resolution = movieDetails.Resolution.ToString(),
                CinemaId = movieDetails.CinemaId,
                ProducerId = movieDetails.ProducerId,
                Cinema = movieDetails.Cinema,
                Producer = movieDetails.Producer,
                MovieActors = movieDetails.MovieActors
            };

            await _service.DeleteAsync(movieView.Id);
            return RedirectToAction(nameof(Index));
        }
    }
}
