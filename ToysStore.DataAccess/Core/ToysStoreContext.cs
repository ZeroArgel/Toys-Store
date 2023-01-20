namespace ToysStore.DataAccess.Core
{
    using Models.Dao;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    public class ToysStoreContext : DbContext
    {
        private readonly string _connectionString;

        public ToysStoreContext(IConfiguration configuration) =>
            _connectionString = configuration.GetConnectionString("ToysStoreDb");

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseLazyLoadingProxies()
                .UseSqlServer(_connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("ts");

            #region modelBuilder Products
            modelBuilder.Entity<Products>(e =>
            {
                e.ToTable("Products");
                e.HasKey(p => p.Id);
                e.Property(p => p.Name)
                    .HasMaxLength(50)
                    .IsRequired();
                e.Property(p => p.Description)
                    .HasMaxLength(100)
                    .IsRequired();
                e.Property(p => p.RestrictionAge)
                    .IsRequired();
                e.Property(p => p.Price)
                    .HasPrecision(7, 2)
                    .IsRequired();
                e.Navigation(n => n.Company)
                    .UsePropertyAccessMode(PropertyAccessMode.Property);
            });
            #endregion
            #region modelBuilder Companies
            modelBuilder.Entity<Companies>(e =>
            {
                e.ToTable("Companies");
                e.HasKey(p => p.Id);
                e.Property(p => p.Name)
                    .HasMaxLength(50)
                    .IsRequired();
            });
            #endregion
        }
    }
}