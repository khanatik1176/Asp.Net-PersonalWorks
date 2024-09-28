using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
   public class SubTaskDTO
    {
        public int ST_Id { get; set; }

        public string ST_Name { get; set; }

        public string ST_Description { get; set; }

        public int T_id { get; set; }
    }
}
