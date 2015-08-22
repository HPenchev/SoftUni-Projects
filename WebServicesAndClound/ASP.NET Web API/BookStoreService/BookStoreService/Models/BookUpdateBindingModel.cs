using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BookStoreService.Models
{
    public class BookUpdateBindingModel
    {
        //[Required]
        [StringLength(50, ErrorMessage = "The {0} must be between {2} and {1} characters long.", MinimumLength = 1)]
        [Display(Name = "Book title")]
        public string Title { get; set; }

        [StringLength(50, ErrorMessage = "The {0} must be no more than {1} characters long.", MinimumLength = 1)]
        [Display(Name = "Book description")]
        public string Description { get; set; }

        //[Required]
        [Range(0, (double)decimal.MaxValue, ErrorMessage = "The {0} can't be less than {1}")]
        [Display(Name = "Price")]
        public decimal Price { get; set; }

        //[Required]
        [Range(0, int.MaxValue, ErrorMessage = "The {0} can't be less than {1}")]
        [Display(Name = "Copies")]
        public int Copies { get; set; }

        //[Required]
        public EditionType Edition { get; set; }

        public DateTime? ReleaseDate { get; set; }

        //[Required]
        public AgeRestriction AgeRestriction { get; set; }

        //[Required]
        public int AuthorId { get; set; }
    }
}