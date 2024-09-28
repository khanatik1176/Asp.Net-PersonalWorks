using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.TableModels
{
    public class UserDetails
    {
        [Key]
        public int UD_id { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR")]
        [StringLength(20)]
        public string UD_Name { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR")]
        [EmailAddress]
        public string UD_Email { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR")]
        [StringLength(50)]
        public string UD_Address { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR")]
        [StringLength(11)]
        public string UD_PhoneNumber { get; set; }
    }
}
