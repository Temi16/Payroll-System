using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Payroll_System.DTO_s.EarningsDto
{
    public class EarningsResponseModel : BaseResponse<EarningDto>
    {
        public EarningDto Earning { get; set; }
    }
}