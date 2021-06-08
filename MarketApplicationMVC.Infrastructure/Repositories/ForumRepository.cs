using MarketApplicationMVC.Domain.Interface;
using MarketApplicationMVC.Domain.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MarketApplicationMVC.Infrastructure.Repositories
{
    class ForumRepository : IForumRepository
    {
        private readonly Context _context;
        public ForumRepository(Context context)
        {
            _context = context; 
        }
        
        public int AddForumPost(ForumPost forumPost)
        {
            _context.ForumPosts.Add(forumPost);
            _context.SaveChanges();
            return forumPost.Id;
        }

        public int AddForumThread(ForumThread forumThread)
        {
            _context.ForumThreads.Add(forumThread);
            _context.SaveChanges();
            return forumThread.Id;
        }

        public void DeleteForumPost(int id)
        {
            var post = _context.ForumPosts.Find(id);
            if(post != null)
            {
                _context.ForumPosts.Remove(post);
                _context.SaveChanges();
            }
        }

        public void DeleteForumThread(int id)
        {
            var thread = _context.ForumThreads.Include(e => e.ForumPosts).FirstOrDefault(s => s.Id == id);
            if(thread != null)
            {
                _context.Remove(thread);
                _context.SaveChanges();
            }
        }

        public IQueryable<ForumPost> GetAllForumPosts()
        {
            var posts = _context.ForumPosts;
            return posts;
        }

        public IQueryable<ForumThread> GetAllForumThreads()
        {
            var threads = _context.ForumThreads;
            return threads;
        }


        public ForumPost GetForumPostById(int id)
        {
            var post = _context.ForumPosts.FirstOrDefault(i => i.Id == id);
            return post;
        }

        public ForumThread GetForumThreadById(int id)
        {
            var thread = _context.ForumThreads.Include(e => e.ForumPosts).FirstOrDefault(i => i.Id == id);
            return thread;
        }


    }
}
