namespace ToysStore.Models.Requests.Products
{
    using MediatR;
    using System;
    using ZAExtensions.zCore;
    public class DeleteProduct
    {
        public class Request : IRequest<ZResult<bool>>
        {
            public Request(Guid id) => Id = id;
            public Guid Id { get; }
        }
    }
}