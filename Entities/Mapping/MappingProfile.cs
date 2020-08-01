using AutoMapper;
using Entities.Enums;
using Entities.Models;
using Entities.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entities.Mapping
{
    public class MappingProfile : Profile
    {
        
        public MappingProfile()
        {
            CreateMap<Project, ProjectVM>()
                .ForMember(opt => opt.Users, src => src.MapFrom(x => x.Users.Select(j => j.ApplicationUser.FirstName+" "+ j.ApplicationUser.LastName).ToList()));
            //CreateMap<ProjectVM, Project>();

            CreateMap<ProjectCreateIM, Project>()
                .ForMember(opt=>opt.Users,src=>src.MapFrom(x=>x.Users.Select(j=>new ProjectUser() { UserId=j})));
        }
    }
}
