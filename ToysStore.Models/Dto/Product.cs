namespace ToysStore.Models.Dto
{
    using Newtonsoft.Json;
    using System;
    public class Product
    {
        [JsonProperty] public Guid ProductId { get; internal set; }
        [JsonProperty] public string ProductName { get; set; }
        [JsonProperty] public string ProductDescription { get; set; }
        [JsonProperty] public int RestrictionAge { get; set; }
        [JsonProperty] public decimal Price { get; set; }
        [JsonProperty] public Guid CompanyId { get; set; }
        [JsonProperty] public string CompanyName { get; internal set; }
        public void SetProductId(Guid productId) => ProductId = productId;
    }
}