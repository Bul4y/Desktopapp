using CapProject.Pages;
using CapProject.Services.DataService;
using CapProject.Viewmodels;
using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using SkiaSharp.Views.Maui.Controls.Hosting;


namespace Desktopapp
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseSkiaSharp(true)
                .UseMauiCommunityToolkit()
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("Poppins-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                    fonts.AddFont("MaterialIcons-Regular.ttf", "MaterialIcon");
                });

            builder.Services.AddScoped<IDataService, DataService>();

            builder.Services.AddTransient<LoadingPage>();
            builder.Services.AddTransient<LoginPage>();
            builder.Services.AddSingleton<Facultyuserpage>();
            builder.Services.AddSingleton<Inventorypage>();
            builder.Services.AddSingleton<Homepage>();

            builder.Services.AddTransient<LoadingViewmodel>();
            builder.Services.AddTransient<LoginpageViewmodel>();
            builder.Services.AddSingleton<FacultypageViewmodel>();
            builder.Services.AddSingleton<HomepageViewmodel>();
            builder.Services.AddSingleton<InvenotorypageViewmodel>();

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}