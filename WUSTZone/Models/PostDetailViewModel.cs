using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WUSTZone.Domain.Entityies;
using WUSTZone.Domain.Enums;

namespace WUSTZone.Models
{
    /// <summary>
    /// 用于显示帖子详情
    /// 我们需要显示：
    /// 1. 用户名
    /// 2. 用户头像
    /// 3. 发帖时间
    /// 4. 标题
    /// 5. 分类
    /// 6. 文字以及图片内容
    /// 7. 点赞数
    /// 8. 评论数
    /// 9. 所有评论
    /// </summary>
    public class PostDetailViewModel
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        // 完整可直接显示的路径
        public string UserPhotoPath { get; set; }
        public DateTime TimeStamp { get; set; }
        public string Title { get; set; }
        public CategoryEnum Category { get; set; }
        public bool IsSelected { get; set; }
        public string Content { get; set; }
        public List<string> PhotoPaths { get; set; }
        public int LikeCount { get; set; }
        public int CommentCount { get; set; }
        /*
         * 对于评论，要显示：
         * 1. 用户头像
         * 2. 用户名
         * 3. 评论时间
         * 5. 评论内容
         * 6. 楼中楼
         */
        public List<CommentViewModel> Comments { get; set; }
    }
}
