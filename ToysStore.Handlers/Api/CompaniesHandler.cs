namespace ToysStore.Handlers.Api
{
    #region usings.
    using DataAccess.Interfaces;
    using MediatR;
    using Microsoft.AspNetCore.Http;
    using Models.Dao;
    using Models.Filters;
    using Models.Requests.Companies;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using ZAExtensions.zCore;
    using ZAExtensions.zValidation;
    #endregion
    #region GetCompaniesHandle
    public class GetCompaniesHandle : BaseHandler, IRequestHandler<GetCompanies.Request, ZResult<IEnumerable<GetCompanies.Response>>>
    {
        public GetCompaniesHandle(IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor) : base(unitOfWork, httpContextAccessor, false) { }
        public async Task<ZResult<IEnumerable<GetCompanies.Response>>> Handle(GetCompanies.Request request,
            CancellationToken cancellationToken) => (await UnitOfWork.ServicesCompanies.GetAsync()).ToMap<IQueryable<Companies>, IEnumerable<GetCompanies.Response>>().ZOk();
    }
    #endregion
    #region GetCompanyIdHandle
    public class GetCompanyIdHandle : BaseHandler, IRequestHandler<GetCompanyId.Request, ZResult<GetCompanyId.Response>>
    {
        public GetCompanyIdHandle(IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor) : base(unitOfWork, httpContextAccessor, false) { }

        public async Task<ZResult<GetCompanyId.Response>> Handle(GetCompanyId.Request request,
            CancellationToken cancellationToken)
        {
            if (request.Id.IsEmpty()) throw new ZException("Id not must be empty or null", dataResponse: request);

            var response = await UnitOfWork.ServicesCompanies.GetByIdAsync(request.Id, cancellationToken);
            if (response == null) throw new ZException($"Company not found '{request.Id}'");
            return response.ToMap<Companies, GetCompanyId.Response>().ZOk();
        }
    }
    #endregion
    #region AddCompanyHandle
    public class AddCompanyHandle : BaseHandler, IRequestHandler<AddCompany.Request, ZResult<Guid>>
    {
        public AddCompanyHandle(IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor) : base(unitOfWork, httpContextAccessor) { }

        public async Task<ZResult<Guid>> Handle(AddCompany.Request request,
            CancellationToken cancellationToken)
        {
            try
            {
                if (request.CompanyName.IsEmpty()) throw new ZException("CompanyName not must be empty or null", dataResponse: request);

                var company = request.ToMap<AddCompany.Request, Companies>();

                var response = await UnitOfWork.ServicesCompanies.AddAsync(company, cancellationToken);
                await UnitOfWork.EndTransactionAsync(cancellationToken);
                return response.Id.ZOk();
            }
            catch
            {
                await UnitOfWork.RollbackTransactionAsync(cancellationToken);
                throw;
            }
        }
    }
    #endregion
    #region UpdateCompanyHandle
    public class UpdateCompanyHandle : BaseHandler, IRequestHandler<UpdateCompany.Request, ZResult<bool>>
    {
        public UpdateCompanyHandle(IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor) : base(unitOfWork, httpContextAccessor) { }

        public async Task<ZResult<bool>> Handle(UpdateCompany.Request request,
            CancellationToken cancellationToken)
        {
            try
            {
                if (request.CompanyId.IsEmpty()) throw new ZException("CompanyId not must be empty or null", dataResponse: request);
                if (request.CompanyName.IsEmpty()) throw new ZException("CompanyName not must be empty or null", dataResponse: request);

                var company = await UnitOfWork.ServicesCompanies.GetByIdAsync(request.CompanyId, cancellationToken);
                if (company == null) throw new ZException($"Company not found '{request.CompanyId}'");
                company.Name = request.CompanyName;

                await UnitOfWork.ServicesCompanies.UpdateAsync(company);
                await UnitOfWork.EndTransactionAsync(cancellationToken);
                return true.ZOk();
            }
            catch
            {
                await UnitOfWork.RollbackTransactionAsync(cancellationToken);
                throw;
            }
        }
    }
    #endregion
    #region DeleteCompanyHandle
    public class DeleteCompanyHandle : BaseHandler, IRequestHandler<DeleteCompany.Request, ZResult<bool>>
    {
        public DeleteCompanyHandle(IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor) : base(unitOfWork, httpContextAccessor) { }

        public async Task<ZResult<bool>> Handle(DeleteCompany.Request request,
            CancellationToken cancellationToken)
        {
            try
            {
                if (request.Id.IsEmpty()) throw new ZException("Id not must be empty or null", dataResponse: request);

                var company = await UnitOfWork.ServicesCompanies.GetByIdAsync(request.Id, cancellationToken);
                if (company == null) throw new ZException($"Company not found '{request.Id}'");

                await UnitOfWork.ServicesCompanies.DeleteAsync(company);
                await UnitOfWork.EndTransactionAsync(cancellationToken);
                return true.ZOk();
            }
            catch
            {
                await UnitOfWork.RollbackTransactionAsync(cancellationToken);
                throw;
            }
        }
    }
    #endregion
}