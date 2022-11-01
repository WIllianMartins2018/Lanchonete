using LanchesWill.Models;
using LanchesWill.Repositories.Interfaces;
using LanchesWill.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LanchesWill.Controllers
{
    public class CarrinhoCompraController : Controller
    {
        private readonly ILancheRespository _lancheRepository;
        private readonly CarrinhoCompra _carrinhoCompra;

        public CarrinhoCompraController(ILancheRespository lancheRepository, CarrinhoCompra carrinhoCompra)
        {
            _lancheRepository = lancheRepository;
            _carrinhoCompra = carrinhoCompra;
        }

        public IActionResult Index()
        {
            var itens = _carrinhoCompra.GetCarrinhoCompraItems();
            _carrinhoCompra.CarrinhoCompraItems = itens;

            var carrinhoCompraVM = new CarrinhoCompraViewModel
            {
                CarrinhoCompra = _carrinhoCompra,
                CarrinhoCompraTotal = _carrinhoCompra.GetCarrinhoCompraTotal()
            };

            return View(carrinhoCompraVM);
        }

        [Authorize]
        public IActionResult AdicionarItemNoCarrinhoCompra(int lancheId)
        {
            var lancheSelecionado = _lancheRepository.Lanches.FirstOrDefault(
                l => l.LancheId == lancheId);

            if (lancheSelecionado != null)
            {
                _carrinhoCompra.AdicionarAoCarrinho(lancheSelecionado);
            }

            return RedirectToAction("Index");
        }

        [Authorize]
        public IActionResult RemoverItemDoCarrinhoCompra(int lancheId)
        {
            var lancheSelecionado = _lancheRepository.Lanches.FirstOrDefault(
                l => l.LancheId == lancheId);

            if (lancheSelecionado != null)
            {
                _carrinhoCompra.RemoverDoCarrinho(lancheSelecionado);
            }

            return RedirectToAction("Index");
        }
    }
}
