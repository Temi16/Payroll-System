using Payroll_System.Contracts;

namespace Payroll_System.Entities
{
    public class Deductions : AuditableEntity
    {
        public Deductions(double pension, double tax, double insurance, double childSupport)
        {
            Pension = pension;
            Tax = tax;
            Insurance = insurance;
            ChildSupport = childSupport;
            CreatedBy = "Admin";
            LastModifiedBy = "Admin";
        }
        public double Pension { get; set; }
        public double Tax { get; set; }
        public double Insurance { get; set; }
        public double ChildSupport { get; set; }
    }
}
