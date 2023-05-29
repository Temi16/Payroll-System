using Application.DTOs;
using Application.DTOs.RoleDtos;
using Payroll_System.DTO_s.RoleDtos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payroll_System.DTO_s.UserDtos
{
    public class UserDto
    {

        public Guid Id { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
       
      
    }
}