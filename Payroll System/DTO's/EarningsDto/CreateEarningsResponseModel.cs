using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Payroll_System.DTO_s.EarningsDto
{
    public class CreateEarningsResponseModel : BaseResponse<Guid>
    {
        public Guid EarningsId { get; set; }
    }
}