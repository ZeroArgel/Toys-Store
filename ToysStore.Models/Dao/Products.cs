namespace ToysStore.Models.Dao
{
    using System;
    public class Products : BaseDao<Guid>
    {
        public virtual string Name { get; set; }
        public virtual string Description { get; set; }
        public virtual int RestrictionAge { get; set; }
        public virtual decimal Price { get; set; }
        public virtual Guid CompanyId { get; set; }
        public virtual Companies Company { get; set; }
    }
}