using System.Windows.Controls;
using System.Windows.Input;

namespace WillDriveByMyselfApp.Controls
{
    public class NumericTextBox : TextBox
    {
        protected override void OnTextInput(TextCompositionEventArgs e)
        {
            if (!decimal.TryParse(e.Text, out _))
            {
                e.Handled = true;
            }
            base.OnTextInput(e);
        }
    }
}
