using System;
using System.Collections.Generic;
using System.Text;

namespace MarketApplicationMVC.Domain.Model
{
    public class ForumPost
    {
        public int Id { get; set; }
        public string PostContent { get; set; }
        public string UserId { get; set; }
        public int ForumThreadId { get; set; }
        public virtual ForumThread ForumThread { get; set; }
    }
}
