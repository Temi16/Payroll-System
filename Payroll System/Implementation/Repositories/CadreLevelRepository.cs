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
    public class CadreLevelRepository : RepositoryAsync, ICadreLevelRepository
    {
        private readonly ApplicationContext _dbContext;
        public CadreLevelRepository(ApplicationContext dbContext) : base(dbContext)
        {

            _dbContext = dbContext;
        }

        public async Task<CadreLevel> GetCadreLevel(Expression<Func<CadreLevel, bool>> expression, bool AsNoTracking = true, CancellationToken cancellationToken = default)
        {
            IQueryable<CadreLevel> query = _dbContext.CadreLevels;
            if (AsNoTracking) query = query.AsNoTracking();
            return await query.Include(cl => cl.Earnings)
                .Include(cl => cl.Deductions)
                .Where(expression).SingleOrDefaultAsync(cancellationToken);
        }

        public async Task<IEnumerable<CadreLevel>> GetAllCadreLevel(Expression<Func<CadreLevel, bool>> expression, bool AsNoTracking = true, CancellationToken cancellationToken = default)
        {
            IQueryable<CadreLevel> query = _dbContext.CadreLevels;
            if (AsNoTracking) query = query.AsNoTracking();
            if (expression != null) query = query.Include(cl => cl.Earnings)
                .Include(cl => cl.Deductions)
                .Where(expression);
            return await query.ToListAsync(cancellationToken);
        }

        public async Task<IEnumerable<CadreLevel>> GetAllCadreLevel()
        {
            IQueryable<CadreLevel> query = _dbContext.CadreLevels;
            if (query != null) query = query.Include(cl => cl.Earnings)
                .Include(cl => cl.Deductions);
            return query;
        }
    }
}
