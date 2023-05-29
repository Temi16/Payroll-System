using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Payroll_System.DTO_s.EmployeesDto
{
    public class EmployeesResponseModel : BaseResponse<List<EmployeeDto>>
    {
        public List<EmployeeDto> Employees { get; set; } = new List<EmployeeDto>();
    }
}