using AutoMapper;
using BLL.Models;
using Domain.Entity;
using Domain.Entity.Attach;

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

            CreateMap<CreateCommentModel, Comment>()
                .ForMember(d => d.Id, m
                    => m.MapFrom(s => Guid.NewGuid()));

            CreateMap<Comment, GetCommentModel>();

            CreateMap<Comment, CommentTextModel>();

            CreateMap<Attach, AttachPathModel>();

            CreateMap<Attach, GetAttachModel>();
        }
    }
}
