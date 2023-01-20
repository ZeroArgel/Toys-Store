namespace ToysStore.DataAccess.Core
{
    using Interfaces;
    using System.Threading;
    using System.Threading.Tasks;
    public class UnitOfWork : IUnitOfWork
    {
        protected readonly ToysStoreContext ToysStoreContext;

        public UnitOfWork(ToysStoreContext toysStoreContext)
        {
            ToysStoreContext = toysStoreContext;
            ServicesCompanies = new ServicesCompanies(toysStoreContext);
            ServicesProducts = new ServicesProducts(toysStoreContext);
        }

        public IServicesCompanies ServicesCompanies { get; }
        public IServicesProducts ServicesProducts { get; }
        public async Task BeginTransactionAsync(CancellationToken cancellationToken) => await ToysStoreContext.Database.BeginTransactionAsync(cancellationToken);
        public async Task EndTransactionAsync(CancellationToken cancellationToken)
        {
            await SaveChangesAsync(cancellationToken);
            await ToysStoreContext.Database.CommitTransactionAsync(cancellationToken);
        }

        public async Task RollbackTransactionAsync(CancellationToken cancellationToken)
        {
            if (ToysStoreContext.Database.CurrentTransaction == null) return;
            await ToysStoreContext.Database.RollbackTransactionAsync(cancellationToken);
        }
        public async Task SaveChangesAsync(CancellationToken cancellationToken) => await ToysStoreContext.SaveChangesAsync(cancellationToken);
    }
}