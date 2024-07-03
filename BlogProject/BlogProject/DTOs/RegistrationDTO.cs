using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BlogProject.DTOs
{
    public class RegistrationDTO
    {
        [Required]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "User Name must be Greater than or equal 3")]
        public string UserName { get; set; }
        [Required]
        [StringLength(20, MinimumLength = 8 , ErrorMessage ="Password must be Greater than or equal 8")]
        public string UserPassword { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 8, ErrorMessage = "Password must be Greater than or equal 8")]
        [Compare("UserPassword", ErrorMessage = "Confirm password doesn't match, Type again !")]
        public string ConfirmPassword { get; set; }
        public string UserRole { get; set; }
        public string UserStatus { get; set; }

        [Required]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Use letters only please")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Name must contain atleast 3 words")]
   
        public string UserRealName { get; set; }
    }
}