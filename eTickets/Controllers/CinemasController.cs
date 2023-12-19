﻿using eTickets.Data;
using eTickets.Data.Services;
using eTickets.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eTickets.Controllers
{
    public class CinemasController : Controller
    {
        private readonly ICinemasService _cinemasService;

        public CinemasController(ICinemasService cinemasService)
        {
            _cinemasService = cinemasService;
        }
        public async Task<IActionResult> Index()
        {
            var allCinemas = await _cinemasService.GetAllAsync();
            return View(allCinemas);
        }

        //Get: Cinemas/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("Logo,Name,Description")]Cinema cinema)
        {
            if(!ModelState.IsValid) return View(cinema);
            await _cinemasService.AddAsync(cinema);
            return RedirectToAction("Index");
        }

        //Get: Cinemas/Details/id
        public async Task<IActionResult> Details(int id)
        {
            var cinemasDetails = await _cinemasService.GetByIdAsync(id);
            if (cinemasDetails == null) return View("NotFound");
            return View(cinemasDetails);
        }

        //Get: Cinemas/Edit/id
        public async Task<IActionResult> Edit(int id)
        {
            var cinemasDetails = await _cinemasService.GetByIdAsync(id);
            if (cinemasDetails == null) return View("NotFound");
            return View(cinemasDetails);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Logo,Name,Description")] Cinema cinema)
        {
            if (!ModelState.IsValid) return View(cinema);
            await _cinemasService.UpdateAsync(id, cinema);
            return RedirectToAction("Index");
        }

        //Get: Cinemas/Delete/id
        public async Task<IActionResult> Delete(int id)
        {
            var cinemasDetails = await _cinemasService.GetByIdAsync(id);
            if (cinemasDetails == null) return View("NotFound");
            return View(cinemasDetails);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirm(int id)
        {
            var cinemasDetails = await _cinemasService.GetByIdAsync(id);
            if (cinemasDetails == null) return View("NotFound");

            await _cinemasService.DeleteAsync(id);
            return RedirectToAction("Index");
        }
    }
}