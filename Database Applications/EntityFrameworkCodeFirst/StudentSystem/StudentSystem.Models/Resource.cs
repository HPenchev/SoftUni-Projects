namespace StudentSystem
{    
    using System.ComponentModel.DataAnnotations;

    public class Resource
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public TypeOfResource Type { get; set; }

        [Required]
        public string Url { get; set; }

        public int CourseId { get; set; }

        public virtual Course Course { get; set; }
    }
}