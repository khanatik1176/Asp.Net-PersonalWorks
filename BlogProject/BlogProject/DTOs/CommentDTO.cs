using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BlogProject.DTOs
{
    public class CommentDTO
    {
        public int Cid { get; set; }
        public int Uid { get; set; }
        public int Pid { get; set; }
        public System.DateTime Time { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Comments Must be within 50 words")]
        public string Comment1 { get; set; }
    }
}