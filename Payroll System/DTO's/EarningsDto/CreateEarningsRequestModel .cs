using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Payroll_System.DTO_s.EarningsDto
{ 
    public class CreateEarningsRequestModel
    {
        public double BasicPay { get; set; }
        public double Transport { get; set; }
        public double Housing { get; set; }
        public double Medical { get; set; }

    }
}