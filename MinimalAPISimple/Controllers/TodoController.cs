using Microsoft.AspNetCore.Mvc;

namespace MinimalAPISimple.Controllers
{
    [Route("/todo")]
    public class TodoController : Controller
    {
        public IActionResult Index() {
            return View();
        }
    }
}
