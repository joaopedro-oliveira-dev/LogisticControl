using LogisticControl.Domain.Models;
using LogisticControl.Repository.Interfaces;
using LogisticControl.Services.Interfaces;

namespace LogisticControl.Services;

public class CompanyService : ICompanyService
{
    private readonly ICompanyRepository _companyRepository;
    private readonly IBaseRepository _baseRepository;

    public CompanyService (ICompanyRepository companyRepository, IBaseRepository baseRepository)
    {
        _companyRepository = companyRepository;
        _baseRepository = baseRepository;
    }

    public void Add(Company entity)
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
    public async Task<Company[]> GetAllCompaniesAsync(bool includeAddresses = false)
    {
        try
        {
            return await _companyRepository.GetAllCompaniesAsync(includeAddresses);
        }
        catch (Exception ex)
        {
            throw new Exception($"ERRO: {ex.Message}");
        }
    }
    public async Task<Company?> GetCompanyAsyncByAddressId(int addressId, bool includeAddresses = false)
    {
        try
        {
            return await _companyRepository.GetCompanyAsyncByAddressId(addressId, includeAddresses);
        }
        catch (Exception ex)
        {
            throw new Exception($"ERRO: {ex.Message}");
        }
    }
    public async Task<Company?> GetCompanyAsyncById(int companyId, bool includeAddresses = false)
    {
        try
        {
            return await _companyRepository.GetCompanyAsyncById(companyId, includeAddresses);
        }
        catch (Exception ex)
        {
            throw new Exception($"ERRO: {ex.Message}");
        }
    }
    public void Update(Company entity)
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
    public void Delete(Company entity)
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