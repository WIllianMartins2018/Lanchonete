using LanchesWill.Repositories.Interfaces;
using LanchesWill.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace LanchesWill.Controllers
{
    public class LancheController : Controller
    {
        private readonly ILancheRespository _lancheRepository;

        public LancheController(ILancheRespository lancheRepository)
        {
            _lancheRepository = lancheRepository;
        }

        public IActionResult List()
        {
            var lanchesListViewModel = new LancheListViewModel();

            lanchesListViewModel.Lanches = _lancheRepository.Lanches;
            lanchesListViewModel.CategoriaAtual = "Categoria Atual";

            return View(lanchesListViewModel);

        }
    }
}
