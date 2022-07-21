
using EVE.Data.Cart;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EVE.Data.ViewComponents
{
    public class TIcketsCartSummary : ViewComponent
    {
        private readonly ShoppingCart _shoppingCart;
        public TIcketsCartSummary(ShoppingCart shoppingCart)
        {
            _shoppingCart = shoppingCart;
        }

        public IViewComponentResult Invoke()
        {
            var items = _shoppingCart.GetTicketCarts();

            return View(items.Count);
        }
    }
}