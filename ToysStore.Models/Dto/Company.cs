namespace ToysStore.Models.Dto
{
    using System;
    using Newtonsoft.Json;
    public class Company
    {
        [JsonProperty] public Guid CompanyId { get; internal set; }
        [JsonProperty] public string CompanyName { get; set; }
        public void SetCompanyId(Guid companyId) => CompanyId = companyId;
    }
}