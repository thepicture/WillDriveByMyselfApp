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
        public ViewModelBase SelectedViewModel;
        public event Action Navigated;

        public Stack<ViewModelBase> History = new Stack<ViewModelBase>();
        public bool CanGoBack;

        public void Navigate<T>()
        {
            ViewModelBase viewModelToNavigate =
                (ViewModelBase)Activator.CreateInstance(typeof(T));
            History.Push(viewModelToNavigate);
            SelectedViewModel = History.Peek();
            CanGoBack = History.Count > 1;
            Navigated?.Invoke();
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
    }
}