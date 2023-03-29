using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace BookStoreApp.Models
{
    public partial class BookstoreContext : DbContext
    {
        public BookstoreContext()
        {
        }

        public BookstoreContext(DbContextOptions<BookstoreContext> options)
            : base(options)
        {
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Purchase> Purchases { get; set; }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            // Seed books
            mb.Entity<Book>().HasData(
                new Book
                {
                    BookId = 1,
                    Title = "Les Miserables",
                    Author = "Victor Hugo",
                    Publisher = "Signet",
                    Isbn = "978-0451419439",
                    Classification = "Fiction",
                    Category = "Classic",
                    PageCount = 1488,
                    Price = 9.95
                },
                new Book
                {
                    BookId = 2,
                    Title = "Team of Rivals",
                    Author = "Doris Kearns Goodwin",
                    Publisher = "Simon & Schuster",
                    Isbn = "978-0743270755",
                    Classification = "Non-Fiction",
                    Category = "Biography",
                    PageCount = 944,
                    Price = 14.58
                },
                new Book
                {
                    BookId = 3,
                    Title = "The Snowball",
                    Author = "Alice Schroeder",
                    Publisher = "Bantam",
                    Isbn = "978-0553384611",
                    Classification = "Non-Fiction",
                    Category = "Biography",
                    PageCount = 832,
                    Price = 14.58
                },
                new Book
                {
                    BookId = 4,
                    Title = "American Ulysses",
                    Author = "Ronald C. White",
                    Publisher = "Random House",
                    Isbn = "978-0812981254",
                    Classification = "Non-Fiction",
                    Category = "Biography",
                    PageCount = 864,
                    Price = 21.54
                },
                new Book
                {
                    BookId = 5,
                    Title = "Unbroken",
                    Author = "Laura Hillenbrand",
                    Publisher = "Random House",
                    Isbn = "978-0812974492",
                    Classification = "Non-Fiction",
                    Category = "Historical",
                    PageCount = 528,
                    Price = 13.33
                }
            );
        }
    }
}
