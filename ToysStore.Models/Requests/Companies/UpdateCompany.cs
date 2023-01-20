namespace ToysStore.Models.Requests.Companies
{
    using Dto;
    using MediatR;
    using ZAExtensions.zCore;
    public class UpdateCompany
    {
        public class Request : Company, IRequest<ZResult<bool>> { }
    }
}