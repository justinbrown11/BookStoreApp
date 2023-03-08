using BookStoreApp.Models;
using BookStoreApp.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStoreApp.Controllers
{
    public class HomeController : Controller
    {
        private IBookStoreRepository repo;

        public HomeController(IBookStoreRepository temp) => repo = temp; 

        public IActionResult Index(string bookCategory, int pageNum = 1)
        {
            int pageSize = 10; // Set page size of 10

            // Grab Books according to page information
            var x = new BooksViewModel
            {
                Books = repo.Books
                    .Where(b => b.Category == bookCategory || bookCategory == null)
                    .OrderBy(b => b.Title) // Order by book title
                    .Skip((pageNum - 1) * pageSize)
                    .Take(pageSize),

                PageInfo = new PageInfo
                {
                    TotalNumBooks = bookCategory == null ? repo.Books.Count() : repo.Books.Where(b => b.Category == bookCategory).Count(),
                    BooksPerPage = pageSize,
                    CurrentPage = pageNum
                }
            };

            return View(x);
        }
    }
}
