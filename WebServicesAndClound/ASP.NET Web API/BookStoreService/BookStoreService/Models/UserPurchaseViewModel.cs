using BooksShopModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStoreService.Models
{
    public class UserPurchaseViewModel
    {
        public UserPurchaseViewModel() { }

        public UserPurchaseViewModel(Purchase purchase)
        {
            this.BookTitle = purchase.Book.Title;
            this.DateOfPurchase = purchase.DateOfPurchase;
            this.Price = purchase.Price;
            this.IsRecalled = purchase.IsRecalled;
        }

        public string BookTitle { get; set; }

        public decimal Price { get; set; }

        public DateTime DateOfPurchase { get; set; }

        public bool IsRecalled { get; set; }
    }
}