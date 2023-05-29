using Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payroll_System.DTO_s.UserDtos
{
    public class LoginResponseModel : BaseResponse<LoginResponseData>
    {
        public LoginResponseData Data { get; set; }
    }
}
