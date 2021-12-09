using System;
using System.Collections.Generic;
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

        public static Stack<ViewModelBase> History = new Stack<ViewModelBase>();
        public static bool CanGoBack;

        /// <summary>
        /// Navigates to the given view model type.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public static void Navigate<T>()
        {
            ViewModelBase viewModelToNavigate =
                (ViewModelBase)Activator.CreateInstance(typeof(T));
            History.Push(viewModelToNavigate);
            SelectedViewModel = History.Peek();
            CanGoBack = History.Count > 1;
            Navigated?.Invoke();
        }

        /// <summary>
        /// Pops the last view model from the history and sets 
        /// the current view model to a new peek.
        /// <exception cref="System.IndexOutOfRangeException">
        /// Throws 
        /// <see cref="IndexOutOfRangeException">
        /// System.IndexOutOfRangeException
        /// </see> when trying to go back with one element in the history.
        /// </exception>
        /// </summary>
        public static void GoBack()
        {
            if (History.Count == 1)
            {
                throw new IndexOutOfRangeException("NavigationService's history is empty");
            }
            History.Pop();
            SelectedViewModel = History.Peek();
            CanGoBack = History.Count > 1;
            Navigated?.Invoke();
        }
    }
}