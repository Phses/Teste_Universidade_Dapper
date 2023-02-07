using Microsoft.AspNetCore.Mvc;

namespace Universidade.API.Controllers
{
    public class DepartamentoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
