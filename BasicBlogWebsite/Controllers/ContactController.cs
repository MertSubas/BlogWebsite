using BasicBlogWebsite.Entity.Interfaces;
using BasicBlogWebsite.EntityViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BasicBlogWebsite.Controllers
{
    public class ContactController : Controller
    {
        private readonly ICommentService _commentService;

        public ContactController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        public IActionResult Index()
        {
            return View();
        }
        public async Task<JsonResult> SendMessage(MessageViewModel model)
        {
            string msg = await _commentService.SendMessage(model);
            if (msg=="Ok")
            {
                return Json("Ok");
            }
            return Json("No");
        }
        [HttpPost]
        public JsonResult NewsLatter(string email)
        {
            _commentService.AddNewsLatterList(email);
            return Json("Ok");
        }
        
    }
}
