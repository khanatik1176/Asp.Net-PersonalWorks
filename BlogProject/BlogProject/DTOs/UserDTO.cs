using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlogProject.DTOs
{
    public class UserDTO
    {
        public int Uid { get; set; }
        public string UserName { get; set; }
        public string UserRole { get; set; }
        public string UserStatus { get; set; }
        public string UserRealName { get; set; }

        public virtual ICollection<CommentDTO> Comments { get; set; }

        public virtual ICollection<PostLikeDTO> PostLikes { get; set; }

        public virtual ICollection<PostDTO> Posts { get; set; }

        public UserDTO()
        {
            Comments = new List<CommentDTO>();
            PostLikes = new List<PostLikeDTO>();
            Posts = new List<PostDTO>();
        }



    }
}