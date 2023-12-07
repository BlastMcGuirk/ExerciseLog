using ExerciseLog.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MudBlazor.Services;

namespace ExerciseLog
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

            builder.Services.AddMudServices();

#if DEBUG
            builder.Services.AddBlazorWebViewDeveloperTools();
    		builder.Logging.AddDebug();
#endif
            
            builder.Services.AddDbContext<AppDbContext>();

            var app = builder.Build();

            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;

                var context = services.GetRequiredService<AppDbContext>();
                //context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                if (!context.Schedule.Any())
                {
                    context.Schedule.AddRange([
                        new() { Day = "Sunday", },
                        new() { Day = "Monday", },
                        new() { Day = "Tuesday", },
                        new() { Day = "Wednesday", },
                        new() { Day = "Thursday", },
                        new() { Day = "Friday", },
                        new() { Day = "Saturday", },
                    ]);
                    context.SaveChanges();
                }
            }

            return app;
        }
    }
}
