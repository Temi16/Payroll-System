using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Payroll_System.DTO_s.EmployeesDto
{
    public class EmployeeResponseModel : BaseResponse<EmployeeDto>
    {
        public EmployeeDto Employee { get; set; }
    }
}