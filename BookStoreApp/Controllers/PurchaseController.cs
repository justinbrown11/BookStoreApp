using BookStoreApp.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStoreApp.Controllers
{
    public class PurchaseController : Controller
    {
        // Purchase repo
        private IPurchaseRepository repo { get; set; }
        private Basket basket { get; set; }

        // Instatiation for repo and basket
        public PurchaseController(IPurchaseRepository temp, Basket b)
        {
            repo = temp;
            basket = b;
        }

        [HttpGet]
        public IActionResult Checkout()
        {
            return View(new Purchase()); // Return form
        }

        [HttpPost]
        public IActionResult Checkout(Purchase purchase)
        {
            // If there are no basket items, the cart is empty, throw error
            if (basket.Items.Count() == 0)
            {
                ModelState.AddModelError("", "Sorry your cart is empty!");
            }

            // Check model state
            if (ModelState.IsValid)
            {
                // Add basket items to purchase lines and clear the current basket
                purchase.Lines = basket.Items.ToArray();
                repo.SavePurchase(purchase);
                basket.ClearBasket();

                return RedirectToPage("/PurchaseCompleted");
            }

            else
            {
                return View();
            }
        }
    }
}
