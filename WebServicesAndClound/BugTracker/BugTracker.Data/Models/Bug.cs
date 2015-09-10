using BugTracker.Data.Models.Enumerations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace BugTracker.Data.Models
{
    public class Bug
    {
        private ICollection<Comment> comments;

        public Bug()
        {
            this.comments = new HashSet<Comment>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        public string Description { get; set; }

        [Required]
        public DateTime PublishDate { get; set; }

        [Required]
        public BugStatus Status { get; set; }

        public User Author { get; set; }

        public ICollection<Comment> Comments
        {
            get
            {
                return this.comments;
            }
            set
            {
                this.comments = value;
            }
        }
    }
}