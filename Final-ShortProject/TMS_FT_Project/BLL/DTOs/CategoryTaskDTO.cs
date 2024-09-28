using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class CategoryTaskDTO : CategoryDTO
    {
        public List<TaskDTO> Tasks { get; set; }

        public CategoryTaskDTO()
        {
            Tasks = new List<TaskDTO>();
        }
    }
}
