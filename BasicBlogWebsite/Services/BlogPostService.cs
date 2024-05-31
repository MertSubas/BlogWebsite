﻿using AutoMapper;


using BasicBlogWebsite.Entity;
using BasicBlogWebsite.Entity.Interfaces;
using BasicBlogWebsite.EntityViewModels;

using BasicBlogWebsite.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;




namespace BasicBlogWebsite.Services
{
    public class BlogPostService : IBlogPostService
    {

        private readonly IGenericRepostory<BlogPost> _postory;
        private readonly IGenericRepostory<NewsLatter> _newsrepo;
        private readonly IMapper _mapper;
        private readonly BasicBlogContext _context;
        private DbSet<BlogPost> _dbSet;
        private readonly ICommentService _commentService;

        public BlogPostService(IGenericRepostory<BlogPost> postory, IMapper mapper, BasicBlogContext context, ICommentService commentService, IGenericRepostory<NewsLatter> newsrepo)
        {
            _postory = postory;
            _mapper = mapper;
            this._context = context;
            _dbSet = _context.Set<BlogPost>();
            _commentService = commentService;
            _newsrepo = newsrepo;
        }

        public async Task<(List<BlogPostViewModel> blogPosts, int totalItems)> GetPaginatedBlogPosts(int pageNumber)
        {
            int pageSize = 5; // Her sayfada gösterilecek blog gönderisi sayısı

            var blogList = await _postory.GetAll(); // Tüm blog gönderilerini al
            var totalItems = blogList.ToList().Count; // Toplam blog gönderi sayısı

            var paginatedBlogPosts = blogList.Skip(totalItems - pageNumber * pageSize).Take(pageSize).ToList(); // Belirli sayfa ve sayfa boyutuna göre gönderileri al

            var mappedBlogPosts = _mapper.Map<List<BlogPostViewModel>>(paginatedBlogPosts); // ViewModel'e dönüştür

            return (mappedBlogPosts, totalItems); // Sayfalanan blog gönderilerini ve toplam öğe sayısını döndür
        }

        public async Task<BlogPostViewModel> GetBlogById(int id)
        {
            var blog = await _postory.GetByIdAsync(x => x.BlogId == id);
            BlogPostViewModel mappedBlog = _mapper.Map<BlogPostViewModel>(blog);
            List<CommentViewModel> allComment = await _commentService.GetAllCommentByPostId(id);
            var blogList = await _postory.GetAll();
           var lastFourBlogPosts = blogList.TakeLast(4).ToList();
            mappedBlog.Comments = allComment;
            mappedBlog.Blogs = _mapper.Map<List<BlogPostViewModel>>(lastFourBlogPosts);
            return mappedBlog;

        }
        public async Task<AdminBlogList> GetAll(int pageNumber, int pageSize, Expression<Func<BlogPost, bool>> filter = null, Func<IQueryable<BlogPost>, IOrderedQueryable<BlogPost>> orderby = null, params Expression<Func<BlogPost, object>>[] includes)
        {
            IQueryable<BlogPost> query = _dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (orderby != null)
            {
                query = orderby(query);
            }

            foreach (var table in includes)
            {
                query = query.Include(table);
            }

            // Toplam kayıt sayısını al
            int totalRecords = await query.CountAsync();

            // Sayfalama işlemi için skip ve take ekleniyor
            query = query.Skip((pageNumber - 1) * pageSize)
                         .Take(pageSize);

            // Toplam sayfa sayısını hesapla
            int totalPages = (int)Math.Ceiling((double)totalRecords / pageSize);

            var data = await query.ToListAsync();
            List<BlogPostViewModel> blog = _mapper.Map<List<BlogPostViewModel>>(data);
            // PageResult nesnesini oluştur ve döndür
            return new AdminBlogList
            {
                PageNumber = pageNumber,
                PageSize = totalPages,
                BlogList = blog
            };

        }
        public async Task<BlogPostViewModel> RandomPost()
        {
            var blogList = await _postory.GetAll(x=>x.Status==true);   
            var randomBlog = blogList.OrderBy(x => Guid.NewGuid()).FirstOrDefault();     

            if (randomBlog != null)
            {
                return _mapper.Map<BlogPostViewModel>(randomBlog);

            }
            return null;
        }
        public async Task<List<BlogPostViewModel>> LastFiveBlog()
        {
            var blogList = await _postory.GetAll(x=>x.Status==true,null,x=>x.Comments);
            var lastFiveBlogPosts = blogList.TakeLast(5).ToList();
            lastFiveBlogPosts.Reverse();
            var blogs = _mapper.Map<List<BlogPostViewModel>>(lastFiveBlogPosts);
            return blogs;
        }
        public async Task SendMail(BlogPost post)
        {
               var emails= await _newsrepo.GetAll();
      

            // Her e-posta adresine e-posta gönder
            foreach (var email in emails)
            {
                SendSingleMail(email.Email, post);
            }
        }
    

        private void SendSingleMail(string emailAddress, BlogPost post)
        {
           
            
        }

        public async Task<List<BlogPostViewModel>> SearchBlog(string search)
        {
            var blogs=await _postory.GetAll(x => x.BlogTitle.Contains(search));
            var mapped= _mapper.Map<List<BlogPostViewModel>>(blogs);
            return mapped;
        }
    }
    
}
