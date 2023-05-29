using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Payroll_System.DTO_s.EmployeesDto
{
    public class CreateEmployeeResponseModel : BaseResponse<Guid>
    {
        public Guid EmployeeId { get; set; }
    }
}