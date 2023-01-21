namespace ToysStore.DataAccess.Core
{
    #region usings.
    using Interfaces;
    using Models.Dao;
    using System;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading;
    using System.Threading.Tasks;
    #endregion
    public class ServicesProducts : ServicesBase<Products>, IServicesProducts
    {
        public ServicesProducts(ToysStoreContext zFinancesContext) : base(zFinancesContext) { }
        public async Task<IQueryable<Products>> GetAsync(Expression<Func<Products, bool>> predicate = null)
            => await GetTAsync(predicate, inc => inc.Company);
        public async Task<Products> GetByIdAsync(Guid id, CancellationToken cancellationToken) => await GetTByIdAsync(x => x.Id == id, cancellationToken);
        public async Task<Products> AddAsync(Products products, CancellationToken cancellationToken) => await AddTAsync(products, cancellationToken);
        public async Task<Products> UpdateAsync(Products products) => await UpdateTAsync(products);
        public async Task<Products> DeleteAsync(Products products) => await DeleteTAsync(products);
    }
}