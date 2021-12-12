using System;
using WillDriveByMyselfApp.ViewModels;

namespace WillDriveByMyselfApp.Services
{
    /// <summary>
    /// Defines methods for navigating.
    /// </summary>
    public interface INavigationService
    {
        /// <summary>
        /// Fires when navigated to a view model or went back.
        /// </summary>
        event Action Navigated;

        ViewModelBase SelectedViewModel { get; set; }
        bool CanGoBack { get; set; }
        /// <summary>
        /// Navigates to a object of the given type.
        /// </summary>
        /// <typeparam name="T">The type to navigate to.</typeparam>
        void Navigate<T>();
        /// <summary>
        /// Navigates to a object with the given object parameter.
        /// </summary>
        /// <typeparam name="T">The type T to navigate to.</typeparam>
        /// <param name="obj">
        /// The object parameter to use in constructor.
        /// </param>
        void Navigate<T>(object obj);

        /// <summary>
        /// Pops the last object from the history and sets 
        /// the current object as a peek.
        /// <exception cref="IndexOutOfRangeException">
        /// Throws 
        /// <see cref="IndexOutOfRangeException">
        /// System.IndexOutOfRangeException
        /// </see> when trying to go back with one element in the history.
        /// </exception>
        /// </summary>
        void GoBack();
    }
}
