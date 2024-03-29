﻿using eTickets.Data;
using eTickets.Data.Services;
using eTickets.Data.Static;
using eTickets.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eTickets.Controllers
{
    [Authorize(Roles = UserRoles.Admin)]
    public class ProducersController : Controller
    {
        private readonly IProducersService _producersService;

        public ProducersController(IProducersService producersService)
        {
            _producersService = producersService;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var allProducers = await _producersService.GetAllAsync();
            return View(allProducers);
        }

        //Get: producers/detials/id
        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var producerDetails = await _producersService.GetByIdAsync(id);

            if (producerDetails == null) return View("NotFound");
            return View(producerDetails);
        }

        //Get: producers/create/id
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("ProfilePictureURL,FullName,Bio")]Producer producer)
        {
            if(!ModelState.IsValid) return View(producer);

            await _producersService.AddAsync(producer);
            return RedirectToAction("Index"); 
        }

        //Get: producers/edit/id
        public async Task<IActionResult> Edit(int id)
        {
            var producerDetails = await _producersService.GetByIdAsync(id);
            if (producerDetails == null) return View("NotFound");
            return View(producerDetails);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ProfilePictureURL,FullName,Bio")] Producer producer)
        {
            if (!ModelState.IsValid) return View(producer);

            if(id == producer.Id)
            {
                await _producersService.UpdateAsync(id, producer);
                return RedirectToAction("Index");
            }
            return View(producer);
        }

        //Get: producers/delete/id
        public async Task<IActionResult> Delete(int id)
        {
            var producerDetails = await _producersService.GetByIdAsync(id);
            if (producerDetails == null) return View("NotFound");
            return View(producerDetails);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var producerDetails = await _producersService.GetByIdAsync(id);
            if (producerDetails == null) return View("NotFound");

            await _producersService.DeleteAsync(id);
            return RedirectToAction("Index");
        }

    }
}
