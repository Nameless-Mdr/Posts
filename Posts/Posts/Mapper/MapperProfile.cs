using AutoMapper;
using BLL.Models;
using BLL.Models.Attach;
using BLL.Models.Comment;
using BLL.Models.Post;
using BLL.Models.User;
using Common;
using Domain.Entity;
using Domain.Entity.Attach;

namespace Posts.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            // Мапинг модели пользователя
            CreateMap<CreateUserModel, User>()
                .ForMember(d => d.Id, m
                    => m.MapFrom(s => Guid.NewGuid()))
                .ForMember(d => d.PasswordHash, m 
                    => m.MapFrom(s => HashHelper.GetHash(s.Password)))
                .ForMember(d => d.BirthDate, m 
                    => m.MapFrom(s => s.BirthDate.UtcDateTime));

            CreateMap<User, GetUserModel>();

            // Мапинг модели поста
            CreateMap<CreatePostModel, Post>()
                .ForMember(d => d.Id, m
                    => m.MapFrom(s => Guid.NewGuid()))
                .ForMember(d => d.DateCreated, m
                    => m.MapFrom(s => DateTimeOffset.UtcNow));

            CreateMap<Post, GetPostModel>()
                .ForMember(d => d.Attaches, m 
                    => m.MapFrom(d => d.Attaches));

            // Мапинг модели комментария
            CreateMap<CreateCommentModel, Comment>()
                .ForMember(d => d.Id, m
                    => m.MapFrom(s => Guid.NewGuid()))
                .ForMember(d => d.DateCreated, m
                    => m.MapFrom(s => DateTimeOffset.UtcNow));

            CreateMap<Comment, GetCommentModel>();

            CreateMap<Comment, CommentTextModel>();

            // Мапинг модели файла
            CreateMap<Attach, AttachPathModel>();

            CreateMap<Attach, GetAttachModel>();
        }
    }
}
