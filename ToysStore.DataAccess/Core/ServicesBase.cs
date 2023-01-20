namespace ToysStore.DataAccess.Core
{
    #region usings.
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading;
    using System.Threading.Tasks;
    #endregion
    public class ServicesBase<T> where T : class
    {
        protected readonly ToysStoreContext ToysStoreContext;
        public ServicesBase(ToysStoreContext toysStoreContext) => ToysStoreContext = toysStoreContext;
        protected async Task<IQueryable<T>> GetTAsync(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties)
        {
            var set = ToysStoreContext.Set<T>().AsNoTracking().AsQueryable();
            foreach (var property in includeProperties)
                set = set.Include(property);
            return predicate == null
                ? await Task.FromResult(set)
                : await Task.FromResult(set.Where(predicate));
        }
        protected async Task<T> GetTByIdAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken, params Expression<Func<T, object>>[] includeProperties)
        {
            var set = ToysStoreContext.Set<T>().AsNoTracking();
            foreach (var property in includeProperties)
                set = set.Include(property);
            return await set.FirstOrDefaultAsync(predicate, cancellationToken);
        }
        protected async Task<T> AddTAsync(T model, CancellationToken cancellationToken) => (await ToysStoreContext.Set<T>().AddAsync(model, cancellationToken)).Entity;
        protected async Task<T> UpdateTAsync(T model) => await Task.FromResult(ToysStoreContext.Set<T>().Update(model).Entity);
        protected async Task<T> DeleteTAsync(T model) => await Task.FromResult(ToysStoreContext.Set<T>().Remove(model).Entity);
    }
}
