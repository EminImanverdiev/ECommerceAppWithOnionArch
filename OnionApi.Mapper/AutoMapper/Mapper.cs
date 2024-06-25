using AutoMapper;
using AutoMapper.Internal;
using OnionApi.Application.DTOs;
using OnionApi.Application.Features.Products.Queries.GetAllProducts;
using OnionApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OnionApi.Mapper.AutoMapper
{
    public class Mapper : Application.Interfaces.AutoMapper.IMapper
    {
        private readonly IMapper _mapper;

        public Mapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Product, GetAllProductsQueryResponse>()
                   .ForMember(dest => dest.Brand, opt => opt.MapFrom(src => src.Brand != null ? new BrandDto { Name = src.Brand.Name } : null));
                cfg.CreateMap<Brand, BrandDto>();
            });

            _mapper = config.CreateMapper();
        }

        public TDestination Map<TDestination, TSource>(TSource source, string? ignore = null)
        {
            return _mapper.Map<TSource, TDestination>(source);
        }

        public IList<TDestination> Map<TDestination, TSource>(IList<TSource> sources, string? ignore = null)
        {
            return _mapper.Map<IList<TSource>, IList<TDestination>>(sources);
        }

        public TDestination Map<TDestination>(object source, string? ignore = null)
        {
            return _mapper.Map<TDestination>(source);
        }

        public IList<TDestination> Map<TDestination>(IList<object> source, string? ignore = null)
        {
            return _mapper.Map<IList<object>, IList<TDestination>>(source);
        }
    }
}
