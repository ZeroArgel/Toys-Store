namespace ToysStore.DataAccess.Interfaces
{
    #region usings.
    using Models.Dao;
    using System;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading;
    using System.Threading.Tasks;
    #endregion
    public interface IServicesCompanies
    {
        Task<IQueryable<Companies>> GetAsync(Expression<Func<Companies, bool>> predicate = null);
        Task<Companies> GetByIdAsync(Guid id, CancellationToken cancellationToken);
        Task<Companies> AddAsync(Companies companies, CancellationToken cancellationToken);
        Task<Companies> UpdateAsync(Companies companies);
        Task<Companies> DeleteAsync(Companies companies);
    }
}