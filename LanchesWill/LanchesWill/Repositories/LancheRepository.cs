using LanchesWill.Context;
using LanchesWill.Models;
using LanchesWill.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LanchesWill.Repositories
{
    public class LancheRepository : ILancheRespository
    {
        private readonly AppDbContext _context;

        public LancheRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Lanche> Lanches => _context.Lanches.Include(c => c.Categoria);

        public IEnumerable<Lanche> LanchesPreferidos => _context.Lanches.
                Where(l => l.IsLanchePreferido).
                Include(c => c.Categoria);

        public Lanche GetLancheById(int lancheid)
        {
            return _context.Lanches.FirstOrDefault(l => l.LancheId == lancheid);
        }
    }
}
