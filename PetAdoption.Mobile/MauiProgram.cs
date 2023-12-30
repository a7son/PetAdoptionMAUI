using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using PetAdoption.Shared;
using Refit;

namespace PetAdoption.Mobile
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
                    fonts.AddFont("Ubuntu-Regular.ttf", "UbuntuRegular");
                    fonts.AddFont("Ubuntu-Bold.ttf", "UbuntuBold");
                })
                .UseMauiCommunityToolkit();

#if DEBUG
            builder.Logging.AddDebug();
#endif
            RegisterAppDependency(builder.Services);
            ConfigureRefit(builder.Services);
            return builder.Build();
        }

        static void RegisterAppDependency(IServiceCollection services)
        {
            services.AddSingleton<CommonService>();

            services.AddTransient<AuthService>();

            services.AddTransient<LoginRegisterViewModel>()
                    .AddTransient<LoginRegisterPage>();

            services.AddSingleton<HomeViewModel>()
                    .AddSingleton<HomePage>();

            services.AddTransientWithShellRoute<DetailsPage, DetailsViewModel>(nameof(DetailsPage));
        }

        static void ConfigureRefit(IServiceCollection services)
        {
            services.AddRefitClient<IAuthApi>()
                .ConfigureHttpClient(SetHttpClient);

            services.AddRefitClient<IPetApi>()
                .ConfigureHttpClient(SetHttpClient);

            services.AddRefitClient<IUserApi>(ConfigureRefitClient).ConfigureHttpClient(SetHttpClient);

            static void SetHttpClient(HttpClient httpClient) => httpClient.BaseAddress = new Uri(AppConstants.BaseApiUrl);

            static RefitSettings ConfigureRefitClient(IServiceProvider serviceProvider)
            {
                var commonService = serviceProvider.GetRequiredService<CommonService>();
                return new RefitSettings()
                {
                    AuthorizationHeaderValueGetter = (_, __) => Task.FromResult(commonService.Token ?? string.Empty)
                };
            }


        }
    }
}