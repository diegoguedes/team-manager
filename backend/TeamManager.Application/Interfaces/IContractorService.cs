using TeamManager.Application.DTOs;

namespace TeamManager.Application.Interfaces;

public interface IContractorService
{
    Task<ContractorDTO> GetById(int? id);

    Task Add(ContractorDTO contractorDto);
    Task Update(ContractorDTO contractorDto);
    Task Remove(int? id);

}