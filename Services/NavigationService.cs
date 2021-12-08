using System;
using WillDriveByMyselfApp.ViewModels;

namespace WillDriveByMyselfApp.Services
{
    /// <summary>
    /// A static class for navigating
    /// to the given view model type.
    /// </summary>
    public static class NavigationService
    {
        public static ViewModelBase SelectedViewModel;
        public static event Action Navigated;

        public static void Navigate<T>()
        {
            SelectedViewModel = (ViewModelBase)Activator.CreateInstance(typeof(T));
            Navigated?.Invoke();
        }
    }
}