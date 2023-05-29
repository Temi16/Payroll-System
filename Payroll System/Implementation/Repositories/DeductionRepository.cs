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
    public class DeductionRepository : RepositoryAsync, IDeductionRepository
    {
        private readonly ApplicationContext _dbContext;
        public DeductionRepository(ApplicationContext dbContext) : base(dbContext)
        {

            _dbContext = dbContext;
        }

        public async Task<Deductions> GetDeductions(Expression<Func<Deductions, bool>> expression, bool AsNoTracking = true, CancellationToken cancellationToken = default)
        {
            IQueryable<Deductions> query = _dbContext.Deductions;
            if (AsNoTracking) query = query.AsNoTracking();
            return await query
                .Where(expression).SingleOrDefaultAsync(cancellationToken);
        }

        public async Task<IEnumerable<Deductions>> GetAllDeductions(Expression<Func<Deductions, bool>> expression, bool AsNoTracking = true, CancellationToken cancellationToken = default)
        {
            IQueryable<Deductions> query = _dbContext.Deductions;
            if (AsNoTracking) query = query.AsNoTracking();
            if (expression != null) query = query
                .Where(expression);
            return await query.ToListAsync(cancellationToken);
        }

        public async Task<IEnumerable<Deductions>> GetAllDeductions()
        {
            IQueryable<Deductions> query = _dbContext.Deductions;
            if (query != null) return query;
            return null;
        }
    }
}
