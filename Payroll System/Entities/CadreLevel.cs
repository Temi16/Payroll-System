using System;
using System.Collections.Generic;
using Payroll_System.Contracts;

namespace Payroll_System.Entities
{
    public class CadreLevel : AuditableEntity
    {
        public CadreLevel()
        {
            Employees = new HashSet<Employee>();
           
        }
        public CadreLevel(string cadreName, Guid earningsId, Guid deductionsId, double salary)
        {
            CadreName = cadreName;
            EarningsId = earningsId;
            DeductionsId = deductionsId;
            Salary = salary;
            CreatedBy = "Admin";
            LastModifiedBy = "Admin";
        }
        public string CadreName { get; set; }
        public Guid EarningsId { get; set; }
        public Earnings Earnings { get; set; }
        public Guid DeductionsId { get; set; }
        public Deductions Deductions { get; set; }
        public double Salary { get; set; }
        public ICollection<Employee> Employees { get; set; }
    }
}
