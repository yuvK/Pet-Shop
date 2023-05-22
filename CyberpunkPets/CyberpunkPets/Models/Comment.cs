using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CyberpunkPets.Models
{
    public class Comment
    {
        [Key]
        public int CommentId { get; set; }
        [ForeignKey("AnimalId")]
        [System.ComponentModel.DataAnnotations.Required]
        public int AnimalId { get; set; }
        public Animal? Animal { get; set; }
        [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "Content should have some text..")]
        [MaxLength(50)]
        [StringLength(50, ErrorMessage = ("Comment shold be between 3 and 50 chars"), MinimumLength = 3)]
        public string? Content { get; set; }
    }
}