namespace ToysStore.Models.Requests.Companies
{
    using Dto;
    using MediatR;
    using System;
    using ZAExtensions.zCore;
    public class AddCompany
    {
        public class Request : Company, IRequest<ZResult<Guid>> { }
    }
}