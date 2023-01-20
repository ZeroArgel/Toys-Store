namespace ToysStore.Handlers.Api
{
    #region Usings
    using DataAccess.Interfaces;
    using Microsoft.AspNetCore.Http;
    using Models.Filters;
    using System;
    using System.Globalization;
    using ZAExtensions.zCore;
    #endregion
    public class BaseHandler
    {
        protected readonly CultureInfo CultureInfo;
        protected readonly DateTimeOffset RequestTime;
        protected readonly TimeZoneInfo TimeZoneInfo;
        protected readonly IUnitOfWork UnitOfWork;
        public BaseHandler(IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor, bool isTransaction = true)
        {
            if (unitOfWork == null) throw new ZException("Unauthorized (uow undefined)", 401);
            if (httpContextAccessor.HttpContext == null) throw new ZException("Unauthorized (hca undefined)", 401);
            
            var iHeadersRequest = httpContextAccessor.HttpContext.Features.Get<IHeadersRequest>();
            UnitOfWork = unitOfWork;
            
            if (iHeadersRequest == null) throw new ZException("Unauthorized (IHeadersRequest undefined)");
            if (isTransaction) UnitOfWork.BeginTransactionAsync(default);

            CultureInfo = iHeadersRequest.CultureInfo;
            RequestTime = iHeadersRequest.RequestTime;
            TimeZoneInfo = iHeadersRequest.TimeZoneInfo;
        }
    }
}