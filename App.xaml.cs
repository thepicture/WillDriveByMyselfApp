﻿using System.Windows;
using WillDriveByMyselfApp.Services;
using WillDriveByMyselfApp.Stores;
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

            DependencyService.Register<NavigationService>();
            DependencyService.Register<MessageBoxPopupService>();
            DependencyService.Register<ServiceDataStore>();
            DependencyService.Register<MessageService>();
            DependencyService.Register<OpenFileDialogService>();

            new MainView().Show();

            DependencyService.Get<INavigationService>().Navigate<ServiceViewModel>();
        }
    }
}
