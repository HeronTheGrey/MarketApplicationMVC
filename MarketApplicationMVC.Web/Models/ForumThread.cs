using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace MarketApplicationMVC.Web.Models
{
    public class ForumThread
    {
        public ForumThread()
        {

        }

        public ForumThread(int id, string name, string author)
        {
            Id = id;
            Name = name;
            Author = author;
        }

        [DisplayName("Identificator")]
        public int Id { get; set; }
        [DisplayName("Title")]
        public string Name { get; set; }
        public string Author { get; set; }
    }
}
