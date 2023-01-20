using System.Globalization;
using ZAExtensions.zCore;

namespace ToysStore.Models.Filters
{
    using AutoMapper;
    using Dao;
    using Dto;
    using Requests.Companies;
    using Requests.Products;
    public static class Mapping
    {
        public static TDestination ToMap<TSource, TDestination>(this TSource model) =>
            ConfigMapperT().Map<TDestination>(model);

        private static Mapper ConfigMapperT() =>
            new(
                new MapperConfiguration(
                    cfg => {
                        #region Products mapping.

                        cfg.CreateMap<Products, Product>()
                            .ForMember(dest => dest.ProductId, opc => opc.MapFrom(src => src.Id))
                            .ForMember(dest => dest.ProductName, opc => opc.MapFrom(src => src.Name))
                            .ForMember(dest => dest.ProductDescription, opc => opc.MapFrom(src => src.Description))
                            .ForPath(dest => dest.CompanyName, opc => opc.MapFrom(src => src.Company.Name))
                            .ReverseMap()
                            .ForMember(dest => dest.Id, opc => opc.MapFrom(src => src.ProductId))
                            .ForMember(dest => dest.Name, opc => opc.MapFrom(src => src.ProductName))
                            .ForMember(dest => dest.Description, opc => opc.MapFrom(src => src.ProductDescription))
                            .ForPath(dest => dest.Company.Name, opc => opc.MapFrom(src => src.CompanyName))
                            .ForMember(dest => dest.Price, opc => opc.MapFrom(src => src.Price.ToString(new CultureInfo("en-Us")).ToDecimal()));

                        cfg.CreateMap<AddProduct.Request, Products>()
                            .ForMember(dest => dest.Id, opc => opc.MapFrom(src => src.ProductId))
                            .ForMember(dest => dest.Name, opc => opc.MapFrom(src => src.ProductName))
                            .ForMember(dest => dest.Description, opc => opc.MapFrom(src => src.ProductDescription))
                            .ForMember(dest => dest.Price, opc => opc.MapFrom(src => src.Price.ToString(new CultureInfo("en-Us")).ToDecimal()));
                        #endregion
                        #region Companies mapping.
                        cfg.CreateMap<Companies, Company>()
                            .ForMember(dest => dest.CompanyId, opc => opc.MapFrom(src => src.Id))
                            .ForMember(dest => dest.CompanyName, opc => opc.MapFrom(src => src.Name))
                            .ReverseMap()
                            .ForMember(dest => dest.Id, opc => opc.MapFrom(src => src.CompanyId))
                            .ForMember(dest => dest.Name, opc => opc.MapFrom(src => src.CompanyName));
                        
                        cfg.CreateMap<Companies, GetCompanies.Response>()
                            .ForMember(dest => dest.CompanyId, opc => opc.MapFrom(src => src.Id))
                            .ForMember(dest => dest.CompanyName, opc => opc.MapFrom(src => src.Name));

                        cfg.CreateMap<Companies, GetCompanyId.Response>()
                            .ForMember(dest => dest.CompanyId, opc => opc.MapFrom(src => src.Id))
                            .ForMember(dest => dest.CompanyName, opc => opc.MapFrom(src => src.Name));
                        #endregion
                    })
            );
    }
}