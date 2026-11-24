using Microsoft.Extensions.Logging;
using sqliteOrnekProje.Services;       //bunu unutma, bağlantı

namespace sqliteOrnekProje
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
                });

            builder.Services.AddMauiBlazorWebView();
            builder.Services.AddSingleton<DatabaseService>();   //DatabaseService sınıfını uygulamaya tanıtır. Singleton yapısı sayesinde uygulama çalıştığı sürece hafızada tek bir servis örneği tutulur ve tüm sayfalar aynı veritabanı bağlantısını kullanır.
            builder.Services.AddSingleton<IletisimService>();   //IletisimService sınıfını uygulamaya tanıtıyoruz

#if DEBUG
            builder.Services.AddBlazorWebViewDeveloperTools();
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
