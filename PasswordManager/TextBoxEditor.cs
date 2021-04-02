using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;


namespace PasswordManager
{
    public class TextBoxEditor
    {

        private StackPanel stackPanel;
        private TextBox textBox;
        private TextBlock errorMessage, label;
        private TextBoxState state;
        private bool isFieldRequired;
        
        public TextBoxEditor(StackPanel stackPanel, bool isFieldRequired)
        {
            this.stackPanel = stackPanel;
            this.label = stackPanel.Children[0] as TextBlock;
            this.textBox = stackPanel.Children[1] as TextBox;
            state = TextBoxState.NotSelected;
            this.isFieldRequired = isFieldRequired;
            this.errorMessage = new TextBlock
            {
                Text = "Please fill in this field",
                Style = (Style)Application.Current.MainWindow.Resources["selectedTextBoxLabel"],
                Foreground = new SolidColorBrush(Color.FromRgb(255, 0, 0))
            };
        }

        public TextBox BindedTextBox
        {
            get { return textBox; }
        }

        public TextBoxState State
        {
            get { return state; }
        }

        private void clearErrorMessage()
        {
            errorMessage.Text = "";
        }

        private void setErrorMessage(string message)
        {
            errorMessage.Text = message;
        }

        public void select()
        {
            textBox.Style = (Style)Application.Current.MainWindow.Resources["normalTextBox"];
            textBox.BorderBrush = new SolidColorBrush(Color.FromRgb(0, 0, 0));
            textBox.Background = new SolidColorBrush(Color.FromRgb(241, 241, 241));
            label.Style = (Style) Application.Current.MainWindow.Resources["selectedTextBoxLabel"];
            label.Foreground = new SolidColorBrush(Color.FromRgb(0, 0, 0));
            clearErrorMessage();

            if (stackPanel.Children.Contains(this.errorMessage))
                stackPanel.Children.Remove(this.errorMessage);
            state = TextBoxState.Selected;
        }

        public void unselect()
        {
            textBox.Style = (Style)Application.Current.MainWindow.Resources["normalTextBox"];
            textBox.BorderBrush = new SolidColorBrush(Color.FromRgb(51, 108, 166));
            textBox.Background = new SolidColorBrush(Color.FromRgb(250, 250, 250));
            label.Style = (Style)Application.Current.MainWindow.Resources["textBoxLabel"];
            label.Foreground = new SolidColorBrush(Color.FromRgb(0, 0, 0));
            state = TextBoxState.NotSelected;
        }

        public void displayError(string errorMessage)
        {
            textBox.Style = (Style)Application.Current.MainWindow.Resources["errorTextBox"];
            label.Style = (Style)Application.Current.MainWindow.Resources["selectedTextBoxLabel"];
            label.Foreground = new SolidColorBrush(Color.FromRgb(255, 0, 0));
            setErrorMessage(errorMessage);

            if (!stackPanel.Children.Contains(this.errorMessage))
            stackPanel.Children.Add(this.errorMessage); 
        }

        public string checkIfHasNoErrors()
        {
            if (isFieldRequired)
            {
                if (textBox.Text != "")
                    return "";
                else
                    return "Please fill in this field";
            }
            else
                return "";
        }
    }
}
