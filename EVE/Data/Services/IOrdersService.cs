using System;
using EVE.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EVE.Data.Services
{
    public interface IOrdersService
    {
        Task StoreOrderAsync(List<TicketCart> items, string userId, string userEmailAddress);
        Task<List<Order>> GetOrdersByUserIdAndRoleAsync(string userId, string userRole);
    }
}
