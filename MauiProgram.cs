using Microsoft.Extensions.Logging;
using TheChoppingNote.ViewModels;

namespace TheChoppingNote
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
                });
            builder.Services.AddSingleton<MainPage>();
            builder.Services.AddSingleton<RecipiesPage>();
            builder.Services.AddSingleton<RecipieDetailsPage>();

            builder.Services.AddTransient<MainViewModel>();

            builder.Services.AddTransient<RecipieListViewModel>();
            builder.Services.AddTransient<RecipieDetailsViewModel>();
#if DEBUG
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
