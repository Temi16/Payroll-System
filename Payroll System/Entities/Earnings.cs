using Payroll_System.Contracts;

namespace Payroll_System.Entities
{
    public class Earnings : AuditableEntity
    {
        public Earnings(double basicPay, double transport, double housing, double medical)
        {
            BasicPay = basicPay;
            Transport = transport;
            Housing = housing;
            Medical = medical;
            CreatedBy = "Admin";
            LastModifiedBy = "Admin";
        }

        public double BasicPay { get; set; }
        public double Transport { get; set; }
        public double Housing { get; set; }
        public double Medical { get; set; }
    }
}
