using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksShopModels
{
    public class Purchase
    {
        [Key]
        public  int Id { get; set; }

        public decimal Price { get; set; }

        public DateTime DateOfPurchase { get; set; }

        //public int UserId { get; set; }

        public bool IsRecalled { get; set; }

        public int BookId { get; set; }

        public virtual ApplicationUser User { get; set; }

        public virtual Book Book { get; set; }
    }
}
