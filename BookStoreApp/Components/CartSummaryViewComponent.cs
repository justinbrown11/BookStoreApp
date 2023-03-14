using BookStoreApp.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStoreApp.Components
{
    // For the cart view at the top of page
    public class CartSummaryViewComponent : ViewComponent
    {
        // Declare basket
        private Basket basket;

        // Instantiate basket
        public CartSummaryViewComponent(Basket b)
        {
            basket = b;
        }
        
        // Return view
        public IViewComponentResult Invoke()
        {
            return View(basket);
        }
    }
}
