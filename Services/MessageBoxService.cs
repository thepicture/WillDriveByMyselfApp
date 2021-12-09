using System.Windows;

namespace WillDriveByMyselfApp.Services
{
    public class MessageBoxService : IMessageService
    {
        public void ShowError(string message)
        {
            _ = MessageBox.Show(message,
                                "Ошибка",
                                MessageBoxButton.OK,
                                MessageBoxImage.Error);
        }

        public void ShowInfo(string message)
        {
            _ = MessageBox.Show(message,
                                "Информация",
                                MessageBoxButton.OK,
                                MessageBoxImage.Information);
        }

        public bool ShowQuestion(string message)
        {
            return MessageBox.Show(message,
                                   "Вопрос",
                                   MessageBoxButton.OK,
                                   MessageBoxImage.Error) == MessageBoxResult.Yes;
        }

        public void ShowWarning(string message)
        {
            _ = MessageBox.Show(message,
                                "Предупреждение",
                                MessageBoxButton.OK,
                                MessageBoxImage.Warning);
        }
    }
}
