using System.Linq;
using System.Threading.Tasks;
using Payroll_System.Entities;
using Payroll_System.Interface.Repositories;
using Payroll_System.Interface.Services;
using Payroll_System.DTO_s.EmployeesDto;
using Payroll_System.Identity;
using Microsoft.AspNetCore.Identity;
using System.Threading;
using Payroll_System.DTO_s.CadreLevelDto;
using Payroll_System.DTO_s.EarningsDto;
using Payroll_System.DTO_s.DeductionsDto;
using System;

namespace Payroll_System.Implementation.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRespository _employeeRepository;
        private readonly IUserStore<User> _userRepository;
        public EmployeeService(IEmployeeRespository employeeRepository, IUserStore<User> userRepository)
        {
            _employeeRepository = employeeRepository;
            _userRepository = userRepository;
            
        }


        public async Task<CreateEmployeeResponseModel> CreateEmployee(CreateEmployeeRequestModel model, CancellationToken cancellationToken)
        {
            CreateEmployeeResponseModel createEmployeeResponseModel = new();
            var checkEmployeeExist = await _employeeRepository.ExistsAsync<Employee>(e => e.Email == model.Email);
            if (checkEmployeeExist)
            {
                createEmployeeResponseModel.Status = false;
                createEmployeeResponseModel.Message = "Employee already exist";
                createEmployeeResponseModel.ValidationResults.Add("Employee already exist");

                return createEmployeeResponseModel;

            }
            var user = new User(model.FirstName, model.LastName, model.Email);
            await _userRepository.CreateAsync(user, cancellationToken);
            var employee = new Employee(model.FirstName, model.LastName, model.Age, model.PhoneNumber, model.Email, model.CadreLevelId, user.Id);
            var employeeId = await _employeeRepository.CreateAsync<Employee>(employee);
            await _employeeRepository.SaveChangesAsync();
            createEmployeeResponseModel.Status = true;
            createEmployeeResponseModel.Message = "Employee created successfully";
            createEmployeeResponseModel.ValidationResults.Add("Employee created successfully");
            createEmployeeResponseModel.EmployeeId = employeeId;

            return createEmployeeResponseModel;

        }

        public async Task<EmployeeResponseModel> GetById(Guid id)
        {
            EmployeeResponseModel employeeResponseModel = new();
            var employee = await _employeeRepository.GetEmployee(e => e.Id == id);
            if (employee == null)
            {
                employeeResponseModel.Status = false;
                employeeResponseModel.Message = "No Employee available";
                return employeeResponseModel;
            };
            EmployeeDto employeeDto = new();
            employeeDto.Id = employee.Id;
            employeeDto.FirstName = employee.FirstName;
            employeeDto.LastName = employee.LastName;
            employeeDto.PhoneNumber = employee.PhoneNumber;
            employeeDto.Age = employee.Age;
            employeeDto.Email = employee.Email;
            employeeDto.CadreLevel = new CadreLevelResponseModel
            {
                CadreLevel = new CadreLevelDto
                {
                    Id = employee.CadreLevelId,
                    CadreName = employee.CadreLevel.CadreName,
                    Salary = employee.CadreLevel.Salary,
                    Earnings = new EarningDto
                    {
                        Id = employee.CadreLevelId,
                        BasicPay = employee.CadreLevel.Earnings.BasicPay,
                        Transport = employee.CadreLevel.Earnings.Transport,
                        Housing = employee.CadreLevel.Earnings.Housing,
                        Medical = employee.CadreLevel.Earnings.Medical

                    },
                    Deductions = new DeductionDto
                    {
                        Id = employee.CadreLevel.DeductionsId,
                        Pension = employee.CadreLevel.Deductions.Pension,
                        Tax = employee.CadreLevel.Deductions.Tax,
                        ChildSupport = employee.CadreLevel.Deductions.ChildSupport,
                        Insurance = employee.CadreLevel.Deductions.Insurance
                    }
                }
            };
            employeeResponseModel.Status = true;
            employeeResponseModel.Message = "Employee available";
            employeeResponseModel.Employee = employeeDto;
            return employeeResponseModel;
        }

        public async Task<EmployeesResponseModel> ViewAllEmployees()
        {
            EmployeesResponseModel employeesResponseModel = new();
            var employees = await _employeeRepository.GetAllEmployee();
            if (employees.Count() < 0)
            {
                employeesResponseModel.Status = false;
                employeesResponseModel.Message = "No Employee available";
                return employeesResponseModel;
            };
            employeesResponseModel.Status = true;
            employeesResponseModel.Message = "Employee available";
            employeesResponseModel.Employees = employees.Select(e => new EmployeeDto
            {
                Id = e.Id,
                FirstName = e.FirstName,
                LastName = e.LastName,
                Age = e.Age,
                Email = e.Email,
                PhoneNumber = e.PhoneNumber,
                CadreLevel = new CadreLevelResponseModel
                {
                    CadreLevel = new CadreLevelDto
                    {
                        Id = e.CadreLevelId,
                        CadreName = e.CadreLevel.CadreName,
                        Salary = e.CadreLevel.Salary,
                        Earnings = new EarningDto
                        {
                            Id = e.CadreLevelId,
                            BasicPay = e.CadreLevel.Earnings.BasicPay,
                            Transport = e.CadreLevel.Earnings.Transport,
                            Housing = e.CadreLevel.Earnings.Housing,
                            Medical = e.CadreLevel.Earnings.Medical

                        },
                        Deductions = new DeductionDto
                        {
                            Id = e.CadreLevel.DeductionsId,
                            Pension = e.CadreLevel.Deductions.Pension,
                            Tax = e.CadreLevel.Deductions.Tax,
                            ChildSupport = e.CadreLevel.Deductions.ChildSupport,
                            Insurance = e.CadreLevel.Deductions.Insurance
                        }
                    }
                }
            }).ToList();

            return employeesResponseModel;
        }

        public async Task<EmployeesResponseModel> ViewAllEmployeesByCadreLevel(Guid cadreLevelId)
        {
            EmployeesResponseModel employeesResponseModel = new();
            var employees = await _employeeRepository.GetAllEmployee(e => e.CadreLevelId == cadreLevelId);
            if (employees.Count() < 0)
            {
                employeesResponseModel.Status = false;
                employeesResponseModel.Message = "No Employee available";
                return employeesResponseModel;
            };
            employeesResponseModel.Status = true;
            employeesResponseModel.Message = "Employee available";
            employeesResponseModel.Employees = employees.Select(e => new EmployeeDto
            {
                Id = e.Id,
                FirstName = e.FirstName,
                LastName = e.LastName,
                Age = e.Age,
                Email = e.Email,
                PhoneNumber = e.PhoneNumber,
                CadreLevel = new CadreLevelResponseModel
                {
                    CadreLevel = new CadreLevelDto
                    {
                        Id = e.CadreLevelId,
                        CadreName = e.CadreLevel.CadreName,
                        Salary = e.CadreLevel.Salary,
                        Earnings = new EarningDto
                        {
                            Id = e.CadreLevelId,
                            BasicPay = e.CadreLevel.Earnings.BasicPay,
                            Transport = e.CadreLevel.Earnings.Transport,
                            Housing = e.CadreLevel.Earnings.Housing,
                            Medical = e.CadreLevel.Earnings.Medical

                        },
                        Deductions = new DeductionDto
                        {
                            Id = e.CadreLevel.DeductionsId,
                            Pension = e.CadreLevel.Deductions.Pension,
                            Tax = e.CadreLevel.Deductions.Tax,
                            ChildSupport = e.CadreLevel.Deductions.ChildSupport,
                            Insurance = e.CadreLevel.Deductions.Insurance
                        }
                    }
                }
            }).ToList();

            return employeesResponseModel;
        }
    }
}
