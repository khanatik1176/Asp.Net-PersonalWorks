using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.TableModels
{
   public class User
    {
        public int Uid { get; set; }

        [Key]
        [Required]
        [Column(TypeName = "VARCHAR")]
        [EmailAddress]
        public string UserEmail { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR")]
        public string UserPassword { get; set; }

        public string Role { get; set; }

        public virtual UserDetails UserDetails { get; set; }

        [ForeignKey("UserDetails")]
        public int UD_id { get; set; }
    }
}
