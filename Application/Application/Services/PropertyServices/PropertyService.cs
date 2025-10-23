

using Application.Dtos.PropertyDtos;
using Domain.Entities.Property;
using Domain.IRepository;
using System.Diagnostics;
using System.Reflection.Metadata;

namespace Application.Services.PropertyServices;

public class PropertyService : IPropertyServices
{

    #region Ctor

    private readonly IPropertyRepository _propertyRepository;

    public PropertyService(IPropertyRepository propertyRepository)
    {
        _propertyRepository = propertyRepository;
    }

    #endregion

    #region General

    public async Task<PropertyDto> GetPropertyById(Guid id)
    {

        var property = await _propertyRepository.GetPropertyById(id);

        if (property == null)
        {
            throw new Exception("Property Not Found");
        }

        PropertyDto propertyDto = new()
        {

            Id = property.Id,
            Title = property.Title,
            Description = property.Description,
            CityName = property.CityName,
            CityId = property.CityId,
            ProvinceName = property.ProvinceName,
            provinceId = property.provinceId,
            Latitude = property.Latitude,
            Longitude = property.Longitude,
            CreateAt = property.CreateAt,
            OwnerFullName = property.OwnerFullName,
            PropertyTypeName = property.PropertyTypeName,
            PropertyTypeId = property.PropertyTypeId,
            PropertyImages = property.PropertyImages
            .Select(i => new PropertyImageDto
            {
                Id = i.Id,
                ImageUrl = i.ImageUrl
            })
            .ToList()

        };



        return propertyDto;

    }

    public async Task<List<PropertyDto>> GetListOfProperties()
    {
        var properties = await _propertyRepository.GetListOfProperties();

        List<PropertyDto> propertyDtos = new List<PropertyDto>();

        foreach (var property in properties)
        {


            PropertyDto mappedProperty = new()
            {

                Id = property.Id,
                Title = property.Title,
                Description = property.Description,
                CityName = property.CityName,
                CityId = property.CityId,
                ProvinceName = property.ProvinceName,
                provinceId = property.provinceId,
                Latitude = property.Latitude,
                Longitude = property.Longitude,
                CreateAt = property.CreateAt,
                OwnerFullName = property.OwnerFullName,
                PropertyTypeName = property.PropertyTypeName,
                PropertyTypeId = property.PropertyTypeId,
                PropertyImages = property.PropertyImages
                     .Select(i => new PropertyImageDto
                     {
                         Id = i.Id,
                         ImageUrl = i.ImageUrl
                     })
                     .ToList()

            };
            propertyDtos.Add(mappedProperty);

        }

        return propertyDtos;


    }

    public async Task AddProperty(PropertyDto propertyDto)
    {

        PropertyEntity entity = new()
        {

            Title = propertyDto.Title,
            Description = propertyDto.Description,
            CityName = propertyDto.CityName,
            CityId = propertyDto.CityId,
            ProvinceName = propertyDto.ProvinceName,
            provinceId = propertyDto.provinceId,
            Latitude = propertyDto.Latitude,
            Longitude = propertyDto.Longitude,
            CreateAt = propertyDto.CreateAt,
            OwnerFullName = propertyDto.OwnerFullName,
            PropertyTypeName = propertyDto.PropertyTypeName,
            PropertyTypeId = propertyDto.PropertyTypeId,
            PropertyImages = propertyDto.PropertyImages.
                Select(i => new PropertyImageEntity
                {

                    ImageUrl = i.ImageUrl,


                }).ToList()


        };

        await _propertyRepository.AddNewProperty(entity);




    }

    public async Task UpdateProperty(PropertyDto propertyDto)
    {

        var property = await _propertyRepository.GetPropertyById(propertyDto.Id);



        property.Title = propertyDto.Title;
        property.Description = propertyDto.Description;
        property.CityName = propertyDto.CityName;
        property.CityId = propertyDto.CityId;
        property.ProvinceName = propertyDto.ProvinceName;
        property.provinceId = propertyDto.provinceId;
        property.Latitude = propertyDto.Latitude;
        property.Longitude = propertyDto.Longitude;
        property.PropertyTypeName = propertyDto.PropertyTypeName;
        property.PropertyTypeId = propertyDto.PropertyTypeId;

        property.PropertyImages = propertyDto.PropertyImages
       .Select(i => new PropertyImageEntity 
       {
           ImageUrl = i.ImageUrl 
       })
       .ToList();

        await _propertyRepository.UpdateProperty(property);

    }

    public async Task DeleteProperty(Guid Id)
    {
        var property = await _propertyRepository.FindProperty(Id);

        if (property == null)
        {
            throw new Exception("Property Not Found");
        }


        await _propertyRepository.DeleteProperty(property);

    }


    #endregion


    // get by type
    public async Task<List<PropertyDto>> GetAllProperties(Guid typeId) 
    {

        var entitis = await _propertyRepository.GetPropertiesByType(typeId);

        List<PropertyDto> propertyDtos = new List<PropertyDto>();

        foreach (var property in entitis)
        {


            PropertyDto mappedProperty = new()
            {

                Id = property.Id,
                Title = property.Title,
                Description = property.Description,
                CityName = property.CityName,
                CityId = property.CityId,
                ProvinceName = property.ProvinceName,
                provinceId = property.provinceId,
                Latitude = property.Latitude,
                Longitude = property.Longitude,
                CreateAt = property.CreateAt,
                OwnerFullName = property.OwnerFullName,
                PropertyTypeName = property.PropertyTypeName,
                PropertyTypeId = property.PropertyTypeId,
                PropertyImages = property.PropertyImages
                     .Select(i => new PropertyImageDto
                     {
                         Id = i.Id,
                         ImageUrl = i.ImageUrl
                     })
                     .ToList()

            };
            propertyDtos.Add(mappedProperty);

        }

        return propertyDtos;

    }
    

}
