using System.Linq;
using System.Windows.Controls;
using System.Windows.Input;

namespace WillDriveByMyselfApp.Controls
{
    public class TimeTextBox : TextBox
    {
        protected override void OnTextInput(TextCompositionEventArgs e)
        {
            if (!char.IsDigit(e.Text.First()) && e.Text != ":")
            {
                e.Handled = true;
            }
            base.OnTextInput(e);
        }
    }
}
