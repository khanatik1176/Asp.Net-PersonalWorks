using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BlogProject.DTOs
{
    public class LoginDTO
    {
        [Required]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "User Name must be Greater than or equal 3")]
        public string UserName { get; set; }
        [Required]
        [StringLength(20, MinimumLength = 8, ErrorMessage = "Password must be Greater than or equal 8")]
        public string UserPassword { get; set; }
        public string UserRole { get; set; }
    }
}