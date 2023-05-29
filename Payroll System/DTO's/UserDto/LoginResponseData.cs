using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payroll_System.DTO_s.UserDtos
{
    public class LoginResponseData
    {
        public Guid UserId { get; set; }
        public string Email { get; set; }
       
        public DateTimeOffset Expiry { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        //public IEnumerable<string> Roles { get; set; } = new List<string>();

    }
}
