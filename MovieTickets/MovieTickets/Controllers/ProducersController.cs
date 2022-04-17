using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieTickets.Data.Data.Static;
using MovieTickets.Services.Contracts;
using MovieTickets.Services.ViewModel.Producers;

namespace MovieTickets.Web.Controllers
{
    [Authorize(Roles = UserRoles.Admin)]
    public class ProducersController: Controller
    {
        private readonly IProducerService _service;

        public ProducersController(IProducerService service
           )
        {
            _service = service;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var data = await _service.GetAllAsync();

            var producer = new ProducerViewModel();

            var dataQuery = data.AsQueryable()
                .Select(x => new ProducerViewModel
                {
                    Id = x.Id,
                    ProfilePicture = x.ProfilePicture,
                    FullName = x.FullName,
                    Age = x.Age,
                    Biography = x.Biography,
                    //Movies = x.Movies.ToList()
                })
                .ToList();

            var dto = new AllProducerViewModel
            {
                Producers = dataQuery,
                ProfilePicture= producer.ProfilePicture,
                FullName= producer.FullName,
                Age= producer.Age,
                Biography =producer.Biography
            };

            return View(dto);
        }

        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            var producerDetails = await _service.GetByIdAsync(id);

            if (producerDetails == null)
            {
                return View("NotFound");
            }

            var response = new ProducerViewModel()
            {
                Id = producerDetails.Id,
                ProfilePicture = producerDetails.ProfilePicture,
                FullName = producerDetails.FullName,
                Age = producerDetails.Age,
                Biography = producerDetails.Biography,
                //Movies = producerDetails.Movies.ToList()
            };

            return View(response);
        }

        public IActionResult Create() => View();

        [HttpPost]
        public async Task<IActionResult> Create(ProducerViewModel producer)
        {
            if (!ModelState.IsValid)
            {
                return View(producer);
            }

            await _service.AddNewProducerAsync(producer);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var producerDetails = await _service.GetByIdAsync(id);

            if (producerDetails == null)
            {
                return View("NotFound");
            }

            var response = new ProducerViewModel
            {
                Id = producerDetails.Id,
                ProfilePicture = producerDetails.ProfilePicture,
                FullName = producerDetails.FullName,
                Age = producerDetails.Age,
                Biography = producerDetails.Biography

            };

            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id,ProducerViewModel producer)
        {
            if (!ModelState.IsValid)
            {
                return View(producer);
            }

            if (id == producer.Id)
            {
                await _service.UpdateProducerAsync(producer);
                return RedirectToAction(nameof(Index));

            }
            return View(producer);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var producerDetails = await _service.GetByIdAsync(id);

            if (producerDetails == null)
            {
                return View("NotFound");
            }

            var producerModel = new ProducerViewModel
            {
                Id = producerDetails.Id,
                ProfilePicture = producerDetails.ProfilePicture,
                FullName = producerDetails.FullName,
                Age = producerDetails.Age,
                Biography = producerDetails.Biography,
            };

            return View(producerModel);
        }

        [HttpPost,ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var producerDetails = await _service.GetByIdAsync(id);

            if (producerDetails == null)
            {
                return View("NotFound");
            }

            var producerModel = new ProducerViewModel
            {
                Id = producerDetails.Id,
                ProfilePicture = producerDetails.ProfilePicture,
                FullName = producerDetails.FullName,
                Age = producerDetails.Age,
                Biography = producerDetails.Biography,
            };

            await _service.DeleteAsync(producerModel.Id);

            return RedirectToAction(nameof(Index));
        }


    }
}
