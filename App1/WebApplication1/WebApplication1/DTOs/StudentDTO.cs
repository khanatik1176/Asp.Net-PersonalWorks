using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.DTOs
{
    public class StudentDTO
    {
        public int id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }

        public string Email { get; set; }

        public string Address { get; set; }
    }
}