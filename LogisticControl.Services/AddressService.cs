using LogisticControl.Domain.Models;
using LogisticControl.Repository.Interfaces;
using LogisticControl.Services.Interfaces;

namespace LogisticControl.Services;

public class AddressService : IAddressService
{
    private readonly IAddressRepository _addressRepository;
    private readonly IBaseRepository _baseRepository;

    public AddressService(IAddressRepository addressRepository, IBaseRepository baseRepository)
    {
        _addressRepository = addressRepository;
        _baseRepository = baseRepository;
    }

    public void Add(Address entity)
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
    public async Task<Address[]> GetAllAddressesAsync(bool includeCompany = false)
    {
        try
        {
            return await _addressRepository.GetAllAddressesAsync(includeCompany);
        }
        catch (Exception ex)
        {
            throw new Exception($"ERRO: {ex.Message}");
        }
    }
    public async Task<Address[]> GetAddressesAsyncByCompanyId(int companyId, bool includeCompany = false)
    {
        try
        {
            return await _addressRepository.GetAddressesAsyncByCompanyId(companyId, includeCompany);
        }
        catch (Exception ex)
        {
            throw new Exception($"ERRO: {ex.Message}");
        }
    }
    public async Task<Address> GetAddressAsyncById(int addressId, bool includeCompany = false)
    {
        try
        {
            return await _addressRepository.GetAddressAsyncById(addressId, includeCompany);
        }
        catch (Exception ex)
        {
            throw new Exception($"ERRO: {ex.Message}");            
        }
    }
    public void Update(Address entity)
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
    public void Delete(Address entity)
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