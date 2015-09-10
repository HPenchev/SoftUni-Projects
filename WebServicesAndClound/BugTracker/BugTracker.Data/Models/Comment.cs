using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace BugTracker.Data.Models
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Text { get; set; }

        [Required]
        public DateTime PublishDate { get; set; }

        public User Author { get; set; }

        [Required]
        [ForeignKey("Bug")]
        public  int BugId { get; set; }

        [InverseProperty("Comments")]
        public Bug Bug { get; set; }
    }
}