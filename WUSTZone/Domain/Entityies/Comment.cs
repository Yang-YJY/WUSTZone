using System;
using System.ComponentModel.DataAnnotations;

namespace WUSTZone.Domain.Entityies
{
    public class Comment
    {
        public int Id { get; set; }

        [Display(Name="留言ID")]
        public int PostId { get; set; }
        
        [Display(Name="发帖ID")]
        public int UserId { get; set; }

       
        /// <summary>
        /// 一级评论为则父Id为0
        /// </summary>
        [Display(Name="上一级评论Id")]
        public int FatherId { get; set; }

        [Display(Name ="评论创建时间")]
        public DateTime TimeStamp { get; set; }

        [Display(Name ="评论内容")]
        public string Content { get; set; }
    }
}
