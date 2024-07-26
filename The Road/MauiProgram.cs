/* Unmerged change from project 'The Road (net8.0-maccatalyst)'
Before:
using Microsoft.Extensions.Logging;
After:
using The_Road.Repositories;
*/

/* Unmerged change from project 'The Road (net8.0-ios)'
Before:
using Microsoft.Extensions.Logging;
After:
using The_Road.Repositories;
*/

/* Unmerged change from project 'The Road (net8.0-android)'
Before:
using Microsoft.Extensions.Logging;
After:
using The_Road.Repositories;
*/
using The_Road.Repositories;
namespace The_Road
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                })
            .RegisterServices()
            .RegisterViewModels()
            .RegisterViews();

            return builder.Build();
        }

        public static MauiAppBuilder RegisterServices(this MauiAppBuilder mauiAppBuilder)
        {
            mauiAppBuilder.Services.AddSingleton<ITheRoadItemRepository, TheRoadItemRepository>();
            return mauiAppBuilder;
        }
        public static MauiAppBuilder RegisterViewModels(this MauiAppBuilder mauiAppBuilder)
        {
            mauiAppBuilder.Services.AddTransient<ViewModels.MainViewModel>();
            mauiAppBuilder.Services.AddTransient<ViewModels.ItemViewModel>();
            return mauiAppBuilder;
        }
        public static MauiAppBuilder RegisterViews(this MauiAppBuilder mauiAppBuilder)
        {
            mauiAppBuilder.Services.AddTransient<Views.MainView>();
            mauiAppBuilder.Services.AddTransient<Views.ItemView>();
            return mauiAppBuilder;
        }
    }
}
