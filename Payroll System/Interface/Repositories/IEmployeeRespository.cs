using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using Payroll_System.Entities;

namespace Payroll_System.Interface.Repositories
{
    public interface IEmployeeRespository : IRepository
    {
        Task<Employee> GetEmployee(Expression<Func<Employee, bool>> expression, bool AsNoTracking = true, CancellationToken cancellationToken = default);
        Task<IEnumerable<Employee>> GetAllEmployee(Expression<Func<Employee, bool>> expression, bool AsNoTracking = true, CancellationToken cancellationToken = default);

        Task<IEnumerable<Employee>> GetAllEmployee();
    }
}
