using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Payroll_System.DTO_s.EarningsDto
{
    public class EarningsResponsesModel : BaseResponse<List<EarningDto>>
    {
        public List<EarningDto> Earnings { get; set; } = new List<EarningDto>();
    }
}