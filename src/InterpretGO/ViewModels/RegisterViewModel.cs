using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace InterpretGO.ViewModels
{
    public class RegisterViewModel
    {
        [Required]
        [Display(Name = "User Name")]
        public string UserName { get; set; }

        [Required]
        [Display (Name = "Name")]
        public string Name { get; set; }

        [Required]
        [Display (Name = "Phone")]
        public string Phone { get; set; }

        [Display (Name = "Specialty")]
        public string Specialty { get; set; }

        [Display (Name = "Certification")]
        public string Certification { get; set; }

        [Display (Name = "Rate")]
        public int Rate { get; set; }

        [Display (Name = "Language")]
        public string Language { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }
}
