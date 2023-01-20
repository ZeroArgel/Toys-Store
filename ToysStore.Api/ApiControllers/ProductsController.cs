namespace ToysStore.Api.ApiControllers
{
    #region usings.
    using MediatR;
    //using Microsoft.AspNetCore.Authentication.Cookies;
    //using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Models.Requests.Products;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using ZAExtensions.zCore;
    #endregion
    /// <summary>
    /// 
    /// </summary>
    [ApiController, Route("api/products")]
    //[Authorize(AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme)]
    public class ProductsController : BaseController
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="mediator"></param>
        public ProductsController(IMediator mediator) : base(mediator) { }

        /// <summary>
        /// Get all products
        /// </summary>
        /// <returns></returns>
        [HttpGet("get")]
        public async Task<ZResult<IEnumerable<GetProducts.Response>>> Get() =>
            await Mediator.Send(new GetProducts.Request());
        /// <summary>
        /// Get product by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("get/{id:Guid}")]
        public async Task<ZResult<GetProductId.Response>> GetId(Guid id) =>
            await Mediator.Send(new GetProductId.Request(id));
        /// <summary>
        /// Add one product
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("add")]
        public async Task<ZResult<Guid>> Add([FromBody] AddProduct.Request request) =>
            await Mediator.Send(request);

        /// <summary>
        /// Update one product
        /// </summary>
        /// <param name="id"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPut("update/{id:guid}")]
        public async Task<ZResult<bool>> Update(Guid id, [FromBody] UpdateProduct.Request request)
        {
            request.SetProductId(id);
            return await Mediator.Send(request);
        }
        /// <summary>
        /// Delete one product
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("delete/{id:guid}")]
        public async Task<ZResult<bool>> Delete(Guid id) => await Mediator.Send(new DeleteProduct.Request(id));
    }
}