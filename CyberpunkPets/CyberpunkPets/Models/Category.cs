using System.ComponentModel.DataAnnotations;

namespace CyberpunkPets.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        [Required(ErrorMessage = ("Please enter a name"))]
        [StringLength(15, ErrorMessage = ("Category name should be between 2 and 15 chars"), MinimumLength = 2)]
        public string? Name { get; set; }
        public ICollection<Animal>? Animals { get; set; }
    }
}