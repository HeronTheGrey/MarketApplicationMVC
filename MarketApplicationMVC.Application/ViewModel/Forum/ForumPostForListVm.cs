using AutoMapper;
using MarketApplicationMVC.Application.Mapping;
using MarketApplicationMVC.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarketApplicationMVC.Application.ViewModel.Forum
{
    public class ForumPostForListVm : IMapFrom<ForumPost>
    {
        public int Id { get; set; }
        public string PostContent { get; set; }
        public string UserName { get; set; }
        public string UserId { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<ForumPost, ForumPostForListVm>();
        }
    }
}
