namespace ToysStore.Models.Dao
{
    using System;
    public class Companies : BaseDao<Guid>
    {
        public virtual string Name { get; set; }
    }
}