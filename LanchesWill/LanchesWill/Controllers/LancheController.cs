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
            ViewData["Titulo"] = "Todos os Lanches";
            ViewData["Data"] = DateTime.Now;

            var lanches = _lancheRepository.Lanches;
            var totalLanches = lanches.Count();

            ViewBag.Total = "Total de Lanches: ";
            ViewBag.TotalLanches = totalLanches;

            return View(lanches);
        }
    }
}
