using System.ComponentModel.DataAnnotations;
namespace BookOrder.Dtos
{
    public class UpdateBookDto
    {
        [Required]  
        public string Title { get; set; } = string.Empty!;
        [Required]
        public string Author { get; set; } = string.Empty!;
        [Required]
        public double Price { get; set; } = 0.0;
        [Required]
        public DateTime PublishedDate { get; set; } = DateTime.Now;
    }
}

