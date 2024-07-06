using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MidProject.DTOs
{
    public class RegistrationDTO
    {
        public int Uid { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "User Name must be Greater than or equal to 3")]
        public string UserName { get; set; }
        [Required]
        [EmailAddress]
        public string UserEmail { get; set; }
        [Required]
        [StringLength(20, MinimumLength = 5, ErrorMessage = "Address must be Greater than or equal to 5")]
        public string UserAddress { get; set; }
        [Required]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "Phone Number must be equal to 11")]
        public string UserPhoneNumber { get; set; }
        public string UserRole { get; set; }
        public string UserStatus { get; set; }
        [Required]
        [StringLength(20, MinimumLength = 8, ErrorMessage = "Password must be Greater than or equal to 8")]
        public string UserPassword { get; set; }
        [Required]
        [StringLength(20, MinimumLength = 8, ErrorMessage = " Confirm Password must be Greater than or equal to 8")]
        public string ConfirmPassword { get; set; }
    }
}