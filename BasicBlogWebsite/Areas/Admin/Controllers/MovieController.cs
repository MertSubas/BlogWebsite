using Microsoft.AspNetCore.Mvc;

namespace BasicBlogWebsite.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MovieController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
