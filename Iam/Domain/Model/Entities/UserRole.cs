using agro_shop.Iam.Domain.Model.Aggregates;

namespace agro_shop.Iam.Domain.Model.Entities;

public class UserRole
{
    public long UserId { get; private set; }
    public UserEntity User { get; private set; }

    public long RoleId { get; private set; }
    public Role Role { get; private set; }

    // Constructor para la entidad intermedia
    public UserRole(long userId, long roleId)
    {
        UserId = userId;
        RoleId = roleId;
    }
}