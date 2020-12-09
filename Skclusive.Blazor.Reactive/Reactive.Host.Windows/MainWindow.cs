﻿using Microsoft.MobileBlazorBindings.WebView.Windows;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Platform.WPF;
using Skclusive.Reactive.App.Binding;

namespace Skclusive.Reactive.Host.Windows
{
    public class MainWindow : FormsApplicationPage
    {
        [STAThread]
        public static void Main()
        {
            var app = new System.Windows.Application();
            app.Run(new MainWindow());
        }

        public MainWindow()
        {
            Forms.Init();
            BlazorHybridWindows.Init();
            LoadApplication(new AppStartup());
        }
    }
}