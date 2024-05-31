using AutoMapper;
using BasicBlogWebsite.Entity;
using BasicBlogWebsite.EntityViewModels;

namespace BasicBlogWebsite.Mapping
{
    public class MappingProfile:Profile
    {
        public MappingProfile() {
            CreateMap<BlogPost, BlogPostViewModel>().ReverseMap();
            CreateMap<Comment, CommentViewModel>().ReverseMap();
            CreateMap<ReplyComment, ReplyCommentViewModel>().ReverseMap();
            CreateMap<Slider, SliderViewModel>().ReverseMap();
            CreateMap<Social, SocialViewModel>().ReverseMap();
            CreateMap<ContactMessage, MessageViewModel>().ReverseMap();
            CreateMap<About, AboutViewModel>().ReverseMap();
            CreateMap<About, AdminAboutViewModel>().ReverseMap();

            CreateMap<Education, EducationViewModel>().ReverseMap();

            CreateMap<Suggestion, SuggestionViewModel>().ReverseMap();

        }
    }
}
