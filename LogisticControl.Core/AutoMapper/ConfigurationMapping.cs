using AutoMapper;
using LogisticControl.Domain.Models;
using LogisticControl.Domain.DTOs;

namespace LogisticControl.Core.AutoMapper;

public class ConfigurationMapping : Profile
{
    public ConfigurationMapping()
    {
        CreateMap<AddressPostDTO, Address>().ReverseMap();
        CreateMap<AddressPutDTO, Address>().ReverseMap();
        CreateMap<CompanyPostDTO, Company>().ReverseMap();
        CreateMap<CompanyPutDTO, Company>().ReverseMap();
        CreateMap<DriverPostDTO, Driver>().ReverseMap();
        CreateMap<DriverPutDTO, Driver>().ReverseMap();
        CreateMap<RoutePostDTO, Route>().ReverseMap();
        CreateMap<RoutePutDTO, Route>().ReverseMap();
        CreateMap<ServicePostDTO, Service>().ReverseMap();
        CreateMap<ServicePutDTO, Service>().ReverseMap();
    }
}