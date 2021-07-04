using MarketApplicationMVC.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MarketApplicationMVC.Domain.Interface
{
    public interface IForumRepository
    {
        int AddForumThread(ForumThread forumThread);
        ForumThread GetForumThreadById(int id);
        IQueryable<ForumThread> GetAllForumThreads();
        void DeleteForumThread(int id);
        int AddForumPost(ForumPost forumPost);
        ForumPost GetForumPostById(int id);
        IQueryable<ForumPost> GetAllForumPosts();
        void DeleteForumPost(int id);
        void DeactivateThread(int id);
    }
}
