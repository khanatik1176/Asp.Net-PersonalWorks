using MidProject.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MidProject.DTOs
{
    public class UserDTO
    {
        public int Uid { get; set; }
        public string UserName { get; set; }
        public string UserEmail { get; set; }
        public string UserAddress { get; set; }
        public string UserPhoneNumber { get; set; }
        public string UserRole { get; set; }
        public string UserStatus { get; set; }

        public virtual ICollection<RecipeRatingDTO> RecipeRatings { get; set; }
        public virtual ICollection<RecipeDTO> Recipes { get; set; }

        public UserDTO()
        {

        }
    }
}