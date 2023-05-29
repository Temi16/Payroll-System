using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Payroll_System.DTO_s.DeductionsDto;
using Payroll_System.DTO_s.EarningsDto;

namespace Payroll_System.DTO_s.CadreLevelDto
{
    public class CreateCadreLevelRequestModel
    {
        public string? CadreName { get; set; }
        public CreateEarningsRequestModel Earnings { get; set; }
        public CreateDeductionsRequestModel Deductions { get; set; }
        public double Salary { get; set; }

    }
}