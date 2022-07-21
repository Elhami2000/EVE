using EVE.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EVE.Data.Cart
{
    public class ShoppingCart
    {

        public AppDbContext _context { get; set; }

        public string CartId { get; set; }
        public List<TicketCart> TicketCarts { get; set; }


        public ShoppingCart (AppDbContext context) 
        {

            _context = context;

         }

        public static ShoppingCart GetShoppingCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            var context = services.GetService<AppDbContext>();

            string cartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();
            session.SetString("CartId", cartId);
            return new ShoppingCart(context) { CartId = cartId };
        }

        public void AddTicketToCart (BusInfo busInfo)
        {
            var ShoppingCartTicket = _context.TicketCarts.FirstOrDefault(n => n.BusInfo.ID == busInfo.ID &&
            n.CartId == CartId);

            if (ShoppingCartTicket == null)
            {
                ShoppingCartTicket = new TicketCart()
                {
                    CartId = CartId,
                    BusInfo = busInfo,
                    Amount = 1
                };

                _context.TicketCarts.Add(ShoppingCartTicket);

            }
            else
            {
                ShoppingCartTicket.Amount++;
            }
            _context.SaveChanges();

        }

        public void RemoveTicketFromCart(BusInfo busInfo)
        {
            var ShoppingCartTicket = _context.TicketCarts.FirstOrDefault(n => n.BusInfo.ID == busInfo.ID &&
            n.CartId == CartId);

            if (ShoppingCartTicket != null)
            {
                if(ShoppingCartTicket.Amount > 1)
                {
                    ShoppingCartTicket.Amount--;
                }
                else
                {
                    _context.TicketCarts.Remove(ShoppingCartTicket);
                }


            }
            _context.SaveChanges();
        }


        public List<TicketCart> GetTicketCarts()
        {
            return TicketCarts ?? (TicketCarts = _context.TicketCarts.Where(n => n.CartId ==
            CartId).Include(n => n.BusInfo).ToList());
        }

        public double GetShoppingCartTotal () =>
         _context.TicketCarts.Where(n => n.CartId == CartId).Select(n =>
            n.BusInfo.TicketPrice * n.Amount).Sum();
            
        public async Task ClearShoppingCartAsync()
        {
            var items = await _context.TicketCarts.Where(n => n.CartId ==
            CartId).ToListAsync();
            _context.TicketCarts.RemoveRange(items);
            await _context.SaveChangesAsync();
        }
    }
}
