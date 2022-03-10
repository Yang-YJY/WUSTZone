using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WUSTZone.Models
{
    public class CommentViewModel: BasicCommentViewModel
    {
        // 包含主评论和楼中楼
        public List<BasicCommentViewModel> SubComments { get; set; }
    }
}
