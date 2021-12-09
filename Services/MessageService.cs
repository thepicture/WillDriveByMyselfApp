using System;

namespace WillDriveByMyselfApp.Services
{
    public static class MessageService
    {
        public static event Action<object> NewMessage;
        public static void Send(object message)
        {
            NewMessage?.Invoke(message);
        }
    }
}
