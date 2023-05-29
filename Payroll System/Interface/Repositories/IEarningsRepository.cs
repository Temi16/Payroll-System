using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using Payroll_System.Entities;

namespace Payroll_System.Interface.Repositories
{
    public interface IEarningsRepository : IRepository
    {
        Task<Earnings> GetEarnings(Expression<Func<Earnings, bool>> expression, bool AsNoTracking = true, CancellationToken cancellationToken = default);
        Task<IEnumerable<Earnings>> GetAllEarnings(Expression<Func<Earnings, bool>> expression, bool AsNoTracking = true, CancellationToken cancellationToken = default);

        Task<IEnumerable<Earnings>> GetAllEarnings();
    }
}
