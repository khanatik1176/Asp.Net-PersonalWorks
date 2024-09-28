using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.TableModels
{
   public class Task
    {
        [Key]
        public int Tid { get; set; }

        [Required]
        [StringLength(20)]
        [Column(TypeName = "VARCHAR")]
        public string T_Name { get; set; }

        [Required]
        [StringLength(50)]
        [Column(TypeName = "VARCHAR")]
        public string T_Description { get; set; }
        [Required]
        public DateTime T_Complete_Date { get; set; }

        [Column(TypeName = "VARCHAR")]
        public string T_Status { get; set; }

        public virtual ICollection<Subtask> Subtasks { get; set; }

        public Task()
        {
            Subtasks = new List<Subtask>();
        }

        public virtual User User { get; set; }

        [ForeignKey("User")]
        public string UserEmail { get; set; }

        public virtual Category Category { get; set; }

        [ForeignKey("Category")]
        public string C_Name { get; set; }
    }
}
