using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PasswordManager
{
    /// <summary>
    /// Interaction logic for CustomPasswordBoxField.xaml
    /// 
    /// </summary>

    public partial class CustomPasswordBoxField : TextContainerTemplate
    {
        Style selectedTextBoxStyle, selectedPasswordBoxStyle;
        SolidColorBrush strongPassword = new SolidColorBrush(Color.FromRgb(44, 180, 54));
        SolidColorBrush weakPassword = new SolidColorBrush(Color.FromRgb(255, 95, 95));
        SolidColorBrush mediumPassword = new SolidColorBrush(Color.FromRgb(255, 195, 0));
        SolidColorBrush goodPassword = new SolidColorBrush(Color.FromRgb(147, 218, 24));
        SolidColorBrush notSelectedPasswordBoxColor = (SolidColorBrush) Application.Current.FindResource("AppResBlueColor");
        SolidColorBrush selectedPasswordBoxColor = (SolidColorBrush)Application.Current.FindResource("AppResBlackColor");
        


        public CustomPasswordBoxField() : base(new TextBlock())
        {
            InitializeComponent();

            selectedTextBoxStyle = (Style) Application.Current.FindResource("selectedTextBox");
            selectedPasswordBoxStyle = (Style) Application.Current.FindResource("selectedPasswordBox");

            passwordBoxField.Visibility = Visibility.Visible;
            textBoxField.Visibility = Visibility.Hidden;

            labelText.Style = textContainerLabelStyle;
            messageLabel.Style = textContainerLabelStyle;
            setStateNotSelected();
        }

        private void CustomPasswordBoxField_Loaded(object sender, RoutedEventArgs e)
        {
            if (IsFieldRequired)
                InputFieldName += "*";
        }


        private void clearErrorMessage()
        {
            // errorMessage.Text = "";
        }
        private void setErrorMessage(string message)
        {
            //errorMessage.Text = message;
        }

        private void setStateNotSelected()
        {
            passwordBoxField.Style = notSelectedTextContainerStyle;
            passwordBoxField.Background = new SolidColorBrush(Color.FromRgb(250, 250, 250));
            passwordBoxField.BorderBrush = notSelectedPasswordBoxColor;

            textBoxField.Style = notSelectedTextContainerStyle;
            textBoxField.Background = new SolidColorBrush(Color.FromRgb(250, 250, 250));
            textBoxField.BorderBrush = notSelectedPasswordBoxColor;

            labelText.Style = textContainerLabelStyle;
            labelText.Foreground = new SolidColorBrush(Color.FromRgb(0, 0, 0));

            clearErrorMessage();
            messageLabel.Visibility = Visibility.Hidden;
           // messageLabel.HorizontalAlignment = HorizontalAlignment.Right;
            /*if (!parentParent.Children.Contains(this.errorMessage))
                parentParent.Children.Add(this.errorMessage); */

            state = TextContainerState.NotSelected;
        }

        private void setStateSelected()
        {
            passwordBoxField.Style = selectedPasswordBoxStyle;
            //  inputField.Background = new SolidColorBrush(Color.FromRgb(241, 241, 241));
            passwordBoxField.Background = new SolidColorBrush(Color.FromRgb(250, 250, 250));
            passwordBoxField.BorderBrush = selectedPasswordBoxColor;

            textBoxField.Style = selectedTextBoxStyle;
            //  inputField.Background = new SolidColorBrush(Color.FromRgb(241, 241, 241));
            textBoxField.Background = new SolidColorBrush(Color.FromRgb(250, 250, 250));
            textBoxField.BorderBrush = selectedPasswordBoxColor;


            labelText.Style = selectedTextContainerLabelStyle;
            labelText.Foreground = new SolidColorBrush(Color.FromRgb(0, 0, 0));

            clearErrorMessage();
            messageLabel.Visibility = Visibility.Hidden;
         //   messageLabel.HorizontalAlignment = HorizontalAlignment.Right;
            /*  if (!parentParent.Children.Contains(this.errorMessage))
                  parentParent.Children.Add(this.errorMessage); */

            state = TextContainerState.Selected;
        }

        public void displayError(string errorMessage)
        {
            passwordBoxField.Style = errorTextContainerStyle;
            textBoxField.Style = errorTextContainerStyle;

            labelText.Style = selectedTextContainerLabelStyle;
            labelText.Foreground = new SolidColorBrush(Color.FromRgb(255, 0, 0));

            messageLabel.Visibility = Visibility.Visible;
            messageLabel.HorizontalAlignment = HorizontalAlignment.Left;
            messageLabel.Foreground = new SolidColorBrush(Color.FromRgb(255, 0, 0));

            //setErrorMessage(errorMessage);
        }

        public string checkIfHasNoErrors()
        {
            if (IsFieldRequired)
            {
                if (passwordBoxField.Password.ToString() != "")
                    return "";
                else
                    return "Please fill in this field";
            }
            else
                return "";
        }


        private void inputField_GotFocus(object sender, RoutedEventArgs e)
        {
            setStateSelected();
            displayCurrentPassword(sender);
        }

        private void inputField_LostFocus(object sender, RoutedEventArgs e)
        {
            setStateNotSelected();
        }

        private void showPassword(object sender, MouseButtonEventArgs e)
        {
            textBoxField.Text = passwordBoxField.Password.ToString();
            textBoxField.Visibility = Visibility.Visible;
            passwordBoxField.Visibility = Visibility.Hidden;
           // currentCaretPosition = passwordBox
            setStateSelected();
            displayCurrentPassword(passwordBoxField);
        }

        private void hidePassword(object sender, MouseButtonEventArgs e)
        {
            passwordBoxField.Password = textBoxField.Text;
            textBoxField.Visibility = Visibility.Hidden;
            passwordBoxField.Visibility = Visibility.Visible;
            setStateSelected();
            displayCurrentPassword(textBoxField);
        }

        private void displayCurrentPassword(object sender)
        {
            string currentPassword = sender is PasswordBox ? (sender as PasswordBox).Password.ToString() : (sender as TextBox).Text;

            if(currentPassword.Length == 0)
            {
                setStateSelected();
                return;
            }

            if (currentPassword.Length <= 3)
            {
                passwordBoxField.BorderBrush = weakPassword;
                textBoxField.BorderBrush = weakPassword;
                messageLabel.Foreground = weakPassword;
                messageLabel.Text = "Weak";
            }
            else if (currentPassword.Length > 3 && currentPassword.Length <= 6)
            {
                passwordBoxField.BorderBrush = mediumPassword;
                textBoxField.BorderBrush = mediumPassword;
                messageLabel.Foreground = mediumPassword;
                messageLabel.Text = "Medium";
            }
            else if (currentPassword.Length > 6 && currentPassword.Length < 10)
            {
                passwordBoxField.BorderBrush = goodPassword;
                textBoxField.BorderBrush = goodPassword;
                messageLabel.Foreground = goodPassword;
                messageLabel.Text = "Good";
            }
            else
            {
                passwordBoxField.BorderBrush = strongPassword;
                textBoxField.BorderBrush = strongPassword;
                messageLabel.Foreground = strongPassword;
                messageLabel.Text = "Strong";
            }
            messageLabel.HorizontalAlignment = HorizontalAlignment.Right;
            messageLabel.Visibility = Visibility.Visible;
        }

        private void inputField_TextChanged(object sender, RoutedEventArgs e)
        {
            displayCurrentPassword(sender);
        }

        private void inputField_MouseEnter(object sender, MouseEventArgs e)
        {
            if (state != TextContainerState.Selected)
            {
                passwordBoxField.Background = new SolidColorBrush(Color.FromRgb(241, 241, 241));
                textBoxField.Background = new SolidColorBrush(Color.FromRgb(241, 241, 241));
            }
        }

        private void inputField_MouseLeave(object sender, MouseEventArgs e)
        {
            if (state != TextContainerState.Selected)
            {
                passwordBoxField.Background = new SolidColorBrush(Color.FromRgb(250, 250, 250));
                textBoxField.Background = new SolidColorBrush(Color.FromRgb(241, 241, 241));
            }
        }
    }
}
