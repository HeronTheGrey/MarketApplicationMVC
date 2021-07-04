using AutoMapper;
using MarketApplicationMVC.Application.Mapping;
using MarketApplicationMVC.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarketApplicationMVC.Application.ViewModel.Forum
{
    public class NewPostVm : IMapFrom<ForumPost>
    {
        public int Id { get; set; }
        public string PostContent { get; set; }
        public int ThreadId { get; set; }
        public string UserId { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<ForumPost, NewPostVm>()
                .ForMember(d => d.ThreadId, opt => opt.MapFrom(s => s.ForumThreadId));

            profile.CreateMap<NewPostVm, ForumPost>()
                .ForMember(d => d.ForumThreadId, opt => opt.MapFrom(s => s.ThreadId));
        }
    }
}
