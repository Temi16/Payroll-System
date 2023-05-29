using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using Payroll_System.Entities;

namespace Payroll_System.Interface.Repositories
{
    public interface ICadreLevelRepository : IRepository
    {
        Task<CadreLevel> GetCadreLevel(Expression<Func<CadreLevel, bool>> expression, bool AsNoTracking = true, CancellationToken cancellationToken = default);
        Task<IEnumerable<CadreLevel>> GetAllCadreLevel(Expression<Func<CadreLevel, bool>> expression, bool AsNoTracking = true, CancellationToken cancellationToken = default);

        Task<IEnumerable<CadreLevel>> GetAllCadreLevel();
    }
}
