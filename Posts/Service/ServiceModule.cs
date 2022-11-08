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
            services.AddTransient<IPostRepo, PostRepo>();

            services.AddTransient<IPostService, PostService>();

            services.AddTransient<ICommentRepo, CommentRepo>();

            services.AddTransient<ICommentService, CommentService>();
        }
    }
}
