using System.ComponentModel.DataAnnotations;

public class News
{
    [Required]
    public int Id { get; set; }

    [Required]
    [MinLength(1)]
    public string NewsContent { get; set; }
}