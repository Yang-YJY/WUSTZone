using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using WUSTZone.Domain.Enums;

namespace WUSTZone.Models
{
    public class PostViewModel
    {
        [Display(Name = "用户ID")]


        public string UserName { get; set; }
        public int UserId { get; set; }

        [Display(Name = "创建时间")]
        public DateTime TimeStamp { get; set; }

        /// <summary>
        /// "0": 默认类别
        /// "1": 闲聊
        /// "2": 求助
        /// "3": 树洞
        /// </summary>
        [Required(ErrorMessage ="请选择留言类别")]
        [Display(Name = "留言类别")]
        public PostEnum Category { get; set; }

        [Display(Name = "点赞数")]
        public int LikeCount { get; set; }

        [Display(Name = "评论数")]
        public int CommentCount { get; set; }

        /// <summary>
        /// "0": 未置顶
        /// "1": 置顶
        /// </summary>
        [Display(Name = "置顶")]
        public bool IsPinned { get; set; }

        /// <summary>
        /// "0": 不是精选
        /// "1": 精选
        /// </summary>
        [Display(Name = "精选")]
        public bool IsSelected { get; set; }

        [Required]
        [Display(Name = "内容")]
        public string Content { get; set; }

        /// <summary>
        /// 将上传的图片路径转为json对象再转为字符串后存入数据库
        /// </summary>
        public List<IFormFile> Photos { get; set; }
    }
}
