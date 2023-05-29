using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Payroll_System.DTO_s.CadreLevelDto;
using Payroll_System.DTO_s.DeductionsDto;
using Payroll_System.DTO_s.EarningsDto;

namespace Payroll_System.DTO_s.EmployeesDto
{
    public class EmployeeDto
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public CadreLevelResponseModel CadreLevel { get; set; }

    }
}