using TeamManager.Domain.Validation;

namespace TeamManager.Domain.Entities;

public class TeamMember : Entity
{
    public string Name { get; protected set; }

    public Tag Tag { get; protected set; }

    public TeamMember(string name)
    {
        ValidateDomain(name);
    }
    
    public TeamMember()
    {
    }
    
    public TeamMember(string name,Tag tag)
    {
        ValidateDomain(name, tag);
    }
    
    private void ValidateDomain(string name)
    {
        DomainExceptionValidation.When(string.IsNullOrEmpty(name), "Invalid name. Name is required");

        Name = name;
    }
    private void ValidateDomain(string name, Tag tag)
    {
        ValidateDomain(name); 
        Tag = tag;
    }
}