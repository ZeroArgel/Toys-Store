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
    public class ServicesCompanies : ServicesBase<Companies>, IServicesCompanies
    {
        public ServicesCompanies(ToysStoreContext zFinancesContext) : base(zFinancesContext) { }
        public async Task<IQueryable<Companies>> GetAsync(Expression<Func<Companies, bool>> predicate = null)
            => await GetTAsync(predicate);
        public async Task<Companies> GetByIdAsync(Guid id, CancellationToken cancellationToken) => await GetTByIdAsync(x => x.Id == id, cancellationToken);
        public async Task<Companies> AddAsync(Companies companies, CancellationToken cancellationToken) => await AddTAsync(companies, cancellationToken);
        public async Task<Companies> UpdateAsync(Companies companies) => await UpdateTAsync(companies);
        public async Task<Companies> DeleteAsync(Companies companies) => await DeleteTAsync(companies);
    }
}