using AutoMapper;
using BasicBlogWebsite.Entity.Interfaces;
using BasicBlogWebsite.Entity;
using BasicBlogWebsite.EntityViewModels;
using Microsoft.AspNetCore.Mvc;
using BasicBlogWebsite.Controllers;

namespace BasicBlogWebsite.ViewComponents.SocialViewComponent
{
    public class SocialViewComponent:ViewComponent
    {
        private readonly IGenericRepostory<Social> _social;
        private readonly IMapper _mapper;

        public SocialViewComponent(IGenericRepostory<Social> social,IMapper mapper)
        {
            _social = social;
            _mapper = mapper;
        }

        public async Task<IViewComponentResult> InvokeAsync() 
        {
            var socialList = await _social.GetAll();
            var social = socialList.FirstOrDefault();
            var socials = _mapper.Map<SocialViewModel>(social);
            return View(socials); 
        }
    }
}
