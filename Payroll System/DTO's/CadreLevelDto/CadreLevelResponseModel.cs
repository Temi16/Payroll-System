using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Payroll_System.DTO_s.CadreLevelDto
{
    public class CadreLevelResponseModel : BaseResponse<CadreLevelDto>
    {
        public CadreLevelDto CadreLevel { get; set; }
    }
}