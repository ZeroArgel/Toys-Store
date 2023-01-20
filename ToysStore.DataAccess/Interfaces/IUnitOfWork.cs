namespace ToysStore.DataAccess.Interfaces
{
    using System.Threading;
    using System.Threading.Tasks;
    public interface IUnitOfWork
    {
        IServicesCompanies ServicesCompanies { get; }
        IServicesProducts ServicesProducts { get; }
        Task BeginTransactionAsync(CancellationToken cancellationToken);
        Task EndTransactionAsync(CancellationToken cancellationToken);
        Task RollbackTransactionAsync(CancellationToken cancellationToken);
        Task SaveChangesAsync(CancellationToken cancellationToken);
    }
}