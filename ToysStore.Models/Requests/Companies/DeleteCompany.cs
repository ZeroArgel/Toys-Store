namespace ToysStore.Models.Requests.Companies
{
    using MediatR;
    using System;
    using ZAExtensions.zCore;
    public class DeleteCompany
    {
        public class Request : IRequest<ZResult<bool>>
        {
            public Request(Guid id) => Id = id;
            public Guid Id { get; }
        }
    }
}