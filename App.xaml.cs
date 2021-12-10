﻿using System.Windows;
using WillDriveByMyselfApp.Services;
using WillDriveByMyselfApp.ViewModels;

namespace WillDriveByMyselfApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            DependencyService.Register<MessageBoxPopupService>();
            DependencyService.Register<NavigationService>();
            DependencyService.Register<MessageService>();

            new MainView().Show();
            DependencyService.Get<NavigationService>().Navigate<ServiceViewModel>();
        }
    }
}
