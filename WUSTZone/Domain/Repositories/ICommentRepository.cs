using System.Collections.Generic;
using WUSTZone.Domain.Entityies;

namespace WUSTZone.Domain.Repositories
{
    public interface ICommentRepository
    {
        /// <summary>
        /// 增加一条评论
        /// </summary>
        /// <param name="comment"></param>
        /// <returns>Comment实体</returns>
       public Comment Add(Comment comment);

        /// <summary>
        /// 删除一条评论
        /// </summary>
        /// <param name="id"></param>
        /// <returns>bool</returns>
       public bool Delete(int id);


        /// <summary>
        /// 获取留言下的所有一级评论
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<Comment> GetByPostId(int id);


        /// <summary>
        /// 获取一级评论下的所有留言
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<Comment> GetByFatherId(int id);

    }
}
