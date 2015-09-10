using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BugTracker.RestServices.Models
{
    public class CommentDetailedViewModel : CommentViewModel
    {
        public int BugId { get; set; }

        public string BugTitle { get; set; }
    }
}