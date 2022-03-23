using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieTickets.Data.Data.Static;
using MovieTickets.Services.Contracts;
using MovieTickets.Services.ViewModel.Cinemas;

namespace MovieTickets.Web.Controllers
{
    [Authorize(Roles = UserRoles.Admin)]
    public class CinemasController : Controller
    {
        private readonly ICinemaService _service;

        public CinemasController(ICinemaService service)
        {
            _service = service;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var allCinemas = await _service.GetAllAsync();

            var cinema = new CinemaViewModel();

            var cinemaQuery = allCinemas
                .AsQueryable()
                .Select(x => new CinemaViewModel
                {
                    Id =x.Id,
                    Logo = x.Logo,
                    CinemaName = x.CinemaName,
                    City = x.City,
                    CinemaAddress = x.CinemaAddress,
                   // Movies = x.Movies.ToList()
                })
                .ToList();

            var dto = new AllCinemasViewModel
            {
                Cinemas = cinemaQuery,
            };

            return View(dto);
        }

        public IActionResult Create() => View();

        [HttpPost]
        //[Bind("Logo, CinemaName, City, CinemaAddress")]
        public async Task<IActionResult> Create(CinemaViewModel cinema)
        {
            //ModelState.Remove("Movies");
            if (!ModelState.IsValid)
            {
                return View(cinema);
            }

            await _service.AddNewCinemaAsync(cinema);
            return RedirectToAction(nameof(Index));
        }


        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            var cinemaDetails = await _service.GetByIdAsync(id);

            if (cinemaDetails == null)
            {
                return View("NotFound");
            }

            var response = new CinemaViewModel()
            {
                Id = cinemaDetails.Id,
                Logo = cinemaDetails.Logo,
                CinemaName = cinemaDetails.CinemaName,
                City = cinemaDetails.City,
                CinemaAddress = cinemaDetails.CinemaAddress,
                //Movies = cinemaDetails.Movies.ToList()
            };
            return View(response);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var cinemaDetails = await _service.GetByIdAsync(id);

            if (cinemaDetails == null)
            {
                return View("NotFound");
            }

            var response = new CinemaViewModel()
            {
                Id = cinemaDetails.Id,
                Logo = cinemaDetails.Logo,
                CinemaName = cinemaDetails.CinemaName,
                City = cinemaDetails.City,
                CinemaAddress = cinemaDetails.CinemaAddress,
                //Movies = cinemaDetails.Movies.ToList()
            };

            return View(response);
        }

        [HttpPost]
        //[Bind("Id,Logo, CinemaName, City, CinemaAddress")]
        public async Task<IActionResult> Edit(int id, CinemaViewModel cinema)
        {
            if (!ModelState.IsValid)
            {
                return View(cinema);
            }

            if (id != cinema.Id)
            {
                return View("NotFound");
            }
            await _service.UpdateCinemaAsync(cinema);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            var cinemaDetails = await _service.GetByIdAsync(id);

            if (cinemaDetails == null)
            {
                return View("NotFound");
            }

            var cineaModel = new CinemaViewModel
            {
                Id = cinemaDetails.Id,
                Logo = cinemaDetails.Logo,
                CinemaName = cinemaDetails.CinemaName,
                City = cinemaDetails.City,
                CinemaAddress = cinemaDetails.CinemaAddress,
            };

            return View(cineaModel);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cinemaDetails = await _service.GetByIdAsync(id);

            if (cinemaDetails == null)
            {
                return View("NotFound");
            }

            var cineaModel = new CinemaViewModel
            {
                Id = cinemaDetails.Id,
                Logo = cinemaDetails.Logo,
                CinemaName = cinemaDetails.CinemaName,
                City = cinemaDetails.City,
                CinemaAddress = cinemaDetails.CinemaAddress,
            };

            await _service.DeleteCinemaAsync(cineaModel.Id);
            return RedirectToAction(nameof(Index));
        }
    }
}
