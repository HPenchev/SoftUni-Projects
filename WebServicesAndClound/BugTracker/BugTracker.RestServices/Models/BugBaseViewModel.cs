using System;

namespace BugTracker.RestServices.Models
{
    public class BugBaseViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Status { get; set; }

        public string Description { get; set; }

        public string Authror { get; set; }

        public DateTime DateCreated { get; set; }
    }
}