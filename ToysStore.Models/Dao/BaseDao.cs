namespace ToysStore.Models.Dao
{
    public class BaseDao<T>
    {
        public virtual T Id { get; set; }
    }
}