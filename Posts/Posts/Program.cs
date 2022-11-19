using DAL;
using Microsoft.EntityFrameworkCore;
using Posts;
using Service;

class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Services.AddDbContext<DataContext>(options =>
        {
            options.UseNpgsql(builder.Configuration.GetConnectionString("PostgreSql"), sql => { });
        });

        builder.Services.AddAutoMapper(typeof(MapperProfile).Assembly);

        (new ServiceModule()).Registry(builder.Services);

        var app = builder.Build();

        using (var serviceScope = ((IApplicationBuilder)app).ApplicationServices.GetService<IServiceScopeFactory>()
               ?.CreateScope())
        {
            if (serviceScope != null)
            {
                var context = serviceScope.ServiceProvider.GetRequiredService<DataContext>();
                context.Database.Migrate();
            }

        }

        app.UseSwagger();
        app.UseSwaggerUI();

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}
