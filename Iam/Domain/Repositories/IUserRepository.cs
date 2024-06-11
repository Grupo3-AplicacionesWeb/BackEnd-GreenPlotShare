using agro_shop.Iam.Domain.Model.Aggregates;
using agro_shop.Shared.Domain.Repositories;

namespace agro_shop.Iam.Domain.Repositories;

public interface IUserRepository : IBaseRepository<UserEntity>
{
    
}