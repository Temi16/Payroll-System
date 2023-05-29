using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Payroll_System.DTO_s.DeductionsDto
{
    public class DeductionsResponseModel : BaseResponse<DeductionDto>
    {
        public DeductionDto Deduction { get; set; }
    }
}