using EVE.Data;
using EVE.Data.Services;
using EVE.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EVE.Controllers
{
    public class BusDriversController : Controller
    {
        private readonly IBusDriversService _service;

        public BusDriversController(IBusDriversService service)
        {
            _service = service;
        }
        public async Task<IActionResult> Index()
        {
            var data = await _service.GetAllAsync();
            return View(data);
        }
        //Get request Actors/Create
        public  IActionResult Create ()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create ([Bind("Emri,BusDriverPic,Bio")]BusDriver driver)
        {
             if (!ModelState.IsValid)
            {
                return View(driver);
            }
            await _service.AddAsync(driver);
            return RedirectToAction(nameof(Index));
        }

        //Get: BusDrivers/Details/1 <-- ID
        public async Task<IActionResult> Details (int id)
        {
            var driverDetails = await _service.GetByIdAsync(id);

            if (driverDetails == null) return View("NotFound");
            return View(driverDetails);
        }

        //Get request Actors/Create
        public async Task< IActionResult> Edit(int id)
        {
            var driverDetails = await _service.GetByIdAsync(id);

            if (driverDetails == null) return View("NotFound");
            return View(driverDetails);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Emri,BusDriverPic,Bio")] BusDriver driver)
        {
            if (!ModelState.IsValid)
            {
                return View(driver);
            }
            await _service.UpdateAsync(id, driver);
            return RedirectToAction(nameof(Index));
        }

        //Get request Actors/Delete/1 <-- Me fshi
        public async Task<IActionResult> Delete(int id)
        {
            var driverDetails = await _service.GetByIdAsync(id);

            if (driverDetails == null) return View("NotFound");
            return View(driverDetails);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var driverDetails = await _service.GetByIdAsync(id);
            if (driverDetails == null) return View("NotFound");

            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
