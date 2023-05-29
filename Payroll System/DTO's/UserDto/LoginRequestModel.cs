using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payroll_System.DTO_s.UserDtos
{
    public class LoginRequestModel
    {
        [Required]
        public string Email { get; set; }

        //[Required]
        //public string Password { get; set; }
    }
}
