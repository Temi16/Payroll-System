using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Payroll_System.DTO_s.CadreLevelDto
{
    public class CreateCadreLevelResponseModel : BaseResponse<Guid>
    {
        public Guid CadreLevelId { get; set; }
    }
}