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

        public void Mapping(Profile profile)
        {
            profile.CreateMap<ForumPost, ForumPostForListVm>()
                .ForMember(s => s.UserName, opt => opt.MapFrom(d => d.User.Name));
        }
    }
}
