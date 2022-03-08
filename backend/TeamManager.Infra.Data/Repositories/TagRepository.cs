using System.Data.Entity;
using Microsoft.EntityFrameworkCore;
using TeamManager.Domain.Entities;
using TeamManager.Domain.Interfaces;
using TeamManager.Infra.Data.Context;

namespace TeamManager.Infra.Data.Repositories;

public class TagRepository: ITagRepository
{
    private ApplicationDbContext _tagContext;
    public TagRepository(ApplicationDbContext context)
    {
        _tagContext = context;
    }

    public async Task<Tag> GetById(int? id)
    {
        return await _tagContext.Tag.FindAsync(id);
    }

    public async Task<Tag> Create(Tag tag)
    {
        _tagContext.Add(tag);
        await _tagContext.SaveChangesAsync();
        return tag;
    }

    public async Task<Tag> Update(Tag tag)
    {
        _tagContext.Update(tag);
        await _tagContext.SaveChangesAsync();
        return tag;
    }

    public async Task<Tag> Remove(Tag tag)
    {
        _tagContext.Remove(tag);
        await _tagContext.SaveChangesAsync();
        return tag;
    }
    
    
}