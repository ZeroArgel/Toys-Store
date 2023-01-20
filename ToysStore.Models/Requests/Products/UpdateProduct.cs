namespace ToysStore.Models.Requests.Products
{
    using Dto;
    using MediatR;
    using ZAExtensions.zCore;
    public class UpdateProduct
    {
        public class Request : Product, IRequest<ZResult<bool>> { }
    }
}