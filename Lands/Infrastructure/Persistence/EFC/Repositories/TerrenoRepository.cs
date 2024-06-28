using agro_shop.Lands.Domain.Model.Aggregates;
using agro_shop.Lands.Domain.Repositories;
using agro_shop.Shared.Infrastructure.Persistence.EFC.Configuration;
using agro_shop.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace agro_shop.Lands.Infrastructure.Persistence.EFC.Repositories
{
    public class TerrenoRepository : BaseRepository<Terreno>, ITerrenoRepository
    {
        private readonly AppDbContext _context;

        public TerrenoRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Terreno?> FindTerrenoByNombreAsync(string nombre)
        {
            return await _context.Set<Terreno>().FirstOrDefaultAsync(p => p.Nombre == nombre);
        }

        public async Task AddAsync(Terreno terreno)
        {
            await _context.Set<Terreno>().AddAsync(terreno);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Terreno terreno)
        {
            _context.Set<Terreno>().Update(terreno);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var entity = await _context.Set<Terreno>().FindAsync(id);
            if (entity != null)
            {
                _context.Set<Terreno>().Remove(entity);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Terreno> GetByIdAsync(Guid id)
        {
            return await _context.Set<Terreno>().FindAsync(id);
        }

        public async Task<IEnumerable<Terreno>> GetAllAsync()
        {
            return await _context.Set<Terreno>().ToListAsync();
        }
    }
}