using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Rating
{
    [Key, Column(Order = 0)]
    public int UserId { get; set; }

    [Key, Column(Order = 1)]
    public int MovieId { get; set; }

    public virtual User User { get; set; }
    
    public virtual Movie Movie { get; set; }

    [Range(0, 10)]
    public int Stars { get; set; }
}