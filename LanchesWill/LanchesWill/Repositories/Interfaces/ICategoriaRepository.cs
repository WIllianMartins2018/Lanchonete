using LanchesWill.Models;

namespace LanchesWill.Repositories.Interfaces
{
    public interface ICategoriaRepository
    {
        IEnumerable<Categoria> Categorias { get;  }
    }
}
