using TeamManager.Domain.Validation;

namespace TeamManager.Domain.Entities;

public sealed class Employee : TeamMember
{
    public Role Role { get; private set; }
    
    
    public Employee(string name) : base(name)
    {
        ValidateDomain(name);
    }
    public Employee(string name, Role role, Tag? tag) : base(name, tag)
    {
        ValidateDomain(name,role,tag);
    }
    
    public Employee(int id, string name, Role role, Tag? tag): base(name, tag)
    {
        ValidateDomain(id,name, role,tag);
    }
    
    
    
    public void Update(string name, Role role, Tag? tag)
    {
        ValidateDomain(name,role,tag);
    }
    
    private void ValidateDomain(string name)
    {
        ValidateDomain(name, null, null);
    }
    private void ValidateDomain(string name, Role role, Tag? tag)
    {
        DomainExceptionValidation.When(string.IsNullOrEmpty(name), "Invalid name. Name is required");
        
        DomainExceptionValidation.When(name?.Length < 3, "Invalid name, too short, minimum 3 characters");
        
        Name = name;
        Role = role;
        Tag = tag;
    }
    
    private void ValidateDomain(int id,string name, Role role, Tag? tag)
    {
        DomainExceptionValidation.When(id < 0, "Invalid Id value");
        ValidateDomain(name,role,tag);

        Id = id;
    }
}