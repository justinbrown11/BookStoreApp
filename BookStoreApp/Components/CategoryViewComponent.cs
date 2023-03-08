using Microsoft.AspNetCore.Mvc;
using BookStoreApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStoreApp.Components
{
    public class CategoryViewComponent : ViewComponent
    {
        private IBookStoreRepository repo { get; set; }

        public CategoryViewComponent(IBookStoreRepository temp)
        {
            repo = temp;
        }

        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedType = RouteData?.Values["bookCategory"];

            var types = repo.Books
                .Select(x => x.Category)
                .Distinct()
                .OrderBy(x => x);

            return View(types);
        }
    }
}
