using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Payroll_System.DTO_s.DeductionsDto
{
    public class DeductionDto
    {
        public Guid Id { get; set; }
        public double Pension { get; set; }
        public double Tax { get; set; }
        public double Insurance { get; set; }
        public double ChildSupport { get; set; }
    }
}