using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BugTracker.RestServices.Models
{
    public class BugDetailedViewModel : BugBaseViewModel
    {
        public BugDetailedViewModel()
        {
            this.Comments = new SortedSet<CommentViewModel>(Comparer<CommentViewModel>.Create(
                    (a, b) => b.Author.CompareTo(a.DateCreated)));
        }

        public ICollection<CommentViewModel> Comments { get; set; }
    }
}