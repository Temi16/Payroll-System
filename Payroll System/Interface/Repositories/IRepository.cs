using Payroll_System.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Payroll_System.Interface.Repositories
{
    public interface IRepository
    {

        #region Get
        Task<T> GetAsync<T>(Expression<Func<T, bool>> expression, bool AsNoTracking = true, CancellationToken cancellationToken = default) where T : AuditableEntity;

        Task<IEnumerable<T>> GetListAsync<T>(Expression<Func<T, bool>> expression = null, bool AsNoTracking = true, CancellationToken cancellationToken = default) where T : AuditableEntity;
        


        Task<bool> ExistsAsync<T>(Expression<Func<T, bool>> expression, CancellationToken cancellationToken = default)
        where T : AuditableEntity;

        #endregion

        #region update
        Task UpdateAsync<T>(T entity)
        where T : AuditableEntity;

        #endregion update

        #region Save Changes

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);

        #endregion Save Changes

        #region FirstOrDefault

        Task<T> FirstByConditionAsync<T>(Expression<Func<T, bool>> expression, bool AsNoTracking = true)
        where T : AuditableEntity;

        #endregion FirstOrDefault

        #region LastOrDefault

        Task<T> LastByConditionAsync<T>(Expression<Func<T, bool>> expression, bool AsNoTracking = true)
        where T : AuditableEntity;

        #endregion LastOrDefault

        #region Create

        Task<Guid> CreateAsync<T>(T entity)
        where T : AuditableEntity;

        Task<IList<Guid>> CreateRangeAsync<T>(IEnumerable<T> entity)
        where T : AuditableEntity;

        #endregion Create

        #region DeleteOrRemoveOrClear

        Task RemoveAsync<T>(T entity)
        where T : AuditableEntity;

        Task<T> RemoveByIdAsync<T>(Guid entityId)
        where T : AuditableEntity;

        Task ClearAsync<T>(Expression<Func<T, bool>> expression = null)
        where T : AuditableEntity;

        #endregion Paginate
        
    }
}
