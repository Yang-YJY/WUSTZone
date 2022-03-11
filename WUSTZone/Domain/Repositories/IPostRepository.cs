using System.Collections.Generic;
using WUSTZone.Domain.Entityies;
using WUSTZone.Domain.Enums;

namespace WUSTZone.Domain.Repositories
{
    public interface IPostRepository
    {
        /// <summary>
        /// 增加一条留言
        /// </summary>
        /// <param name="post"></param>
        /// <returns>Post实体类</returns>
        public Post Add(Post post);


        /// <summary>
        /// 根据留言Id删除一条留言
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Delete (int id);


        /// <summary>
        /// 通过留言Id获取留言
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Post类实体</returns>
        public Post GetPost(int id);



        /// <summary>
        /// 根据用户Id来获取留言集合
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Post类实体集合</returns>
        public List<Post> GetPostsByUserId(int id);


        

        /// <summary>
        /// 根据留言类型来获取留言集合
        /// </summary>
        /// <param name="category"></param>
        /// <returns>Post类实体集合</returns>
        public List<Post> GetPostsByCategory(CategoryEnum category);

        /// <summary>
        /// 根据留言类型来获取留言集合，按创造时间降序排列
        /// </summary>
        /// <param name="category"></param>
        /// <returns>Post类实体集合</returns>
        public List<Post> GetPostsByCategoryAndTimeDesc(CategoryEnum category);

        /// <summary>
        /// 根据留言类型来获取留言集合，按点赞数降序排列
        /// </summary>
        /// <param name="category"></param>
        /// <returns>Post类实体集合</returns>
        public List<Post> GetPostsByCategoryAndLikeCount(CategoryEnum category);


        /// <summary>
        /// 获取精选的留言集合
        /// </summary>
        /// <returns>Post类实体集合</returns>
        public List<Post> GetPostsBySelected();


        /// <summary>
        /// 获取精选的留言集合，按创造时间降序排列
        /// </summary>
        /// <returns>Post类实体集合</returns>
        public List<Post> GetPostsBySelectedAndTimeDesc();


        /// <summary>
        /// 获取精选的留言集合，按点赞数降序排列
        /// </summary>
        /// <returns>Post类实体集合</returns>
        public List<Post> GetPostsBySelectedAndLikeCount();

        /// <summary>
        /// 更新留言（点赞数，评论数，精选，置顶）
        /// 内容不做修改
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Post Update(Post post);

        /// <summary>
        /// 获取全部留言（数据量小时测试使用）
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Post> GetAllPosts();

        /// <summary>
        /// 获取全部留言，按创造时间降序排列
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Post> GetAllPostsByTimeDesc();

        /// <summary>
        /// 获取全部留言，按点赞数降序排列
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Post> GetAllPostsByLikeCount();


        /// <summary>
        /// 根据标题模糊查询
        /// </summary>
        /// <param name="title"></param>
        /// <returns></returns>
        public List<Post> GetPostsByTitle(string title);

        /// <summary>
        /// 根据标题模糊查询,按时间降序
        /// </summary>
        /// <param name="title"></param>
        /// <returns></returns>
        public List<Post> GetPostsByTitleAndTimeDesc(string title);

        /// <summary>
        /// 根据标题模糊查询,按点赞数降序
        /// </summary>
        /// <param name="title"></param>
        /// <returns></returns>
        public List<Post> GetPostsByTitleAndLikeCount(string title);

    }
}
