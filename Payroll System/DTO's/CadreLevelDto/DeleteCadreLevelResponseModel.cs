using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Payroll_System.DTO_s.CadreLevelDto
{
    public class DeleteCadreLevelResponseModel : BaseResponse<bool>
    {
        public bool IsDeleted { get; set; } = false;
    }
}