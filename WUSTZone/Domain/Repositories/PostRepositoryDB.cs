using System.Collections.Generic;
using System.Linq;
using WUSTZone.Domain.Entityies;

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

        public List<Post> GetPostsByCategory(int category)
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
    }
}
