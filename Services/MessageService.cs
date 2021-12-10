using System;

namespace WillDriveByMyselfApp.Services
{
    /// <summary>
    /// Implements a method to send a message 
    /// and subscribe to a new message event.
    /// </summary>
    public class MessageService : IMessageService
    {
        public event Action<object> NewMessage;
        public void Send(object message)
        {
            NewMessage?.Invoke(message);
        }
    }
}
