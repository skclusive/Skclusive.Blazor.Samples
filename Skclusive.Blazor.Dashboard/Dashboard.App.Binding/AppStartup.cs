using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using Microsoft.MobileBlazorBindings;
using Xamarin.Essentials;
using Xamarin.Forms;
using Skclusive.Dashboard.App.View;
using Skclusive.Core.Component;
using Skclusive.Material.Layout;

namespace Skclusive.Dashboard.App.Binding
{
    public class AppStartup : Application
    {
        public AppStartup(string[] args = null, IFileProvider fileProvider = null)
        {
            var hostBuilder = MobileBlazorBindingsHost.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    // Adds web-specific services such as NavigationManager
                    services.AddBlazorHybrid();

                    services.TryAddDashboardViewServices
                    (
                         new DashboardViewConfigBuilder()
                        .WithIsServer(false)
                        .WithIsPreRendering(false)
                        .WithResponsive(true)
                        .WithTheme(Theme.Auto)
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

            var contentPage = new ContentPage { Title = "Skclusive Material" };
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
