using System.ComponentModel.DataAnnotations;
namespace BookOrder.Models;
public class Book
{
    [Key]
    public int Id { get; set; } = 1;
    [Required]
    public string Title { get; set; } = string.Empty;
    [Required]
    public string Author { get; set; } = string.Empty;
    [Required]
    public double Price { get; set; } = 0.0;
    [Required]
    public DateTime PublishedDate { get; set; } = DateTime.Now;
}
