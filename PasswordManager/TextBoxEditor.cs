using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;



namespace PasswordManager
{
    public class TextBoxEditor : TextContainerEditor
    {
        public TextBoxEditor(StackPanel stackPanel, bool isFieldRequired) : base(stackPanel, isFieldRequired)
        {
            this.textContainer = stackPanel.Children[1] as TextBox;
            this.errorMessage = new TextBlock
            {
                Text = "",
                Style = (Style)Application.Current.MainWindow.Resources["selectedTextBoxLabel"],
                Foreground = new SolidColorBrush(Color.FromRgb(255, 0, 0))
            };
        }

        public TextBox BindedTextBox
        {
            get { return (textContainer as TextBox); }
        }

        public void selectTextBox()
        {
            textContainer.Style = (Style)Application.Current.MainWindow.Resources["normalTextBox"];
            textContainer.BorderBrush = new SolidColorBrush(Color.FromRgb(0, 0, 0));
            textContainer.Background = new SolidColorBrush(Color.FromRgb(241, 241, 241));

            label.Style = (Style) Application.Current.MainWindow.Resources["selectedTextBoxLabel"];
            label.Foreground = new SolidColorBrush(Color.FromRgb(0, 0, 0));

            clearErrorMessage();
            if (stackPanel.Children.Contains(this.errorMessage))
                stackPanel.Children.Remove(this.errorMessage);
            state = TextContainerState.Selected;
        }

        public void unselectTextBox()
        {
            textContainer.Style = (Style)Application.Current.MainWindow.Resources["normalTextBox"];
            textContainer.BorderBrush = new SolidColorBrush(Color.FromRgb(51, 108, 166));
            textContainer.Background = new SolidColorBrush(Color.FromRgb(250, 250, 250));

            label.Style = (Style)Application.Current.MainWindow.Resources["textBoxLabel"];
            label.Foreground = new SolidColorBrush(Color.FromRgb(0, 0, 0));

            state = TextContainerState.NotSelected;
        }

        public void displayError(string errorMessage)
        {
            textContainer.Style = (Style)Application.Current.MainWindow.Resources["errorTextBox"];

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
                if ((textContainer as TextBox).Text != "")
                    return "";
                else
                    return "Please fill in this field";
            }
            else
                return "";
        }
    }
}
