using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WUSTZone.Models
{
    /// <summary>
    /// Index页面要展示的内容
    /// </summary>
    public class IndexViewModel
    {
        public string Title { get; set; }

        public string UserName { get; set; }

        public DateTime TimeStamp { get; set; }

        public string Category { get; set; }

        public int LikeCount { get; set; }

        public int CommentCount { get; set; }

        public bool IsPinned { get; set; }

        public bool IsSelected { get; set; }

        public string Condensed { get; set; }


        public int PostId { get; set; }
    }
}
