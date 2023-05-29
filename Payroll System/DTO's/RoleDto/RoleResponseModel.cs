using Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payroll_System.DTO_s.RoleDtos
{
    public class RoleResponseModel : BaseResponse<RoleDto>
    {
        public RoleDto Data { get; set; }
    }
}
