namespace ToysStore.Handlers.Api
{
    #region usings.
    using DataAccess.Interfaces;
    using MediatR;
    using Microsoft.AspNetCore.Http;
    using Models.Dao;
    using Models.Filters;
    using Models.Requests.Products;
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using ZAExtensions.zCore;
    using ZAExtensions.zValidation;
    #endregion
    #region GetProductsHandle
    public class GetProductsHandle : BaseHandler, IRequestHandler<GetProducts.Request, ZResult<IEnumerable<GetProducts.Response>>>
    {
        public GetProductsHandle(IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor) : base(unitOfWork, httpContextAccessor, false) { }
        public async Task<ZResult<IEnumerable<GetProducts.Response>>> Handle(GetProducts.Request request,
            CancellationToken cancellationToken) => (await UnitOfWork.ServicesProducts.GetAsync()).ToMap<IQueryable<Products>, IEnumerable<GetProducts.Response>>().ZOk();
    }
    #endregion
    #region GetProductIdHandle
    public class GetProductIdHandle : BaseHandler, IRequestHandler<GetProductId.Request, ZResult<GetProductId.Response>>
    {
        public GetProductIdHandle(IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor) : base(unitOfWork, httpContextAccessor, false) { }

        public async Task<ZResult<GetProductId.Response>> Handle(GetProductId.Request request,
            CancellationToken cancellationToken)
        {
            if (request.Id.IsEmpty()) throw new ZException("Id not must be empty or null", dataResponse: request);

            var response = await UnitOfWork.ServicesCompanies.GetByIdAsync(request.Id, cancellationToken);
            if (response == null) throw new ZException($"Product not found '{request.Id}'");
            return response.ToMap<Companies, GetProductId.Response>().ZOk();
        }
    }
    #endregion
    #region AddProductHandle
    public class AddProductHandle : BaseHandler, IRequestHandler<AddProduct.Request, ZResult<Guid>>
    {
        public AddProductHandle(IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor) : base(unitOfWork, httpContextAccessor) { }

        public async Task<ZResult<Guid>> Handle(AddProduct.Request request,
            CancellationToken cancellationToken)
        {
            try
            {
                if (request.ProductName.IsEmpty()) throw new ZException("ProductName not must be empty or null", dataResponse: request);
                if (request.ProductDescription.IsEmpty()) throw new ZException("ProductDescription not must be empty or null", dataResponse: request);
                if (request.RestrictionAge < 0) throw new ZException("RestrictionAge not must be empty or null", dataResponse: request);
                if (request.Price.IsEmpty()) throw new ZException("Price not must be empty or null", dataResponse: request);
                if (request.CompanyId.IsEmpty()) throw new ZException("CompanyId not must be empty or null", dataResponse: request);

                var product = request.ToMap<AddProduct.Request, Products>();
                var response = await UnitOfWork.ServicesProducts.AddAsync(product, cancellationToken);
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
    #region UpdateProductHandle
    public class UpdateProductHandle : BaseHandler, IRequestHandler<UpdateProduct.Request, ZResult<bool>>
    {
        public UpdateProductHandle(IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor) : base(unitOfWork, httpContextAccessor) { }

        public async Task<ZResult<bool>> Handle(UpdateProduct.Request request,
            CancellationToken cancellationToken)
        {
            try
            {
                if (request.ProductId.IsEmpty()) throw new ZException("ProductId not must be empty or null", dataResponse: request);
                if (request.ProductName.IsEmpty()) throw new ZException("ProductName not must be empty or null", dataResponse: request);
                if (request.ProductDescription.IsEmpty()) throw new ZException("ProductDescription not must be empty or null", dataResponse: request);
                if (request.RestrictionAge > 0) throw new ZException("RestrictionAge not must be empty or null", dataResponse: request);
                if (request.Price.IsEmpty()) throw new ZException("Price not must be empty or null", dataResponse: request);
                if (request.CompanyId.IsEmpty()) throw new ZException("CompanyId not must be empty or null", dataResponse: request);

                var product = await UnitOfWork.ServicesProducts.GetByIdAsync(request.ProductId, cancellationToken);
                if (product == null) throw new ZException($"Product not found '{request.ProductId}'");
                
                product.Name = request.ProductName;
                product.Description = request.ProductDescription;
                product.RestrictionAge = request.RestrictionAge;
                product.Price = request.Price.ToString(new CultureInfo("en-Us")).ToDecimal();
                product.CompanyId = request.CompanyId;

                await UnitOfWork.ServicesProducts.UpdateAsync(product);
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
    public class DeleteProductHandle : BaseHandler, IRequestHandler<DeleteProduct.Request, ZResult<bool>>
    {
        public DeleteProductHandle(IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor) : base(unitOfWork, httpContextAccessor) { }

        public async Task<ZResult<bool>> Handle(DeleteProduct.Request request,
            CancellationToken cancellationToken)
        {
            try
            {
                if (request.Id.IsEmpty()) throw new ZException("Id not must be empty or null", dataResponse: request);

                var product = await UnitOfWork.ServicesProducts.GetByIdAsync(request.Id, cancellationToken);
                if (product == null) throw new ZException($"Product not found '{request.Id}'");

                await UnitOfWork.ServicesProducts.DeleteAsync(product);
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