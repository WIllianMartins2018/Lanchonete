using Microsoft.AspNetCore.Mvc;

namespace LanchesWill.Controllers
{
    public class TesteController : Controller
    {
        public string Index()
        {
            return $"TESTANDO O MÉTODO INDEX TESTECONTROLLER : {DateTime.Now}";
        }
    }
}
