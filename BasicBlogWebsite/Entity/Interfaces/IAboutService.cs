using BasicBlogWebsite.EntityViewModels;

namespace BasicBlogWebsite.Entity.Interfaces
{
    public interface IAboutService
    {
        Task<AboutPageViewModel> GetAboutAsync();
    }
}
