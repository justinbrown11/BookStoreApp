using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookStoreApp.Models
{
    public class Basket
    {
        // List of basket line items
        public List<BasketLineItem> Items { get; set; } = new List<BasketLineItem>();

        // Method to add item to list
        public virtual void AddItem(Book book, int qty)
        {
            // Find book by id in line items
            BasketLineItem line = Items
                .Where(b => b.Book.BookId == book.BookId)
                .FirstOrDefault();

            // If book is not in line items yet, add it
            if (line == null)
            {
                Items.Add(new BasketLineItem
                {
                    Book = book,
                    Quantity = qty
                });
            }

            // Book has already been selected once, increment qty
            else
            {
                line.Quantity += qty;
            }
        }

        // Removes an item
        public virtual void RemoveItem(Book book)
        {
            Items.RemoveAll(x => x.Book.BookId == book.BookId);
        }

        // Clears basket of items
        public virtual void ClearBasket()
        {
            Items.Clear();
        }

        // Calculates total price
        public double CalculateTotal()
        {
            double sum = Items.Sum(x => x.Quantity * x.Book.Price);

            return sum;
        }
    }

    public class BasketLineItem
    {
        [Key]
        public int LineId { get; set; }
        public Book Book { get; set; }
        public int Quantity { get; set; }
    }
}
