namespace ToysStore.Models.Dto
{
    using System;
    public class Product
    {
        public Guid ProductId { get; internal set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public int RestrictionAge { get; set; }
        public decimal Price { get; set; }
        public Guid CompanyId { get; set; }
        public string CompanyName { get; internal set; }
        public void SetProductId(Guid productId) => ProductId = productId;
    }
}