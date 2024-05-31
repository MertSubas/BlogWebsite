using System.ComponentModel.DataAnnotations;

namespace BasicBlogWebsite.Entity
{
    public class About
    {
        [Key]
        public int AboutId { get; set; }
        public string? AboutTitle { get; set;}
        public string? AboutImage { get; set; }
        public string? AboutContent { get; set; }
        public string? AbountSubTitle { get; set; }
        public string? AbountSubContent { get; set; }
    }
}
