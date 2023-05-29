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
    public class EmployeeRepository : RepositoryAsync, IEmployeeRespository
    {
        private readonly ApplicationContext _dbContext;
        public EmployeeRepository(ApplicationContext dbContext) : base(dbContext)
        {

            _dbContext = dbContext;
        }

        public async Task<Employee> GetEmployee(Expression<Func<Employee, bool>> expression, bool AsNoTracking = true, CancellationToken cancellationToken = default)
        {
            IQueryable<Employee> query = _dbContext.Employees;
            if (AsNoTracking) query = query.AsNoTracking();
            return await query.Include(e => e.CadreLevel)
                    .ThenInclude(cl => cl.Earnings)
                    .Include(e => e.CadreLevel)
                    .ThenInclude(cl => cl.Deductions)
                .Where(expression).SingleOrDefaultAsync(cancellationToken);
        }

        public async Task<IEnumerable<Employee>> GetAllEmployee(Expression<Func<Employee, bool>> expression, bool AsNoTracking = true, CancellationToken cancellationToken = default)
        {
            IQueryable<Employee> query = _dbContext.Employees;
            if (AsNoTracking) query = query.AsNoTracking();
            if (expression != null) query = query.Include(e => e.CadreLevel)
                    .ThenInclude(cl => cl.Earnings)
                    .Include(e => e.CadreLevel)
                    .ThenInclude(cl => cl.Deductions)
                .Where(expression);
            return await query.ToListAsync(cancellationToken);
        }

        public async Task<IEnumerable<Employee>> GetAllEmployee()
        {
            IQueryable<Employee> query = _dbContext.Employees;
            if (query != null) query = query.Include(e => e.CadreLevel)
                    .ThenInclude(cl => cl.Earnings)
                    .Include(e => e.CadreLevel)
                    .ThenInclude(cl => cl.Deductions);
            return query;
        }
    }
}
