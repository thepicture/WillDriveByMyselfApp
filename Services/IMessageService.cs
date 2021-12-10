using System;

namespace WillDriveByMyselfApp.Services
{
    /// <summary>
    /// Defines a method send a message 
    /// and a handler for a new message.
    /// </summary>
    public interface IMessageService
    {
        /// <summary>
        /// Fires when a message has sent.
        /// </summary>
        event Action<object> NewMessage;
        /// <summary>
        /// Sends a message.
        /// </summary>
        /// <param name="message">A message for subscribers.</param>
        void Send(object message);
    }
}
