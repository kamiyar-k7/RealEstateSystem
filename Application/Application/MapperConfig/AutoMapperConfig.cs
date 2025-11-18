using Application.Dtos.BlogDtos;
using Application.Dtos.LcoationDtos;
using Application.Dtos.PropertyDtos;
using AutoMapper;
using Domain.Entities.Blog;
using Domain.Entities.Location;
using Domain.Entities.Property;

namespace Application.MapperConfig;

internal class AutoMapperConfig : Profile
{

    public AutoMapperConfig()
    {
        //blog
        CreateMap<BlogDto , BlogEntity>().ReverseMap();
        CreateMap<BlogCategoryDto, BlogCategoryEntity>().ReverseMap();


        //property
        CreateMap<PropertyTypeDto, PropertyTypeEntity>().ReverseMap();


        //location
        CreateMap<ProvinceDto, ProvinceEntity>().ReverseMap();
        CreateMap<CityDto, CityEntity>().ReverseMap();


    }

}
