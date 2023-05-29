using System;
using System.Threading;
using System.Threading.Tasks;
using Payroll_System.DTO_s.UserDtos;

namespace Payroll_System.Interface.Services
{
    public interface IUserService
    {
        Task<LoginResponseModel> Login(LoginRequestModel model, CancellationToken cancellationToken);
        Task<UserResponseModel> GetById(Guid id, CancellationToken cancellationToken);
        UsersResponseModel ViewAllUsers();
    }
}
