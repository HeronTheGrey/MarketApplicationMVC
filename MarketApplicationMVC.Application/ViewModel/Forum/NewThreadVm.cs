using AutoMapper;
using FluentValidation;
using MarketApplicationMVC.Application.Mapping;
using MarketApplicationMVC.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarketApplicationMVC.Application.ViewModel.Market
{
    public class NewThreadVm : IMapFrom<ForumThread>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string UserId { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<ForumThread, NewThreadVm>();

            profile.CreateMap<NewThreadVm, ForumThread>();
        }

        public class NewThreadValidator : AbstractValidator<NewThreadVm>
        {
            public NewThreadValidator()
            {
                RuleFor(x => x.Id).NotNull();
                RuleFor(x => x.Name).MaximumLength(100);
            }
        }
    }
}
