using TeamManager.Domain.Entities;
using TeamManager.Domain.Interfaces;
using TeamManager.Infra.Data.Context;

namespace TeamManager.Infra.Data.Repositories;

public class ContractorRepository : IContractorRepository
{
    private ApplicationDbContext _contractorContext;
    public ContractorRepository(ApplicationDbContext context)
    {
        _contractorContext = context;
    }


    public async Task<Contractor> GetById(int? id)
    {
        return await _contractorContext.Contractor.FindAsync(id);
    }

    public async Task<Contractor> Create(Contractor contractor)
    {
        _contractorContext.Add(contractor);
        await _contractorContext.SaveChangesAsync();
        return contractor;
    }

    public async Task<Contractor> Update(Contractor contractor)
    {
        _contractorContext.Update(contractor);
        await _contractorContext.SaveChangesAsync();
        return contractor;
    }

    public async Task<Contractor> Remove(Contractor contractor)
    {
        _contractorContext.Remove(contractor);
        await _contractorContext.SaveChangesAsync();
        return contractor;
    }
}