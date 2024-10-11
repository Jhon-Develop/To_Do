using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace To_Do.Models.DTOs
{
    public class RegisterDto
    {
        [Required]
        [MaxLength(100, ErrorMessage = "The username must be less than 100 characters")]
        [MinLength(3, ErrorMessage = "The username must be more than 3 characters")]
        [Display(Name = "Username")]
        public string Username { get; set; }

        [Required]
        [MaxLength(100, ErrorMessage = "The email must be less than 100 characters")]
        [MinLength(3, ErrorMessage = "The email must be more than 3 characters")]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [MaxLength(100, ErrorMessage = "The password must be less than 100 characters")]
        [MinLength(8, ErrorMessage = "The password must be more than 8 characters")]
        [Display(Name = "Password")]
        public string PasswordHash { get; set; }
    }
}