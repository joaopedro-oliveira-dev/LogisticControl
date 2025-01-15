using LogisticControl.Domain.Models;
using LogisticControl.Repository.Interfaces;
using LogisticControl.Services.Interfaces;

namespace LogisticControl.Services;

public class DriverService : IDriverService
{
    private readonly IDriverRepository _driverRepository;
    private readonly IBaseRepository _baseRepository;

    public DriverService(IDriverRepository driverRepository, IBaseRepository baseRepository)
    {
        _driverRepository = driverRepository;
        _baseRepository = baseRepository;
    }

    public void Add(Driver entity)
    {
        try
        {
            _baseRepository.Add(entity);
        }
        catch (Exception ex)
        {
            throw new Exception($"ERRO: {ex.Message}");
        }
    }
    public async Task<Driver[]> GetAllDriversAsync(bool includeRoutes = false)
    {
        try
        {
            return await _driverRepository.GetAllDriversAsync(includeRoutes);
        }
        catch (Exception ex)
        {
            throw new Exception($"ERRO: {ex.Message}");
        }
    }
    public async Task<Driver?> GetDriverAsyncByRouteId(int routeId, bool includeRoutes = false)
    {
        try
        {
            return await _driverRepository.GetDriverAsyncByRouteId(routeId, includeRoutes);
        }
        catch (Exception ex)
        {
            throw new Exception($"ERRO: {ex.Message}");
        }
    }
    public async Task<Driver?> GetDriverAsyncById(int driverId, bool includeRoutes = false)
    {
        try
        {
            return await _driverRepository.GetDriverAsyncById(driverId, includeRoutes);
        }
        catch (Exception ex)
        {
            throw new Exception($"ERRO: {ex.Message}");
        }
    }
    public void Update(Driver entity)
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
    public void Delete(Driver entity)
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