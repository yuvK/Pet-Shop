
using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations;

namespace CyberpunkPets.Models
{
    public class LoginModel
    {
        [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "Enter a name")]
        [Display(Name = "Name: ")]
        public string? Username { get; set; }
        [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "Enter a valid Password")]
        [Display(Name = "Password: ")]
        public string? Password { get; set; }
    }
}
