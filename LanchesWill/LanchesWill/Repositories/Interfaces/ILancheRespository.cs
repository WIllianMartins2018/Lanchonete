using LanchesWill.Models;

namespace LanchesWill.Repositories.Interfaces
{
    public interface ILancheRespository
    {
        IEnumerable<Lanche> Lanches { get; }
        IEnumerable<Lanche> LanchesPreferidos { get; }
        Lanche GetLancheById(int lancheid);
    }
}
