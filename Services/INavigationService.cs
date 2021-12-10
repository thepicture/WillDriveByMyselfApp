using System;

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

        /// <summary>
        /// Navigates to a object of the given type.
        /// </summary>
        /// <typeparam name="T">The type to navigate to.</typeparam>
        void Navigate<T>();

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
