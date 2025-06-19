using System.Windows;
using Microsoft.Extensions.DependencyInjection;
using DattingLab.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using DattingLab.Infrastructure.Repositories;
using DattingLab.Application.Services;
using DattingLab.AI;

namespace DattingLab.UI
{
    public partial class App : Application
    {
        public ServiceProvider Services { get; private set; } = null!;

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            var services = new ServiceCollection();
            ConfigureServices(services);
            Services = services.BuildServiceProvider();
        }

        private void ConfigureServices(ServiceCollection services)
        {
            services.AddDbContext<AppDbContext>(o => o.UseSqlite("Data Source=app.db"));
            services.AddSingleton<IUserProfileRepository, UserProfileRepository>();
            services.AddSingleton<IGirlProfileRepository, GirlProfileRepository>();
            services.AddSingleton<IChatRepository, ChatRepository>();
            services.AddSingleton<ProfileService>();
            services.AddSingleton<GirlProfileGenerator>(sp =>
                new GirlProfileGenerator(sp.GetRequiredService<IGirlProfileRepository>(),
                    System.IO.Path.Combine(System.AppContext.BaseDirectory, "girl_photos")));
            services.AddSingleton<MatchService>();
            services.AddSingleton<IAiClient, DummyAiClient>();
            services.AddSingleton<ChatService>();
            services.AddSingleton<Views.MainWindow>();
        }
    }
}
