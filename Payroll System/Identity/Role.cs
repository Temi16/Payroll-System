using System.Collections;
using System.Collections.Generic;
using Payroll_System.Contracts;

namespace Payroll_System.Identity
{
    public class Role : AuditableEntity
    {
        public Role()
        {
            UserRoles = new HashSet<UserRole>();
        }


        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<UserRole> UserRoles { get; set; }
    }
}
