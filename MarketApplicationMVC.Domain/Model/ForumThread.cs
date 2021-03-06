using System;
using System.Collections.Generic;
using System.Text;

namespace MarketApplicationMVC.Domain.Model
{
    public class ForumThread
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public string UserId { get; set; }
        public virtual ICollection<ForumPost> ForumPosts { get; set; }
    }
}
