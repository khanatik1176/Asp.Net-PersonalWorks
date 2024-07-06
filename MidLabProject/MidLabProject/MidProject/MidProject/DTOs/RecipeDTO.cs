using MidProject.EF;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MidProject.DTOs
{
    public class RecipeDTO
    {
        public int Rid { get; set; }
        [Required]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Recipe Title must be Greater than or equal 3")]
        public string RecipeTitle { get; set; }
        [Required]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Recipe Ingredients must be Greater than or equal 3")]
        public string RecipeIngridient { get; set; }
        [Required]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Recipe Instruction must be Greater than or equal 3")]
        public string RecipeInstructions { get; set; }
        public System.DateTime RecipePostTime { get; set; }
        public int Uid { get; set; }

        public virtual ICollection<RecipeRatingDTO> RecipeRatings { get; set; }
        public virtual User UserDTO { get; set; }

    }
}