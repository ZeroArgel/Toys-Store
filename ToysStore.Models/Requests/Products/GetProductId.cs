namespace ToysStore.Models.Requests.Products
{
    using Dto;
    using MediatR;
    using System;
    using ZAExtensions.zCore;
    public class GetProductId
    {
        public class Request : IRequest<ZResult<Response>>
        {
            public Request(Guid id) => Id = id;
            public Guid Id { get; }
        }
        public class Response : Product { }
    }
}