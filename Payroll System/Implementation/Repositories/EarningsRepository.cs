using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Payroll_System.Context;
using Payroll_System.Entities;
using Payroll_System.Interface.Repositories;

namespace Payroll_System.Implementation.Repositories
{
    public class EarningsRepository : RepositoryAsync, IEarningsRepository
    {
        private readonly ApplicationContext _dbContext;
        public EarningsRepository(ApplicationContext dbContext) : base(dbContext)
        {

            _dbContext = dbContext;
        }

        public async Task<Earnings> GetEarnings(Expression<Func<Earnings, bool>> expression, bool AsNoTracking = true, CancellationToken cancellationToken = default)
        {
            IQueryable<Earnings> query = _dbContext.Earnings;
            if (AsNoTracking) query = query.AsNoTracking();
            return await query
                .Where(expression).SingleOrDefaultAsync(cancellationToken);
        }

        public async Task<IEnumerable<Earnings>> GetAllEarnings(Expression<Func<Earnings, bool>> expression, bool AsNoTracking = true, CancellationToken cancellationToken = default)
        {
            IQueryable<Earnings> query = _dbContext.Earnings;
            if (AsNoTracking) query = query.AsNoTracking();
            if (expression != null) query = query
                .Where(expression);
            return await query.ToListAsync(cancellationToken);
        }

        public async Task<IEnumerable<Earnings>> GetAllEarnings()
        {
            IQueryable<Earnings> query = _dbContext.Earnings;
            if (query != null) return query;
            return null;
        }
    }
}
