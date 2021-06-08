using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MarketApplicationMVC.Domain.Model
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }
        public virtual ICollection<ContactInformation> ContactInformations { get; set; }
        public int? TypeId { get; set; }
        public virtual Type Type { get; set; }
        public virtual Address Address { get; set; }
        public virtual ICollection<ForumPost> ForumPosts { get; set; }
        public virtual ICollection<ForumThread> ForumThreads { get; set; }
        public virtual ICollection<Offer> Offers { get; set; }

    }
}
