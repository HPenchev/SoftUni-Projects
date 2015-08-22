using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStoreService.Models
{
    public class BookViewModel
    {
        private ICollection<string> categories;

        public BookViewModel()
        {
            this.categories = new HashSet<string>();
        }

        public BookViewModel(Book book) : this()
        {            
            this.Id = book.Id;
            this.Title = book.Title;
            this.Price = book.Price;
            this.Copies = book.Copies;
            this.Edition = book.Edition.ToString();
            this.ReleaseDate = book.ReleaseDate;
            this.AgeRestriction = book.AgeRestriction.ToString();
            this.Author = new AuthorViewModel() { FirstName = book.Author.FirstName,
            LastName = book.Author.LastName,
            Id = book.Author.Id};
            foreach (var category in book.Categories)
            {
                this.categories.Add(category.Name);
            }
        }

        public int Id { get; set; }
           
        public string Title { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public int Copies { get; set; }

        public string Edition { get; set; }

        public DateTime? ReleaseDate { get; set; }

        public string AgeRestriction { get; set; }

        public AuthorViewModel Author { get; set; }

        public ICollection<string> Categories
        {
            get
            {
                return this.categories;
            }

            set
            {
                this.categories = value;
            }
        }
    }
}