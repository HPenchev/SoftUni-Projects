namespace StudentSystem
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Homework
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [MinLength(1)]
        public string Content { get; set; }

        [Required]
        public HomeworkType Type { get; set; }

        [Required]
        public DateTime SubmissionDate { get; set; }

        public int CourseId { get; set; }

        public int StudentId { get; set; }

        public virtual Course Course { get; set; }

        public virtual Student Student { get; set; }
    }
}