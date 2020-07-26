using AutoMapper;
using Uibasoft.Smedia.Core.DTOs;
using Uibasoft.Smedia.Core.Entities;

namespace Uibasoft.Smedia.DataAccess.Helpers
{
    public class BasicProfile : Profile
    {
        public BasicProfile()
        {
            CreateMap<Post, PostDto>();
            CreateMap<PostDto, Post>();
        }
    }
}
