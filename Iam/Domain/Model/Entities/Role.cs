using agro_shop.Iam.Domain.Model.ValueObjects;

namespace agro_shop.Iam.Domain.Model.Entities;

public class Role
{
    public long Id { get; set; }
    public ERecord Name { get; set; }
    
    public List<UserRole> UserRoles { get; private set; }
    
    public Role(long id, ERecord name)
    {
        Id = id;
        Name = name;
        UserRoles= new List<UserRole>();
    }
    
}