﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieTickets.Data.Data.Static;
using MovieTickets.Services.Contracts;
using MovieTickets.Services.ViewModel.Actors;

namespace MovieTickets.Web.Controllers
{
    [Authorize(Roles = UserRoles.Admin)]
    public class ActorsController : Controller
    {
        private readonly IActorService _service;

        public ActorsController(IActorService service)
        {
            _service = service;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            //Make it Quriable instead of Enumerable
            var data = await _service.GetAllAsync();
            var actors = new ActorViewModel();

           var dataQuery = data.AsQueryable()

            // dataQuery
                .Select(x => new ActorViewModel
            {
                ActorId = x.Id,
                ProfilePicture = x.ProfilePicture,
                FullName = x.FullName,
                Age = x.Age,
                Biography = x.Biography,
                MovieActors = x.MovieActors.ToList()
            })
            .ToList();

          

            var allActors = new AllActorsViewModel
            {
                Actors = dataQuery,
                ProfilePicture = actors.ProfilePicture,//??
                FullName = actors.FullName,
                Biography = actors.Biography
            };

            return View(allActors);
        }

        //Get: Actors/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        //[Bind("FullName,ProfilePicture,Age,Biography")]
        public async Task<IActionResult> Create(ActorViewModel actor)
        {
            if (!ModelState.IsValid)
            {
                return View(actor);
            }
            await _service.AddNewActorAsync(actor);
            return RedirectToAction(nameof(Index));
        }

        //Get: Actors/Details/1
        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            var actorDetails = await _service.GetByIdAsync(id);

            if (actorDetails == null) return View("NotFound");

            var response = new ActorViewModel()
            {
                ActorId = actorDetails.Id,
                ProfilePicture = actorDetails.ProfilePicture,
                FullName = actorDetails.FullName,
                Age = actorDetails.Age,
                Biography = actorDetails.Biography,
                MovieActors = actorDetails.MovieActors.ToList()
            };

            return View(response);
        }

        //Get: Actors/Edit/1
        public async Task<IActionResult> Edit(int id)
        {
            var actorDetails = await _service.GetByIdAsync(id);
            if (actorDetails == null) return View("NotFound");

            var response = new ActorViewModel
            {
                ActorId = actorDetails.Id,
                ProfilePicture = actorDetails.ProfilePicture,
                FullName = actorDetails.FullName,
                Age = actorDetails.Age,
                Biography = actorDetails.Biography

            };
            return View(response);
        }

        [HttpPost]
        //[Bind("Id,FullName,ProfilePicture,Age,Biography")]
        public async Task<IActionResult> Edit(int id, ActorViewModel actor)
        {
            if (id != actor.ActorId)
            {
                return View("NotFound");
            }

            //??
            //if (!ModelState.IsValid)
            //{
            //    var movieDropdownsData = await _service.GetNewMovieDropdownsValues();

            //    ViewBag.Cinemas = new SelectList(movieDropdownsData.Cinemas, "Id", "CinemaName");
            //    ViewBag.Producers = new SelectList(movieDropdownsData.Producers, "Id", "FullName");
            //    ViewBag.Actors = new SelectList(movieDropdownsData.Actors, "Id", "FullName");//ActorId maybe

            //    return View(movie);
            //}

            //var modelActor = new ActorViewModel
            //{
            //    ActorId = actor.Id,
            //    ProfilePicture = actor.ProfilePicture,
            //    FullName = actor.FullName,
            //    Age = actor.Age,
            //    Biography = actor.Biography
            //};

            await _service.UpdateActorAsync(actor);
            return RedirectToAction(nameof(Index));
        }

        //Get: Actors/Delete/1
        public async Task<IActionResult> Delete(int id)
        {
            var actorDetails = await _service.GetByIdAsync(id);
            if (actorDetails == null) return View("NotFound");
            return View(actorDetails);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var actorDetails = await _service.GetByIdAsync(id);
            if (actorDetails == null) return View("NotFound");

            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
