using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Payroll_System.DTO_s.DeductionsDto
{
    public class CreateDeductionsResponseModel : BaseResponse<Guid>
    {
        public Guid DeductionId { get; set; }
    }
}