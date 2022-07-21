using EVE.Data.Base;
using EVE.Data.ViewModels;
using EVE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EVE.Data.Services
{
    public interface IBusInfoService:IEntityBaseRepository<BusInfo>
    {
        Task<BusInfo> GetBusInfoByIdAsync(int id);
        Task<NewBusInfosDropdownsVM> GetNewBusInfoDropDownValues();

        Task AddNewBusInfoAsync(NewBusInfoVM data);
        Task UpdateBusInfoAsync(NewBusInfoVM data);
    }
}
