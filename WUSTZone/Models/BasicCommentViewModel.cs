using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WUSTZone.Models
{
    public class BasicCommentViewModel
    {
        /*
         * 对于评论，要显示：
         * 1. 用户头像
         * 2. 用户名
         * 3. 评论时间
         * 4. 评论内容
         */
        public string UserName { get; set; }
        public string UserPhotoPath { get; set; }
        public DateTime TimeStamp { get; set; }
        public string Content { get; set; }
    }
}
