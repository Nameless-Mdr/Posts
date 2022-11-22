using AutoMapper;
using BLL.Models.Attach;
using BLL.Models.Comment;
using BLL.Models.Like;
using BLL.Models.Post;
using BLL.Models.User;
using Common;
using Domain.Entity;
using Domain.Entity.Attach;
using Domain.Entity.User;

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

            CreateMap<User, GetUserModel>()
                .ForMember(d => d.CountOfPosts, m 
                    => m.MapFrom(s => s.Posts!.Count))
                .ForMember(d => d.AvatarPath, m 
                    => m.MapFrom(s => s.Avatar!.FilePath));

            // Мапинг модели поста
            CreateMap<CreatePostModel, Post>()
                .ForMember(d => d.Id, m
                    => m.MapFrom(s => Guid.NewGuid()))
                .ForMember(d => d.DateCreated, m
                    => m.MapFrom(s => DateTimeOffset.UtcNow));

            CreateMap<Post, GetPostModel>()
                .ForMember(d => d.Comments, m
                    => m.MapFrom(d => d.Comments))
                .ForMember(d => d.PathContents, m 
                    => m.MapFrom(s => s.Contents!.Select(x => x.FilePath)))
                .ForMember(d => d.CountOfLikes, m 
                    => m.MapFrom(s => s.Likes!.Count));

            // Мапинг модели комментария
            CreateMap<CreateCommentModel, Comment>()
                .ForMember(d => d.Id, m
                    => m.MapFrom(s => Guid.NewGuid()))
                .ForMember(d => d.DateCreated, m
                    => m.MapFrom(s => DateTimeOffset.UtcNow));

            CreateMap<Comment, GetCommentModel>()
                .ForMember(d => d.PostText, m 
                    => m.MapFrom(s => s.Text));

            CreateMap<Comment, CommentModel>()
                .ForMember(d => d.Text, m
                    => m.MapFrom(s => s.Text))
                .ForMember(d => d.FirstName, m
                    => m.MapFrom(s => s.Author.FirstName))
                .ForMember(d => d.LastName, m
                    => m.MapFrom(s => s.Author.LastName))
                .ForMember(d => d.DateCreated, m 
                    => m.MapFrom(s => s.DateCreated));

            // Мапинг модели файла
            CreateMap<Attach, Content>();

            CreateMap<Attach, GetAttachModel>();

            // Мапинг модели лайков
            CreateMap<CreateLikeModel, Like>()
                .ForMember(d => d.Id, m 
                    => m.MapFrom(s => Guid.NewGuid()))
                .ForMember(d => d.DateCreated, m
                    => m.MapFrom(s => DateTimeOffset.UtcNow));
        }
    }
}
