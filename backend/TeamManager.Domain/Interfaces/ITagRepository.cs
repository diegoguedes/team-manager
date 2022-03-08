using TeamManager.Domain.Entities;

namespace TeamManager.Domain.Interfaces;

public interface ITagRepository
{
    
    Task<Tag> GetById(int? id);
    Task<Tag> Create(Tag tag);
    Task<Tag> Update(Tag tag);
    Task<Tag> Remove(Tag tag);
}