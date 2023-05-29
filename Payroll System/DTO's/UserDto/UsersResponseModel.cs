using Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payroll_System.DTO_s.UserDtos
{
    public class UsersResponseModel : BaseResponse<List<UserDto>>
    {
        public List<UserDto> Data { get; set; } = new List<UserDto>();
    }
}
