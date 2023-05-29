using System;
using Payroll_System.Contracts;

namespace Payroll_System.Identity
{
    public class UserRole : AuditableEntity
    {
        public Guid UserId { get; set; }
        public Guid RoleId { get; set; }
        public User User { get; set; }
        public Role Role { get; set; }
    }
}
