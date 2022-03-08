namespace TeamManager.Domain.Interfaces;

public interface IRepository<T>
{
    Task<T> GetById(int? id);
    Task<T> Create(T t);
    Task<T> Update(T t);
    Task<T> Remove(T t);
}