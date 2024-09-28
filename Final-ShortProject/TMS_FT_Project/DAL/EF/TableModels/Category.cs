using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.TableModels
{
    public class Category
    {
      
        public int Cid { get; set; }

        [Key]
        [Required]
        [StringLength(20)]
        [Column(TypeName = "VARCHAR")]
        public string C_Name { get; set; }

        public virtual ICollection<Task> Tasks { get; set; }

        public Category()
        {
            Tasks = new List<Task>();
        }

    }
}
