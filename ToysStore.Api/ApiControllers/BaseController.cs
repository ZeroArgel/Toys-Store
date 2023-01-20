namespace ToysStore.Api.ApiControllers
{
    using MediatR;
    using Microsoft.AspNetCore.Mvc;
    /// <summary>
    /// 
    /// </summary>
    public class BaseController : ControllerBase
    {
        /// <summary>
        /// 
        /// </summary>
        protected readonly IMediator Mediator;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="mediator"></param>
        public BaseController(IMediator mediator) => Mediator = mediator;
    }
}