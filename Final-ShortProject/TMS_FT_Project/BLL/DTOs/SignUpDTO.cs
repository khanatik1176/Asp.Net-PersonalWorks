using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class SignUpDTO
    {
        public int UD_id { get; set; }

        public string UD_Name { get; set; }


        public string UD_Email { get; set; }

        public string UD_Address { get; set; }

        public string UD_PhoneNumber { get; set; }

        public string Password { get; set; }
    }
}
