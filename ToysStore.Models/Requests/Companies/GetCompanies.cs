namespace ToysStore.Models.Requests.Companies
{
    using Dto;
    using MediatR;
    using System.Collections.Generic;
    using ZAExtensions.zCore;
    public class GetCompanies
    {
        public class Request : IRequest<ZResult<IEnumerable<Response>>> { }
        public class Response : Company { }
    }
}