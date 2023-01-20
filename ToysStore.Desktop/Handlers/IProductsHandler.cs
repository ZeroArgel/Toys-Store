namespace ToysStore.Desktop.Handlers
{
    using Models.Requests.Products;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using ZAExtensions.zCore;
    public interface IProductsHandler
    {
        Task<ZResult<IEnumerable<GetProducts.Response>>> Get();
        Task<ZResult<GetProductId.Response>> GetId(Guid id);
        Task<ZResult<Guid>> Add(AddProduct.Request request);
        Task<ZResult<bool>> Update(Guid id, UpdateProduct.Request request);
        Task<ZResult<bool>> Delete(Guid id);
    }
}