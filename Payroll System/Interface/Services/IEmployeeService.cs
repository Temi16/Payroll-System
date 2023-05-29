using System;
using System.Threading;
using System.Threading.Tasks;
using Payroll_System.DTO_s.EmployeesDto;

namespace Payroll_System.Interface.Services
{
    public interface IEmployeeService
    {
        Task<CreateEmployeeResponseModel> CreateEmployee(CreateEmployeeRequestModel model, CancellationToken cancellationToken);
        Task<EmployeeResponseModel> GetById(Guid id);
        Task<EmployeesResponseModel> ViewAllEmployees();
        Task<EmployeesResponseModel> ViewAllEmployeesByCadreLevel(Guid cadreLevelId);
    }
}
