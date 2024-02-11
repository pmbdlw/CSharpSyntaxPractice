using Microsoft.AspNetCore.Mvc;

namespace MinimalAPISimple.Controllers
{
    public class TodoController : Controller
    {
        public IActionResult Index() {
            return View();
        }
    }
}
