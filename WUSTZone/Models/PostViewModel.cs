using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WUSTZone.Models
{
    public class PostViewModel
    {
        /// <summary>
        /// "0": 闲聊
        /// "1": 求助
        /// "2": 树洞
        /// </summary>
        [Required(ErrorMessage ="请选择留言类别")]
        [Display(Name = "留言类别")]
        public int Category { get; set; }

        [Required(ErrorMessage ="请输入标题")]
        [Display(Name ="标题")]
        public string Title { get; set; }

        [Required(ErrorMessage = "内容不能为空")]
        [Display(Name = "内容")]
        public string Content { get; set; }

        [Display(Name ="页面数")]
        public int PageIndex { get; set; }

        /// <summary>
        /// 上传的图片文件
        /// </summary>
        public List<IFormFile> Photos { get; set; }
    }
}
