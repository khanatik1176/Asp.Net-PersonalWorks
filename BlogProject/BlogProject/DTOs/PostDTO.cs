using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BlogProject.DTOs
{
    public class PostDTO
    {
        public int Pid { get; set; }
        [Required]
        [StringLength(20,ErrorMessage ="Title Must be within 20 words")]
        public string PostTitle { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "Content Must be within 50 words")]
        public string PostContent { get; set; }
        public int Uid { get; set; }

        public virtual ICollection<CommentDTO> Comments { get; set; }

        public virtual ICollection<PostLikeDTO> PostLikes { get; set; }

        public virtual ICollection<PostTagDTO> PostTags { get; set; }

        public virtual UserDTO User { get; set; }

        public PostDTO()
        {
            Comments = new List<CommentDTO>();
            PostLikes = new List<PostLikeDTO>();
            PostTags = new List<PostTagDTO>();
        }
    }
}