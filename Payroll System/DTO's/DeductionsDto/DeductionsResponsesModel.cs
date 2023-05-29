using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Payroll_System.DTO_s.DeductionsDto
{
    public class DeductionsResponsesModel : BaseResponse<List<DeductionDto>>
    {
        public List<DeductionDto> Deductions { get; set; } = new List<DeductionDto>();
    }
}