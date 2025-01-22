using LogisticControl.Domain.Enums;
using LogisticControl.Domain.Models;
using LogisticControl.Repository.Interfaces;
using LogisticControl.Services.Interfaces;

namespace LogisticControl.Services;

public class RouteService : IRouteService
{
    private readonly IRouteRepository _routeRepository;
    private readonly IBaseRepository _baseRepository;

    public RouteService(IRouteRepository routeRepository, IBaseRepository baseRepository)
    {
        _routeRepository = routeRepository;
        _baseRepository = baseRepository;
    }

    public void Add(Route entity)
    {
        try
        {
            entity.Opening = DateTime.Now;
            entity.Realization = null;
            entity.Finalization = null;
            entity.Status = StatusRouteEnum.Pendente;
            _baseRepository.Add(entity);
        }
        catch (Exception ex)
        {
            throw new Exception($"ERRO: {ex.Message}");
        }
    }
    public async Task<Route[]> GetAllRoutesAsync(bool includeDriver = false, bool includeServices = false)
    {
        try
        {
            return await _routeRepository.GetAllRoutesAsync(includeDriver, includeServices);
        }
        catch (Exception ex)
        {
            throw new Exception($"ERRO: {ex.Message}");
        }
    }
    public async Task<Route[]> GetRoutesAsyncByDriverId(int driverId, bool includeDriver = false, bool includeServices = false)
    {
        try
        {
            return await _routeRepository.GetRoutesAsyncByDriverId(driverId, includeDriver, includeServices);
        }
        catch (Exception ex)
        {
            throw new Exception($"ERRO: {ex.Message}");
        }
    }
    public async Task<Route?> GetRouteAsyncByServiceId(int serviceId, bool includeDriver = false, bool includeServices = false)
    {
        try
        {
            return await _routeRepository.GetRouteAsyncByServiceId(serviceId, includeDriver, includeServices);
        }
        catch (Exception ex)
        {
            throw new Exception($"ERRO: {ex.Message}");
        }
    }
    public async Task<Route?> GetRouteAsyncById(int routeId, bool includeDriver = false, bool includeServices = false)
    {
        try
        {
            return await _routeRepository.GetRouteAsyncById(routeId, includeDriver, includeServices);
        }
        catch (Exception ex)
        {
            throw new Exception($"ERRO: {ex.Message}");
        }
    }
    public void Update(Route entity)
    {
        try
        {
            if (entity.Realization > DateTime.Now) 
                throw new Exception("A data de realização da rota não pode ser posterior à data e hora atuais.");
            else if (entity.Finalization > DateTime.Now)
                throw new Exception("A data de finalização da rota não pode ser posterior à data e hora atuais.");
            else
                _baseRepository.Update(entity);
        }
        catch (Exception ex)
        {
            throw new Exception($"ERRO: {ex.Message}");
        }
    }
    public void Delete(Route entity)
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