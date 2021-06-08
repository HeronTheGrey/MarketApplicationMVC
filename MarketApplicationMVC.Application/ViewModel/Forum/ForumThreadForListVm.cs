using AutoMapper;
using MarketApplicationMVC.Application.Mapping;
using MarketApplicationMVC.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarketApplicationMVC.Application.ViewModel.Forum
{
    public class ForumThreadForListVm : IMapFrom<ForumThread>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string AuthorName { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<ForumThread, ForumThreadForListVm>()
                .ForMember(s => s.AuthorName, opt => opt.MapFrom(d => d.User.Name)); //zmienić dla AuthorName
        }
    }
}
