using System.Collections.Generic;
using Payroll_System.Contracts;
using Payroll_System.Entities;

namespace Payroll_System.Identity
{
    public class User : AuditableEntity
    {

        public User()
        {
            UserRoles = new HashSet<UserRole>();
        }

        public User(string firstName, string lastName, string email)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            CreatedBy = "Admin";
            LastModifiedBy = "Admin";
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public bool IsEmailConfirmed { get; set; }
        public Admin Admin { get; set; }
        public Employee Employee { get; set; }
        public ICollection<UserRole> UserRoles { get; set; }
    }
}
