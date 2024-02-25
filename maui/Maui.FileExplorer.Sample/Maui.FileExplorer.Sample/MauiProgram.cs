using Microsoft.Extensions.Logging;

namespace Maui.FileExplorer.Sample
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fontCollection =>
                {
                    const string param = "OpenSans-Regular.ttf";
                    const string regular = "OpenSansRegular";
                    fontCollection.AddFont(param, regular);
                    fontCollection.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
