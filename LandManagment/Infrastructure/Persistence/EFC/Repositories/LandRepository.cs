using agro_shop.Shared.Infrastructure.Persistence.EFC.Configuration;
using agro_shop.Shared.Infrastructure.Persistence.EFC.Repositories;
using LandManagement.Domain.Model.Aggregates;
using LandManagement.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace LandManagement.Infrastructure.Persistence.EFC.Repositories;

public class LandRepository(AppDbContext context) : BaseRepository<Land>(context), ILandRepository
{
    public Task<Land?> FindLandByIdAsync(int ownerId)
    {
        return Context.Set<Land>().Where(l => l.Id == ownerId).FirstOrDefaultAsync();
    }
}
