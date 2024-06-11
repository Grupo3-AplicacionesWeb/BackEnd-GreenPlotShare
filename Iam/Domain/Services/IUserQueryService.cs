using agro_shop.Iam.Domain.Model.Aggregates;
using agro_shop.Iam.Domain.Model.Queries;

namespace agro_shop.Iam.Domain.Services;

public interface IUserQueryService
{
    Task<IEnumerable<UserEntity>> Execute(GetAllUserQuery query);
    
    Task<UserEntity?> Execute(GetUserByIdQuery query);
}