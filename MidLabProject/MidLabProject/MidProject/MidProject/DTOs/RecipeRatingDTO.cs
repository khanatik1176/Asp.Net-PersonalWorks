using MidProject.EF;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MidProject.DTOs
{
    public class RecipeRatingDTO
    {
        public int RTid { get; set; }
        public int Uid { get; set; }
        public int Rid { get; set; }

        [Required]
        [StringLength(1, MinimumLength = 1, ErrorMessage = "Rating must be equal to 1")]
        public string RecipeRating1 { get; set; }

        public virtual RecipeDTO Recipe { get; set; }
        public virtual UserDTO User { get; set; }
    }
}