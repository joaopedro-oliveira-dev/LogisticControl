using LogisticControl.Domain.Models;
using LogisticControl.Repository.Interfaces;
using LogisticControl.Services.Interfaces;

namespace LogisticControl.Services;

public class ServiceService : IServiceService
{
    private readonly IServiceRepository _serviceRepository;
    private readonly IBaseRepository _baseRepository;

    public ServiceService(IServiceRepository serviceRepository, IBaseRepository baseRepository)
    {
        _serviceRepository = serviceRepository;
        _baseRepository = baseRepository;
    }

    public void Add(Service entity)
    {
        try
        {
            _baseRepository.Add(entity);
        }
        catch(Exception ex)
        {
            throw new Exception($"ERRO: {ex.Message}");
        }
    }
    public async Task<Service[]> GetAllServicesAsync(bool includeAddress = false, bool includeRoute = false)
    {
        try
        {
            return await _serviceRepository.GetAllServicesAsync(includeAddress, includeRoute);
        }
        catch (Exception ex)
        {
            throw new Exception($"ERRO: {ex.Message}");
        }
    }
    public async Task<Service[]> GetServicesAsyncByAddressId(int addressId, bool includeAddress = false, bool includeRoute = false)
    {
        try
        {
            return await _serviceRepository.GetServicesAsyncByAddressId(addressId, includeAddress, includeRoute);
        }
        catch (Exception ex)
        {
            throw new Exception($"ERRO: {ex.Message}");
        }
    }
    public async Task<Service[]> GetServicesAsyncByRouteId(int routeId, bool includeAddress = false, bool includeRoute = false)
    {
        try
        {
            return await _serviceRepository.GetServicesAsyncByRouteId(routeId, includeAddress, includeRoute);
        }
        catch (Exception ex)
        {
            throw new Exception($"ERRO: {ex.Message}");
        }
    }
    public async Task<Service> GetServiceAsyncById(int serviceId, bool includeAddress = false, bool includeRoute = false)
    {
        try
        {
            return await _serviceRepository.GetServiceAsyncById(serviceId, includeAddress, includeRoute);
        }
        catch (Exception ex)
        {
            throw new Exception($"ERRO: {ex.Message}");
        }
    }
    public void Update(Service entity)
    {
        try
        {
            _baseRepository.Update(entity);
        }
        catch (Exception ex)
        {
            throw new Exception($"ERRO: {ex.Message}");
        }
    }
    public void Delete(Service entity)
    {
        try
        {
            _baseRepository.Delete(entity);
        }
        catch (Exception ex)
        {
            throw new Exception($"ERRO: {ex.Message}");
        }
    }
    public async Task<bool> SaveChangesAsync()
    {
        try
        {
            return await _baseRepository.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            throw new Exception($"ERRO: {ex.Message}");
        }
    }
}