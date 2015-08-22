using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStoreService.Models
{
    public class CategoryViewModel
    {
        public CategoryViewModel() { }

        public CategoryViewModel(Category category)
        {
            this.Id = category.Id;
            this.Name = category.Name;
        }

        public int Id { get; set; }

        public string Name { get; set; }
    }
}