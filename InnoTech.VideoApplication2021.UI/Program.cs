using InnoTech.VideoApplication2021.Domain.IRepositories;
using InnoTech.VideoApplication2021.Domain.Services;
using InnoTech.VideoApplication2021.SQL.Repositories;
using InnotTech.VideoApplication2021.Core.IServices;
using Microsoft.Extensions.DependencyInjection;

namespace InnoTech.VideoApplication2021.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            /*IVideoRepository repo = new VideoRepository();
            IVideoService service = new VideoService(repo);*/
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddScoped<IVideoRepository, VideoRepository>();
            serviceCollection.AddScoped<IVideoService, VideoService>();
           
            var serviceProvider = serviceCollection.BuildServiceProvider();
            var service = serviceProvider.GetRequiredService<IVideoService>();
            var menu = new Menu(service);
            menu.Start();
        }
    }
}