using TeamManager.Domain.Entities;

namespace TeamManager.Domain.Interfaces;

public interface IContractorRepository
{
    
    Task<Contractor> GetById(int? id);
    Task<Contractor> Create(Contractor contractor);
    Task<Contractor> Update(Contractor contractor);
    Task<Contractor> Remove(Contractor contractor);
}