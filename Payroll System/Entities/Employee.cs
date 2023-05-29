using System;
using Payroll_System.Contracts;
using Payroll_System.Identity;


namespace Payroll_System.Entities
{
    public class Employee : AuditableEntity
    {

        public Employee(string firstName, string lastName, int age, string phoneNumber, string email, Guid cadreLevelId, Guid userId)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            PhoneNumber = phoneNumber;
            Email = email;
            CadreLevelId = cadreLevelId;
            UserId = userId;
            CreatedBy = "Admin";
            LastModifiedBy = "Admin";
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public Guid CadreLevelId { get; set; }
        public CadreLevel CadreLevel { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }
    }
}
