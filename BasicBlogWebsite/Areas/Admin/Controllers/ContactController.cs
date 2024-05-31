using BasicBlogWebsite.Entity.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BasicBlogWebsite.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ContactController : Controller
    {
        private readonly ICommentService _commentService;

        public ContactController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        public async Task<JsonResult> SeenMessage(int id)
        {

           await  _commentService.MessageSeen(id);
            return Json("");
        }
    
    }
}
