using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using NTierArchitect.Core.Dtos;
using NTierArchitect.Core.Models;

namespace NTierArchitect.Service.Mapping
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<ProductDto, Product>().ReverseMap();
            CreateMap<CategoryDto, Category>().ReverseMap();
            CreateMap<ProductFeatureDto, ProductFeature>().ReverseMap();
        }
    }
}
