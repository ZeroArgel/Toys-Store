namespace ToysStore.Models.Requests.Products
{
    using Dto;
    using MediatR;
    using System.Collections.Generic;
    using ZAExtensions.zCore;
    public class GetProducts
    {
        public class Request : IRequest<ZResult<IEnumerable<Response>>> { }
        public class Response : Product { }
    }
}