using DAL.Interfaces;
using DAL.Repositories;
using Domain;
using Microsoft.Extensions.DependencyInjection;
using Service.Implements;
using Service.Interfaces;

namespace Service
{
    public class ServiceModule : IModule
    {
        public void Registry(IServiceCollection services)
        {
            // Сервис пользователя
            services.AddTransient<IUserRepo, UserRepo>();

            services.AddTransient<IUserService, UserService>();

            // Сервис поста
            services.AddTransient<IPostRepo, PostRepo>();

            services.AddTransient<IPostService, PostService>();

            // Сервис комментария
            services.AddTransient<ICommentRepo, CommentRepo>();

            services.AddTransient<ICommentService, CommentService>();

            // Сервис файлов
            services.AddTransient<IAttachRepo, AttachRepo>();

            services.AddTransient<IAttachService, AttachService>();
        }
    }
}
