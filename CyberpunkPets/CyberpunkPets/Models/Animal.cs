using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CyberpunkPets.Models
{
    public class Animal
    {
        [Key]
        public int AnimalId { get; set; }
        [Required(ErrorMessage = "Enter a name")]
        [Display(Name ="Name: ")]
        public string? Name { get; set; }
        [Range(0, 120, ErrorMessage = "entar a valid age (0 to 120)")]
        [Required(ErrorMessage = "Enter an age")]
        [Display(Name = "Age: ")]
        public int Age { get; set; }
        [Display(Name = "Profile Picture: ")]
        [Required(ErrorMessage = "Please chose an image file")]
        public string? PictureName { get; set; }
        [Required(ErrorMessage ="Enter an animal description")]
        [DataType(DataType.MultilineText)]
        [StringLength(800)]
        [Display(Name = "Description: ")]
        public string? Description { get; set; }
        [Display(Name = "Category: ")]
        public int CategoryId { get; set; }
        public Category? Category { get; set; }
        public ICollection<Comment>? Comments { get; set; }
        [NotMapped]
        public IFormFile? ProfilePic { get; set; }
    }
}
