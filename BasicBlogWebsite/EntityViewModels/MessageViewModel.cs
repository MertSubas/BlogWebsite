﻿namespace BasicBlogWebsite.EntityViewModels
{
    public class MessageViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Content { get; set; }
        public DateTime SendDate { get; set; }
        public bool IsSeen { get; set; }
    
           
    }
}
