namespace ToysStore.Desktop.Handlers.Core
{
    using Models.Requests.Companies;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using ZAExtensions.zCore;
    public class CompaniesHandler : ICompaniesHandler
    {
        public async Task<ZResult<IEnumerable<GetCompanies.Response>>> Get() =>
            await "companies/get".Get<IEnumerable<GetCompanies.Response>>();

        public async Task<ZResult<GetCompanyId.Response>> GetId(Guid id) =>
            await $"companies/get/{id}".Get<GetCompanyId.Response>();

        public async Task<ZResult<Guid>> Add(AddCompany.Request request) => 
            await request.Post<AddCompany.Request, Guid>("companies/add");

        public async Task<ZResult<bool>> Update(Guid id, UpdateCompany.Request request) =>
            await request.Put<UpdateCompany.Request, bool>($"companies/update/{id}");

        public async Task<ZResult<bool>> Delete(Guid id) =>
            await $"companies/delete/{id}".Delete<bool>();
    }
}