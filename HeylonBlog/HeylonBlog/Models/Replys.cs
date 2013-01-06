using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;

namespace HeylonBlog.Models
{
    public class SubmitReply
    {
        
        public int ArticleReplyID { get; set; }

        [Required(ErrorMessage="评论内容不能为空！")]
        public string ReplyContent { get; set; }

        [Required(ErrorMessage="请输入您的昵称！")]
        public string ReplyUserName { get; set; }

        [RegularExpression(@"^\w+((-\w+)|(\.\w+))*\@[A-Za-z0-9]+((\.|-)[A-Za-z0-9]+)*\.[A-Za-z0-9]+$",ErrorMessage="请输入正确的电子邮箱！")]
        public string ReplyUserEmail { get; set; }

        public DateTime ReplyTime { get; set; }
        public int ArticleID { get; set; }
        public int ToReplyID { get; set; }
        public int Active { get; set; }
        public int UserID { get; set; }

    }
}