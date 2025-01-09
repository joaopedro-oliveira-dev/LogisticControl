using AutoMapper;
using LogisticControl.Domain.Models;
using LogisticControl.Domain.DTOs;

namespace LogisticControl.Core.AutoMapper;

public class ConfigurationMapping : Profile
{
    public ConfigurationMapping()
    {
        CreateMap<AddressGetDTO, Address>().ReverseMap();
        CreateMap<AddressPostDTO, Address>().ReverseMap();
        CreateMap<AddressPutDTO, Address>().ReverseMap();

        CreateMap<CompanyGetDTO, Company>().ReverseMap();
        CreateMap<CompanyPostDTO, Company>().ReverseMap();
        CreateMap<CompanyPutDTO, Company>().ReverseMap();
        
        CreateMap<DriverGetDTO, Driver>().ReverseMap();
        CreateMap<DriverPostDTO, Driver>().ReverseMap();
        CreateMap<DriverPutDTO, Driver>().ReverseMap();
        
        CreateMap<RouteGetDTO, Route>().ReverseMap();
        CreateMap<RoutePostDTO, Route>().ReverseMap();
        CreateMap<RoutePutDTO, Route>().ReverseMap();
        
        CreateMap<ServiceGetDTO, Service>().ReverseMap();
        CreateMap<ServicePostDTO, Service>().ReverseMap();
        CreateMap<ServicePutDTO, Service>().ReverseMap();
        
        CreateMap<UserPostDTO, User>().ReverseMap();
        CreateMap<UserPutDTO, User>().ReverseMap();
        CreateMap<UserPutActiveDTO, User>().ReverseMap();
        CreateMap<LoginDTO, User>().ReverseMap();
    }
}