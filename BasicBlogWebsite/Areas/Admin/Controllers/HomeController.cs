using Microsoft.AspNetCore.Mvc;

namespace BasicBlogWebsite.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        [Area("Admin")]
        public IActionResult HomeIndex()
        {
            return View();
        }
    }
}
