using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using WUSTZone.Domain.Entityies;
using WUSTZone.Domain.Enums;

namespace WUSTZone.Domain.Repositories
{
    public class PostRepositoryDB : IPostRepository
    {
        private readonly AppDbContext context;

        // 依赖注入
        public PostRepositoryDB(AppDbContext context)
        {
            this.context = context;
        }

        public PostRepositoryDB()
        {
        }

        public Post Add(Post post)
        {
            context.Posts.Add(post);
            context.SaveChanges();
            return post;
        }

        public bool Delete(int id)
        {
            Post post = context.Posts.Find(id);
            if(post != null)
            {
                context.Posts.Remove(post);
                context.SaveChanges();
                return true;
            }
            return false;
        }

        public Post GetPost(int id)
        {
            return context.Posts.Find(id);
        }

        public List<Post> GetPostsBySelected()
        {
            return context.Posts
                    .Where(Post => Post.IsSelected == true)
                    .ToList();   
        }

        public List<Post> GetPostsByCategory(CategoryEnum category)
        {
            return context.Posts
                    .Where(Post => Post.Category == category)
                    .ToList();
        }

        public List<Post> GetPostsByUserId(int id)
        {
            return context.Posts
                    .Where(Post => Post.UserId == id)
                    .ToList();
        }

        public Post Update(Post newPost)
        {
            var post = context.Posts.Attach(newPost);
            post.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return newPost;
        }

        public IEnumerable<Post> GetAllPosts()
        {
            return context.Posts;
        }

        public List<Post> GetPostsByTitle(string title)
        {
            return context.Posts
                .Where(Post => EF.Functions.Like(Post.Title,"%"+title+"%")).ToList();
        }

        public List<Post> GetPostsByCategoryAndTimeDesc(CategoryEnum category)
        {
            return context.Posts
                    .Where(Post => Post.Category == category)
                    .OrderByDescending(Post=>Post.TimeStamp)
                    .ToList();
        }

        public List<Post> GetPostsByCategoryAndLikeCount(CategoryEnum category)
        {
            return context.Posts
                   .Where(Post => Post.Category == category)
                   .OrderByDescending(Post => Post.LikeCount)
                   .ToList();
        }

        public List<Post> GetPostsBySelectedAndTimeDesc()
        {
            return context.Posts
                    .Where(Post => Post.IsSelected == true)
                    .OrderByDescending(Post => Post.TimeStamp)
                    .ToList();
        }

        public List<Post> GetPostsBySelectedAndLikeCount()
        {
            return context.Posts
                   .Where(Post => Post.IsSelected == true)
                   .OrderByDescending(Post => Post.LikeCount)
                   .ToList();
        }

        public IEnumerable<Post> GetAllPostsByTimeDesc()
        {
            return context.Posts.OrderByDescending(Post => Post.TimeStamp);
        }

        public IEnumerable<Post> GetAllPostsByLikeCount()
        {
            return context.Posts.OrderByDescending(Post => Post.LikeCount);
        }

        public List<Post> GetPostsByTitleAndTimeDesc(string title)
        {
            return context.Posts
                .Where(Post => EF.Functions.Like(Post.Title, "%" + title + "%"))
                .OrderByDescending(Post => Post.TimeStamp)
                .ToList();
        }

        public List<Post> GetPostsByTitleAndLikeCount(string title)
        {
            return context.Posts
                .Where(Post => EF.Functions.Like(Post.Title, "%" + title + "%"))
                .OrderByDescending(Post => Post.LikeCount)
                .ToList();
        }
    }
}
