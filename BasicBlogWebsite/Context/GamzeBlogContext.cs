using BasicBlogWebsite.Entity;
using BasicBlogWebsite.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BasicBlogWebsite.Context
{
    public class BasicBlogContext:IdentityDbContext<AppUser,AppRole,int>
    {
        public BasicBlogContext(DbContextOptions<BasicBlogContext> options) : base(options) { }

        public DbSet<About> Abouts { get; set; }
        public DbSet<ReplyComment> ReplyComments { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<BlogPost> BlogPosts { get; set; }
        public DbSet<Slider> Sliders { get; set; }
        public DbSet<Social> Socials { get; set; }
        public DbSet<ContactMessage> ContactMessages { get; set; }

        public DbSet<Education> Educations { get; set; }

        public DbSet<Suggestion> Suggestions { get; set; }
        public DbSet<NewsLatter> NewsLatters { get; set; }


    }
}
