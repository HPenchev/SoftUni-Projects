using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BugTracker.RestServices.Models
{
    public class BugBindingModel
    {
        [Required]        
        [Display(Name = "Title")]
        public virtual string Title { get; set; }

        public string Description { get; set; }
    }
}