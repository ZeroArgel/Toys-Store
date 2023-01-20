namespace ToysStore.Desktop.Handlers
{
    using Models.Requests.Companies;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using ZAExtensions.zCore;
    public interface ICompaniesHandler
    {
        Task<ZResult<IEnumerable<GetCompanies.Response>>> Get();
        Task<ZResult<GetCompanyId.Response>> GetId(Guid id);
        Task<ZResult<Guid>> Add(AddCompany.Request request);
        Task<ZResult<bool>> Update(Guid id, UpdateCompany.Request request);
        Task<ZResult<bool>> Delete(Guid id);
    }
}