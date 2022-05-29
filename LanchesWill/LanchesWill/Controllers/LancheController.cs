using LanchesWill.Repositories.Interfaces;
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
            var lanches = _lancheRepository.Lanches;
            return View(lanches);
        }
    }
}
