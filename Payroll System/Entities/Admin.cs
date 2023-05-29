using System;
using Payroll_System.Contracts;
using Payroll_System.Identity;


namespace Payroll_System.Entities
{
    public class Admin : AuditableEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }
    }
}
