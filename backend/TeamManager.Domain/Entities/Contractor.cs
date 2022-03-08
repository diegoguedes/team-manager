using TeamManager.Domain.Validation;

namespace TeamManager.Domain.Entities;

public sealed class Contractor: TeamMember
{
    public int Duration { get; private set; }


    public Contractor(string name, int duration, Tag tag): base(name, tag)
    {
        ValidateDomain(name, duration, tag);
    }
    
    public Contractor(string name, int duration): base(name)
    {
        ValidateDomain(name, duration);
    }
    
    public Contractor(int id, string name, int duration, Tag tag): base(name, tag)
    {
        ValidateDomain(id, name, duration, tag);
    }
    
    public void Update(string name, int duration, Tag tag)
    {
        ValidateDomain(name,duration, tag);
    }
    
    private void ValidateDomain(string name, int duration)
    {
        ValidateDomain(name, duration,null);
    }
    
    private void ValidateDomain(string name, int duration, Tag? tag)
    {
        DomainExceptionValidation.When(string.IsNullOrEmpty(name), "Invalid name. Name is required");
        
        DomainExceptionValidation.When(name.Length < 3, "Invalid name, too short, minimum 3 characters");

        DomainExceptionValidation.When(duration < 0, "Invalid Duration value");
        
        Name = name;
        Duration = duration;
        Tag = tag;
    }
    private void ValidateDomain(int id, string name, int duration, Tag tag)
    {
        DomainExceptionValidation.When(id < 0, "Invalid Id value");
        ValidateDomain(name, duration, tag);

        Id = id;
    }

}