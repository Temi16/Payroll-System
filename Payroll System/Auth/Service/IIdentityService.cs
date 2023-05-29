using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Threading;
using System.Threading.Tasks;
using Payroll_System.DTO_s.UserDtos;


namespace Payroll_System.Auth.Service
{
    public interface IIdentityService
    {
        string GetUserIdentity();
        string GenerateToken(UserResponseModel user, IList<string> roles);
        JwtSecurityToken GetClaims(string token);
        string GetClaimValue(string type);
        string GenerateSalt();
        string PassWordHash(string password, string salt = null);
        


    }
}
