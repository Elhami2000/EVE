using EVE.Data.Cart;
using EVE.Data.Services;
using EVE.Data.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace EVE.Controllers
{
    public class OrdersController : Controller
    {
        private readonly IBusInfoService _busInfoService;
        private readonly ShoppingCart _shoppingCart;
        private readonly IOrdersService _ordersService;
        public OrdersController(IBusInfoService busInfoService, ShoppingCart shoppingCart, IOrdersService ordersService)
        {
            _busInfoService = busInfoService;
            _shoppingCart = shoppingCart;
            _ordersService = ordersService;
        }

        public async Task <IActionResult> Index ()
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            string userRole = User.FindFirstValue(ClaimTypes.Role);
            var orders = await _ordersService.GetOrdersByUserIdAndRoleAsync(userId, userRole);
            return View(orders);
        }


        public IActionResult ShoppingCart()
        {
            var tickets = _shoppingCart.GetTicketCarts();
            _shoppingCart.TicketCarts = tickets;
            var response = new ShoppingCartVM()
            {
                ShoppingCart = _shoppingCart,
                ShoppingCartTotal = _shoppingCart.GetShoppingCartTotal()
            };

            return View(response);
        }

        public async Task <IActionResult> AddItemToShoppingCart(int id)
        {
            var item = await _busInfoService.GetBusInfoByIdAsync(id);

            if (item != null)
            {
                _shoppingCart.AddTicketToCart(item);
            }
            return RedirectToAction(nameof(ShoppingCart));
        }

        public async Task<IActionResult> RemoveItemFromShoppingCart(int id)
        {
            var item = await _busInfoService.GetBusInfoByIdAsync(id);

            if (item != null)
            {
                _shoppingCart.RemoveTicketFromCart(item);
            }
            return RedirectToAction(nameof(ShoppingCart));
        }


        public async Task <IActionResult> CompleteOrder ()
        {
            var items = _shoppingCart.GetTicketCarts();
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            string userEmailAddress = User.FindFirstValue(ClaimTypes.Email);


            await _ordersService.StoreOrderAsync(items, userId, userEmailAddress);
            await _shoppingCart.ClearShoppingCartAsync();
            return View("OrderCompleted");
        }


    }
}
