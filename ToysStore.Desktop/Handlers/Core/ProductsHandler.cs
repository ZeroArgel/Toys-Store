namespace ToysStore.Desktop.Handlers.Core
{
    using Models.Requests.Products;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using ZAExtensions.zCore;
    public class ProductsHandler : IProductsHandler
    {
        public async Task<ZResult<IEnumerable<GetProducts.Response>>> Get() =>
            await "products/get".Get<IEnumerable<GetProducts.Response>>();

        public async Task<ZResult<GetProductId.Response>> GetId(Guid id) =>
            await $"products/get/{id}".Get<GetProductId.Response>();

        public async Task<ZResult<Guid>> Add(AddProduct.Request request) =>
            await request.Post<AddProduct.Request, Guid>("products/add");

        public async Task<ZResult<bool>> Update(Guid id, UpdateProduct.Request request) =>
            await request.Put<UpdateProduct.Request, bool>($"products/update/{id}");

        public async Task<ZResult<bool>> Delete(Guid id) =>
            await $"products/delete/{id}".Delete<bool>();
    }
}