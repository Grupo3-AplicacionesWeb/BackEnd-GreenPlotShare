using agro_shop.Iam.Domain.Model.Aggregates;
using agro_shop.Iam.Domain.Repositories;
using agro_shop.Shared.Infrastructure.Persistence.EFC.Configuration;
using agro_shop.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace agro_shop.Iam.Infrastructure.Persistence.EFC.Repository;

public class UserRepository(AppDbContext context) : BaseRepository<UserEntity>(context), IUserRepository;