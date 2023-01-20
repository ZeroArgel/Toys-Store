namespace ToysStore.Api.ApiControllers
{
    #region usings.
    using MediatR;
    //using Microsoft.AspNetCore.Authentication.Cookies;
    //using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Models.Requests.Companies;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using ZAExtensions.zCore;
    #endregion
    /// <summary>
    /// 
    /// </summary>
    [ApiController, Route("api/companies")]
    //[Authorize(AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme)]
    public class CompaniesController : BaseController
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="mediator"></param>
        public CompaniesController(IMediator mediator) : base(mediator) { }

        /// <summary>
        /// Get all companies
        /// </summary>
        /// <returns></returns>
        [HttpGet("get")]
        public async Task<ZResult<IEnumerable<GetCompanies.Response>>> Get() =>
            await Mediator.Send(new GetCompanies.Request());
        /// <summary>
        /// Get company by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("get/{id:Guid}")]
        public async Task<ZResult<GetCompanyId.Response>> GetId(Guid id) =>
            await Mediator.Send(new GetCompanyId.Request(id));
        /// <summary>
        /// Add one company
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("add")]
        public async Task<ZResult<Guid>> Add([FromBody] AddCompany.Request request) =>
            await Mediator.Send(request);

        /// <summary>
        /// Update one company
        /// </summary>
        /// <param name="id"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPut("update/{id:guid}")]
        public async Task<ZResult<bool>> Update(Guid id, [FromBody] UpdateCompany.Request request)
        {
            request.SetCompanyId(id);
            return await Mediator.Send(request);
        }
        /// <summary>
        /// Delete one company
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("delete/{id:guid}")]
        public async Task<ZResult<bool>> Delete(Guid id) => await Mediator.Send(new DeleteCompany.Request(id));
    }
}