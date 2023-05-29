using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Payroll_System.DTO_s.RoleDtos;
using Payroll_System.DTO_s.UserDtos;
using Payroll_System.Identity;
using Payroll_System.Interface.Services;

namespace Payroll_System.Implementation.Services
{
    public class UserService : IUserService
    {
        private readonly IUserStore<User> _userRepository;
        private readonly IQueryableUserStore<User> _users;
        private readonly IUserEmailStore<User> _userEmailRepository;
        public UserService(IUserStore<User> userRepository, IQueryableUserStore<User> users, IUserEmailStore<User> userEmailRepository)
        {
            _userRepository = userRepository;
            _users = users;
            _userEmailRepository = userEmailRepository;
        }
        public async Task<LoginResponseModel> Login(LoginRequestModel request, CancellationToken cancellationToken)
        {
            LoginResponseModel loginResponseModel = new();
            var user = await _userEmailRepository.FindByEmailAsync(request.Email, cancellationToken);
            if (user == null) 
            {
                loginResponseModel.Status = false;
                loginResponseModel.Message = "Username or Password Incorrect";
                return loginResponseModel;
            };
            List<Role> roles = new List<Role>();
            foreach (var role in user.UserRoles)
            {
                roles.Add(role.Role);
            }
            if (user != null && request.Email == user.Email)
            {
                loginResponseModel.Data = new LoginResponseData
                {
                    UserId = user.Id,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email,
                   

                };
                loginResponseModel.Message = "Login Succesfull";
                loginResponseModel.Status = true;
                return loginResponseModel;

            };
            loginResponseModel.Status = false;
            loginResponseModel.Message = "Username or Password Incorrect";
            return loginResponseModel;
        }

        public async Task<UserResponseModel> GetById(System.Guid id, CancellationToken cancellationToken)
        {
            UserResponseModel userResponseModel = new();
            var user = await _userRepository.FindByIdAsync(id.ToString(), cancellationToken);
            if (user == null)
            {
                userResponseModel.Status = false;
                userResponseModel.Message = "No User available";
                return userResponseModel;
            };
            UserDto userDto = new();
            userDto.Id = user.Id;
            userDto.FirstName = user.FirstName;
            userDto.LastName = user.LastName;
            userDto.Email = user.Email;
            userResponseModel.Status = true;
            userResponseModel.Message = "User available";
            userResponseModel.Data = userDto;
            return userResponseModel;
        }

        public UsersResponseModel ViewAllUsers()
        {
            UsersResponseModel usersResponseModel = new();
            var users = _users.Users.AsQueryable();
            if (users.Count() < 0)
            {
                usersResponseModel.Status = false;
                usersResponseModel.Message = "No User available";
                return usersResponseModel;
            };
            usersResponseModel.Status = true;
            usersResponseModel.Message = "User available";
            usersResponseModel.Data = users.Select(u => new UserDto
            {
                Id = u.Id,
                FirstName = u.FirstName,
                LastName = u.LastName,
                Email = u.Email,
            }).ToList();

            return usersResponseModel;
        }
    }
}
