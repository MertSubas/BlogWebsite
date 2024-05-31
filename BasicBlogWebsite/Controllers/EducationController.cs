using BasicBlogWebsite.Entity.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BasicBlogWebsite.Controllers
{
    public class EducationController : Controller
    {
        private readonly IEducationService _educationService;

        public EducationController(IEducationService educationService)
        {
            _educationService = educationService;
        }

        public async Task<IActionResult> Index()
        {
            var educations= await _educationService.GetAlltrue();
            return View(educations);
        }
    }
}
