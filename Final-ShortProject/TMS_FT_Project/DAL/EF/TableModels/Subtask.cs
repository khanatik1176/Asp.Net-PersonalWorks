using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.TableModels
{
   public class Subtask
    {
        [Key]
        public int ST_id { get; set; }

        [Required]
        [StringLength(20)]
        [Column(TypeName = "VARCHAR")]
        public string ST_Name { get; set; }

        [Required]
        [StringLength(50)]
        [Column(TypeName = "VARCHAR")]
        public string ST_Description { get; set; }

        public virtual Task Task { get; set; }

        [ForeignKey("Task")]
        public int T_id { get; set; }

    }
}
