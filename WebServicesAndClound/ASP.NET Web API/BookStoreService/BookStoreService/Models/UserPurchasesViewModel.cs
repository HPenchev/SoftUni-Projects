using BooksShopModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStoreService.Models
{
    public class UserPurchasesViewModel
    {
        ICollection<UserPurchaseViewModel> purchases;

        public UserPurchasesViewModel()
        {
            this.purchases = new HashSet<UserPurchaseViewModel>();
        }

        public UserPurchasesViewModel(ApplicationUser user)
            : this()
        {
            this.Username = user.UserName;

            foreach (Purchase purchase in user.Purchases)
            {
                this.purchases.Add(new UserPurchaseViewModel(purchase));
            }
        }


        public string Username { get; set; }

        public ICollection<UserPurchaseViewModel> Purchases
        {
            get
            {
                return this.purchases;
            }

            set
            {
                this.purchases = value;
            }
        }
    }
}