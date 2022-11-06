using AutoMapper;
using BLL.Models;
using Domain.Entity;

namespace Posts
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<CreatePostModel, Post>()
                .ForMember(d => d.Id, m 
                    => m.MapFrom(s => Guid.NewGuid()));

            CreateMap<Post, GetPostModel>();
        }
    }
}
