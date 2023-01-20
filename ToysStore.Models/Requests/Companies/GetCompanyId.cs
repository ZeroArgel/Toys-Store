namespace ToysStore.Models.Requests.Companies
{
    using Dto;
    using MediatR;
    using System;
    using ZAExtensions.zCore;
    public class GetCompanyId
    {
        public class Request : IRequest<ZResult<Response>>
        {
            public Request(Guid id) => Id = id;
            public Guid Id { get; }
        }
        public class Response : Company {}
    }
}