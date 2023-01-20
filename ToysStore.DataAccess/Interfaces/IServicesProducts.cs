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
    public interface IServicesProducts
    {
        Task<IQueryable<Products>> GetAsync(Expression<Func<Products, bool>> predicate = null);
        Task<Products> GetByIdAsync(Guid id, CancellationToken cancellationToken);
        Task<Products> AddAsync(Products products, CancellationToken cancellationToken);
        Task<Products> UpdateAsync(Products products);
        Task<Products> DeleteAsync(Products products);
    }
}