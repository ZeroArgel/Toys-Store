namespace ToysStore.Models.Requests.Products
{
    using Dto;
    using MediatR;
    using System;
    using ZAExtensions.zCore;
    public class AddProduct
    {
        public class Request : Product, IRequest<ZResult<Guid>> { }
    }
}