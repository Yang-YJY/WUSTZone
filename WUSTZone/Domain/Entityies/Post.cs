﻿using System;
using System.ComponentModel.DataAnnotations;

namespace WUSTZone.Domain.Entityies
{
    public class Post
    {
        public int Id { get; set; }

        [Display(Name = "用户ID")]
        public int UserId { get; set; }

        [Display(Name ="创建时间")]
        public DateTime  TimeStamp { get; set; }

        /// <summary>
        /// "0": 默认类别
        /// "1": 闲聊
        /// "2": 求助
        /// "3": 树洞
        /// </summary>
        [Required]
        [Display(Name = "留言类别")]
        public int Category { get; set; }

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
    }
}