using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace CourseProject.DTOs
{
    public class CourseDto
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string CreditHour { get; set; }
        [Required]
        public string Type { get; set; }

    }
}