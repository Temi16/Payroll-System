using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using Payroll_System.Entities;

namespace Payroll_System.Interface.Repositories
{
    public interface IDeductionRepository : IRepository
    {
        Task<Deductions> GetDeductions(Expression<Func<Deductions, bool>> expression, bool AsNoTracking = true, CancellationToken cancellationToken = default);
        Task<IEnumerable<Deductions>> GetAllDeductions(Expression<Func<Deductions, bool>> expression, bool AsNoTracking = true, CancellationToken cancellationToken = default);

        Task<IEnumerable<Deductions>> GetAllDeductions();
    }
}
