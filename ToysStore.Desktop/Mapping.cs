namespace ToysStore.Desktop
{
    using AutoMapper;
    using System;
    using Models.Requests.Companies;
    using ZAExtensions.Forms.Models;
    public static class Mapping
    {
        public static TDestination ToMap<TSource, TDestination>(this TSource model) =>
            ConfigMapperT().Map<TDestination>(model);

        private static Mapper ConfigMapperT() =>
            new(
                new MapperConfiguration(
                    cfg => {
                        #region GetCompanies.Response to CbxModel
                        cfg.CreateMap<GetCompanies.Response, CbxModel<string, Guid>>()
                            .ForMember(dest => dest.Value, opc => opc.MapFrom(src => src.CompanyId))
                            .ForMember(dest => dest.Display, opc => opc.MapFrom(src => src.CompanyName));
                        #endregion
                    })
            );
    }
}