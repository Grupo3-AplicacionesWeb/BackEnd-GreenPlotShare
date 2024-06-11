using agro_shop.Iam.Domain.Model.Aggregates;
using agro_shop.Iam.Domain.Model.Commands;

namespace agro_shop.Iam.Domain.Services;

public interface IUserCommandService
{
    Task<UserEntity?> Execute(RegisterUserCommand command);
}