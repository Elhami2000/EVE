
using EVE.Data;
using EVE.Data.Services;
using EVE.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EVE.Controllers
{
    public class BusInfosController : Controller
    {
        private readonly IBusInfoService _service;

        public BusInfosController (IBusInfoService service)
        {
            _service = service;
        }

        public async Task< IActionResult> Index()
        {
            var allBuses = await _service.GetAllAsync();
            return View(allBuses);
        }

        public async Task<IActionResult> Filter(string searchString)
        {
            var allBuses = await _service.GetAllAsync();

            if (!string.IsNullOrEmpty(searchString))
            {
                var filteredResult = allBuses.Where(n => n.BusType.ToLower().Contains(searchString.ToLower()) || n.Pershkrimi.ToLower().Contains(searchString.ToLower())).ToList();
                return View("Index", filteredResult);
            }

            return View(allBuses);
        }

        //GET: BusInfos/Details/1 <-- Details te BusInfos
        public async Task <IActionResult> Details(int id)
        {
            var BusInfoDetail = await _service.GetBusInfoByIdAsync(id);
            return View(BusInfoDetail);
        }

        //GET: BusInfos/Create <-- Krijimi i nje BusInfo te re
        public async Task<IActionResult> Create()
        {
            var busInfoDropDownsData = await _service.GetNewBusInfoDropDownValues();
            ViewBag.BusDrivers = new SelectList(busInfoDropDownsData.BusDrivers, "ID", "Emri");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(NewBusInfoVM busInfo)
        {
            if (!ModelState.IsValid)
            {
                var busInfoDropDownsData = await _service.GetNewBusInfoDropDownValues();
                ViewBag.BusDrivers = new SelectList(busInfoDropDownsData.BusDrivers, "ID", "Emri");
                return View(busInfo);
            }

            await _service.AddNewBusInfoAsync(busInfo);
            return RedirectToAction(nameof(Index));
        }
        //Get
        public async Task<IActionResult> Edit(int id)
        {

            var busDetails = await _service.GetBusInfoByIdAsync(id);

            if (busDetails == null) return View("NotFound");

            var response = new NewBusInfoVM()
            {
                ID = busDetails.ID,
                BusCategory = busDetails.BusCategory,
                BusPhoto = busDetails.BusPhoto,
                BusType = busDetails.BusType,
                Pershkrimi = busDetails.Pershkrimi,
                StartLineDate = busDetails.StartLineDate,
                EndLineDate = busDetails.EndLineDate,
                TicketPrice = busDetails.TicketPrice,
                BusDriverIDs = busDetails.BusDrivers_BusInfos.Select(n => n.BusDriverID).ToList(),

            };



            var busInfoDropDownsData = await _service.GetNewBusInfoDropDownValues();
            ViewBag.BusDrivers = new SelectList(busInfoDropDownsData.BusDrivers, "ID", "Emri");

            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, NewBusInfoVM businfo)
        {

            if (id != businfo.ID) return View("NotFound");
            if (!ModelState.IsValid)
            {
                var busInfoDropDownsData = await _service.GetNewBusInfoDropDownValues();
                ViewBag.BusDrivers = new SelectList(busInfoDropDownsData.BusDrivers, "ID", "Emri");
                return View(businfo);
            }

            await _service.UpdateBusInfoAsync(businfo);
            return RedirectToAction(nameof(Index));
        }


    }
}
 