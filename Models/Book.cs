using System.ComponentModel.DataAnnotations;
namespace BookOrder.Models;
public class Book
{
    [Key]
    public int Id { get; set; }
    [Required]
    public string Title { get; set; } 
    [Required]
    public string Author { get; set; } 
    [Required]
    public double Price { get; set; } = 0.0;
    [Required]
    public DateTime PublishedDate { get; set; } = DateTime.Now;
}
