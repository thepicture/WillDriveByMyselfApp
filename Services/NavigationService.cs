using System;
using System.Collections.Generic;
using WillDriveByMyselfApp.ViewModels;

namespace WillDriveByMyselfApp.Services
{
    /// <summary>
    /// Implements methods for navigating 
    /// to the given view model or to go to a previous view model.
    /// </summary>
    public class NavigationService : INavigationService
    {
        public ViewModelBase SelectedViewModel { get; set; }
        public event Action Navigated;

        public Stack<ViewModelBase> History = new Stack<ViewModelBase>();
        public bool CanGoBack { get; set; }

        public void Navigate<T>()
        {
            Navigate<T>(null);
        }

        public void GoBack()
        {
            if (History.Count == 1)
            {
                throw new IndexOutOfRangeException("NavigationService's " +
                    "history is empty");
            }
            _ = History.Pop();
            SelectedViewModel = History.Peek();
            CanGoBack = History.Count > 1;
            Navigated?.Invoke();
        }

        public void Navigate<T>(object obj)
        {
            ViewModelBase viewModelToNavigate;
            if (obj == null)
            {
                viewModelToNavigate =
                (ViewModelBase)Activator.CreateInstance(typeof(T));
            }
            else
            {
                viewModelToNavigate =
                (ViewModelBase)Activator.CreateInstance(typeof(T), obj);
            }
            History.Push(viewModelToNavigate);
            SelectedViewModel = History.Peek();
            CanGoBack = History.Count > 1;
            Navigated?.Invoke();
        }
    }
}