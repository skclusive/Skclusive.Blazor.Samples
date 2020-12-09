using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using Microsoft.MobileBlazorBindings;
using Xamarin.Essentials;
using Xamarin.Forms;
using Skclusive.Reactive.App.View;
using Skclusive.Material.Layout;
using Xam.Reactive.Concurrency;

namespace Skclusive.Reactive.App.Binding
{
    public class AppStartup : Application
    {
        public AppStartup(IFileProvider fileProvider = null)
        {
            var hostBuilder = MobileBlazorBindingsHost.CreateDefaultBuilder()
                .ConfigureServices((hostContext, services) =>
                {
                    // Adds web-specific services such as NavigationManager
                    services.AddBlazorHybrid();

                    services.AddTransient<IWeatherForecastService, BindingWeatherForecastService>();
                    services.TryAddReactiveViewServices
                    (
                        XamarinDispatcherScheduler.Current,
                        new LayoutConfigBuilder()
                        .WithIsServer(false)
                        .WithIsPreRendering(false)
                        .WithResponsive(true)
                        // .WithDisableBinding(true)
                        .Build()
                    );
                })
                .UseWebRoot("wwwroot");

            if (fileProvider != null)
            {
                hostBuilder.UseStaticFiles(fileProvider);
            }
            else
            {
                hostBuilder.UseStaticFiles();
            }
            var host = hostBuilder.Build();

            var contentPage = new ContentPage { Title = "Skclusive Reactive" };
            // hiding the title bar
            NavigationPage.SetHasNavigationBar(contentPage, false);

            MainPage = contentPage;

            host.AddComponent<Main>(parent: MainPage);
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
