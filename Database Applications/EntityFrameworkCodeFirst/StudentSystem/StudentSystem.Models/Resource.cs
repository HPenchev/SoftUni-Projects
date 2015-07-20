namespace StudentSystem
{    
    using System.ComponentModel.DataAnnotations;

    public class Resource
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [MinLength(1)]
        public string Name { get; set; }

        [Required]
        public TypeOfResource Type { get; set; }

        [Required]
        [MinLength(1)]
        public string Url { get; set; }

        public int CourseId { get; set; }

        public virtual Course Course { get; set; }
    }
}