using System.Collections.Generic;
using System.Linq;
using WUSTZone.Domain.Entityies;

namespace WUSTZone.Domain.Repositories
{
    public class CommentRepositoryDB : ICommentRepository
    {
        private readonly AppDbContext context;

        // 依赖注入
        public CommentRepositoryDB(AppDbContext context)
        {
            this.context = context;
        }

        public Comment Add(Comment comment)
        {
            context.Comments.Add(comment);
            context.SaveChanges();
            return comment;
        }

        public bool Delete(int id)
        {
            Comment comment = context.Comments.Find(id);
            if (comment != null)
            {
                context.Comments.Remove(comment);
                return true;
            }
            return false;
        }
        public List<Comment> GetByPostId(int id)
        {
            return context.Comments
                    .Where(Comment => Comment.PostId == id && Comment.FatherId == 0)
                    .ToList();
        }

        public List<Comment> GetByFatherId(int id)
        {
            return context.Comments
                      .Where(Comment => Comment.FatherId == id)
                      .ToList();
        }

        
    }
}
