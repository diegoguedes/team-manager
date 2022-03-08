using TeamManager.Domain.Validation;

namespace TeamManager.Domain.Entities;

public sealed class Tag : Entity
{
    public string Name { get; private set; }

    public Tag(string name)
    {
        ValidateDomain(name);
        Name = name;
    }
    public Tag(int id, string name)
    {
        ValidateDomain(id);
        ValidateDomain(name);
    }

    public void Update(string name)
    {
        ValidateDomain(name);
    }
    private void ValidateDomain(string name)
    {
        DomainExceptionValidation.When(string.IsNullOrEmpty(name), "Invalid name. Name is required");

        Name = name;
    }
    
    private void ValidateDomain(int id)
    {
        DomainExceptionValidation.When(id < 0, "Invalid Id value");

        Id = id;
    }
    
}