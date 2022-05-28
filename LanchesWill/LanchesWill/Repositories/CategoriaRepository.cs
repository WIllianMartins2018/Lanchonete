using LanchesWill.Context;
using LanchesWill.Models;
using LanchesWill.Repositories.Interfaces;

namespace LanchesWill.Repositories
{
    public class CategoriaRepository : ICategoriaRepository
    {
        private readonly AppDbContext _context;

        public CategoriaRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Categoria> Categorias => _context.Categorias;

    }
}
