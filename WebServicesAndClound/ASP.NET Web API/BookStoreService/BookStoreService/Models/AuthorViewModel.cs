using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStoreService.Models
{
    public class AuthorViewModel
    {
        //private ICollection<string> books;

        public AuthorViewModel()
        {
           // this.books = new HashSet<string>();
        }

        public AuthorViewModel(Author author)            
        {
            this.Id = author.Id;
            this.FirstName = author.FirstName;
            this.LastName = author.LastName;            
        }

        public int Id { get; set; }

        public string FirstName { get; set; }
     
        public string LastName { get; set; }

        //public ICollection<string> Books { get; set; }
    }
}