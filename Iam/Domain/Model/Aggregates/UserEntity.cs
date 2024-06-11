using agro_shop.Iam.Domain.Model.Entities;
using agro_shop.Iam.Domain.Model.ValueObjects;
using Org.BouncyCastle.Utilities;

namespace agro_shop.Iam.Domain.Model.Aggregates;

public class UserEntity
{
    public long Id { get;}

    public long Dni { get; private set; }

    public EmailAddress Email { get; private set; }

    public long Telephone { get; private set; }
    
    public PersonName Name { get; private set; }

    public string Password { get; private set; }

    // Usamos la entidad intermedia
    public List<UserRole> UserRoles { get; private set; }
    
    
    public string FullName => Name.FullName;

    public string EmailAddress => Email.Address;
    
    public UserEntity() {}
    
    public UserEntity(long id, long dni, EmailAddress email, long telephone, PersonName name, string password)
    {
        Id = id;
        Dni = dni;
        Email = email;
        Telephone = telephone;
        Name = name;
        Password = password;
        UserRoles= new List<UserRole>();
    }

    public void AddRole(Role role)
    {
        var userRole = new UserRole(this.Id, role.Id);
        UserRoles.Add(userRole);
    }
    
}