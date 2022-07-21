using EVE.Data.Base;
using EVE.Data.ViewModels;
using EVE.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EVE.Data.Services
{
    public class BusInfoService:EntityBaseRepository<BusInfo>,IBusInfoService
    {

        private readonly AppDbContext _context;
        public BusInfoService(AppDbContext context): base (context)
        {
            _context = context;
        }

        public async Task AddNewBusInfoAsync(NewBusInfoVM data)
        {
            var newBusInfo = new BusInfo()
            {
                BusPhoto = data.BusPhoto,
                BusType = data.BusType,
                Pershkrimi = data.Pershkrimi,
                StartLineDate = data.StartLineDate,
                EndLineDate = data.EndLineDate,
                TicketPrice = data.TicketPrice,
                BusCategory = data.BusCategory
            };
            await _context.BusInfos.AddAsync(newBusInfo);
            await _context.SaveChangesAsync();

            //Add BusInfo BusDrivers
            foreach (var busDriverID in data.BusDriverIDs)
            {
                var newBusDriverBusInfo = new BusDriver_BusInfo()
                {
                    BusInfoID = newBusInfo.ID,
                    BusDriverID = busDriverID
                };
                await _context.BusDrivers_BusInfos.AddAsync(newBusDriverBusInfo);
            }
            await _context.SaveChangesAsync();
        }

        public async Task<BusInfo> GetBusInfoByIdAsync(int id)
        {
            var BusInfoDetails = await _context.BusInfos
                .Include(am => am.BusDrivers_BusInfos).ThenInclude(a => a.BusDriver)
                .FirstOrDefaultAsync(n => n.ID == id);

            return BusInfoDetails;
        }

        public async Task<NewBusInfosDropdownsVM> GetNewBusInfoDropDownValues()
        {
            var response = new NewBusInfosDropdownsVM();
            {
                response.BusDrivers = await _context.BusDrivers.OrderBy(n => n.Emri).ToListAsync();

            }

            return response;
        }

        public async Task UpdateBusInfoAsync(NewBusInfoVM data)
        {

            var dbBusInfo = await _context.BusInfos.FirstOrDefaultAsync(n => n.ID == data.ID);

            if(dbBusInfo != null)
            {

                dbBusInfo.BusPhoto = data.BusPhoto;
                dbBusInfo.BusType = data.BusType;
                dbBusInfo.Pershkrimi = data.Pershkrimi;
                dbBusInfo.StartLineDate = data.StartLineDate;
                dbBusInfo.EndLineDate = data.EndLineDate;
                dbBusInfo.TicketPrice = data.TicketPrice;
                dbBusInfo.BusCategory = data.BusCategory;
                await _context.SaveChangesAsync();

            }

            //Remove BusDrivers

            var existingBusDriversDb = _context.BusDrivers_BusInfos.Where(n => n.BusInfoID == data.ID).ToList();
             _context.BusDrivers_BusInfos.RemoveRange(existingBusDriversDb);
            await _context.SaveChangesAsync();


            //Add BusInfo BusDrivers
            foreach (var busDriverID in data.BusDriverIDs)
            {
                var newBusDriverBusInfo = new BusDriver_BusInfo()
                {
                    BusInfoID = data.ID,
                    BusDriverID = busDriverID
                };
                await _context.BusDrivers_BusInfos.AddAsync(newBusDriverBusInfo);
            }
            await _context.SaveChangesAsync();
        }
    }
}
