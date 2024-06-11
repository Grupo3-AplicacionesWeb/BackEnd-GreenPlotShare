using agro_shop.Iam.Domain.Model.Entities;

namespace agro_shop.Iam.Domain.Model.Commands;

public record RegisterUserCommand(string FirstName, string LastName, string Email, long Dni, long Telephone, string Password, List<Role> Roles);