using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlogProject.DTOs
{
    public class PostLikeDTO
    {
        public int PLid { get; set; }
        public int Pid { get; set; }
        public int Uid { get; set; }
        public System.DateTime Time { get; set; }
    }
}