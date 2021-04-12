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

    public partial class CustomPasswordBoxField : UserControl
    {
        private TextContainerState state;
        Style textBoxLabelStyle;
        Style selectedTextBoxLabelStyle;
        Style selectedTextBoxStyle, selectedPasswordBoxStyle, notSelectedInputFieldStyle, errorInputFieldStyle;
        SolidColorBrush strongPassword = new SolidColorBrush(Color.FromRgb(44, 180, 54));
        SolidColorBrush weakPassword = new SolidColorBrush(Color.FromRgb(255, 95, 95));
        SolidColorBrush mediumPassword = new SolidColorBrush(Color.FromRgb(255, 195, 0));
        SolidColorBrush goodPassword = new SolidColorBrush(Color.FromRgb(147, 218, 24));
        SolidColorBrush notSelectedPasswordBoxColor = (SolidColorBrush) Application.Current.FindResource("AppResBlueColor");
        SolidColorBrush selectedPasswordBoxColor = (SolidColorBrush)Application.Current.FindResource("AppResBlackColor");
       

        /*--------------------------------------------------------------------------------------------------------------------------------------------------------*/
        /*----------------------------------------------------------------PROPERTIES------------------------------------------------------------------------------*/
        /*--------------------------------------------------------------------------------------------------------------------------------------------------------*/

        public static readonly DependencyProperty InputFieldNameProperty = DependencyProperty.Register(
                    "InputFieldName",
                    typeof(string),
                    typeof(CustomPasswordBoxField));
        public string InputFieldName
        {
            get { return (string)GetValue(InputFieldNameProperty); }
            set { SetValue(InputFieldNameProperty, value); }
        }


        public static readonly DependencyProperty IsFieldRequiredProperty = DependencyProperty.Register(
                   "IsFieldRequired",
                   typeof(bool),
                   typeof(CustomPasswordBoxField));
        public bool IsFieldRequired
        {
            get { return (bool)GetValue(IsFieldRequiredProperty); }
            set { SetValue(IsFieldRequiredProperty, value); }
        }



        public static readonly DependencyProperty ErrorMessageProperty = DependencyProperty.Register(
                  "ErrorMessage",
                  typeof(string),
                  typeof(CustomPasswordBoxField));
        public string ErrorMessage
        {
            get { return (string)GetValue(ErrorMessageProperty); }
            set { SetValue(ErrorMessageProperty, value); }
        }

        /*--------------------------------------------------------------------------------------------------------------------------------------------------------*/
        /*--------------------------------------------------------------------------------------------------------------------------------------------------------*/
        /*--------------------------------------------------------------------------------------------------------------------------------------------------------*/

        public CustomPasswordBoxField()
        {
            InitializeComponent();
            this.DataContext = this;

            textBoxLabelStyle = (Style)Application.Current.Resources["textContainerLabel"];
            selectedTextBoxLabelStyle = (Style)Application.Current.Resources["selectedTextContainerLabel"];

            selectedTextBoxStyle = (Style)Resources["selectedTextBox"];
            selectedPasswordBoxStyle = (Style)Resources["selectedPasswordBox"];
            notSelectedInputFieldStyle = (Style)Application.Current.Resources["notSelectedTextContainer"];
            errorInputFieldStyle = (Style)Application.Current.Resources["errorTextContainer"];


            Binding labelTextBinding = new Binding();
            labelTextBinding.Source = this;
            labelTextBinding.Path = new PropertyPath("InputFieldName");
            labelText.SetBinding(TextBlock.TextProperty, labelTextBinding);


            Binding errorMessageLabelBinding = new Binding();
            errorMessageLabelBinding.Source = this;
            errorMessageLabelBinding.Path = new PropertyPath("ErrorMessage");
            errorMessageLabel.SetBinding(TextBlock.TextProperty, errorMessageLabelBinding);

            passwordBoxField.Visibility = Visibility.Visible;
            textBoxField.Visibility = Visibility.Hidden;

            state = TextContainerState.NotSelected;
            labelText.Style = textBoxLabelStyle;
            errorMessageLabel.Style = textBoxLabelStyle;
            //Binding:     this.isFieldRequired = isFieldRequired;      
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
            passwordBoxField.Style = notSelectedInputFieldStyle;
            passwordBoxField.Background = new SolidColorBrush(Color.FromRgb(250, 250, 250));
            passwordBoxField.BorderBrush = notSelectedPasswordBoxColor;

            textBoxField.Style = notSelectedInputFieldStyle;
            textBoxField.Background = new SolidColorBrush(Color.FromRgb(250, 250, 250));
            textBoxField.BorderBrush = notSelectedPasswordBoxColor;

            labelText.Foreground = new SolidColorBrush(Color.FromRgb(0, 0, 0));

            clearErrorMessage();
            errorMessageLabel.Visibility = Visibility.Hidden;
            errorMessageLabel.HorizontalAlignment = HorizontalAlignment.Right;
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


            labelText.Style = selectedTextBoxLabelStyle;
            labelText.Foreground = new SolidColorBrush(Color.FromRgb(0, 0, 0));

            clearErrorMessage();
            errorMessageLabel.Visibility = Visibility.Hidden;
            errorMessageLabel.HorizontalAlignment = HorizontalAlignment.Right;
            /*  if (!parentParent.Children.Contains(this.errorMessage))
                  parentParent.Children.Add(this.errorMessage); */

            state = TextContainerState.Selected;
        }

        public void displayError(string errorMessage)
        {
            passwordBoxField.Style = errorInputFieldStyle;
            textBoxField.Style = errorInputFieldStyle;



            labelText.Style = selectedTextBoxLabelStyle;
            labelText.Foreground = new SolidColorBrush(Color.FromRgb(255, 0, 0));

            errorMessageLabel.Visibility = Visibility.Visible;
            errorMessageLabel.HorizontalAlignment = HorizontalAlignment.Left;

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
            setStateSelected();
        }

        private void hidePassword(object sender, MouseButtonEventArgs e)
        {
            passwordBoxField.Password = textBoxField.Text;
            textBoxField.Visibility = Visibility.Hidden;
            passwordBoxField.Visibility = Visibility.Visible;
            setStateSelected();
        }

        private void inputField_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if(passwordBoxField.Password.Length <= 3)
            {
                passwordBoxField.BorderBrush = weakPassword;
                textBoxField.BorderBrush = weakPassword;
            } else if(passwordBoxField.Password.Length > 3 && passwordBoxField.Password.Length <= 6)
            {
                passwordBoxField.BorderBrush = mediumPassword;
                textBoxField.BorderBrush = mediumPassword;
            }
            else if (passwordBoxField.Password.Length > 6 && passwordBoxField.Password.Length < 10)
            {
                passwordBoxField.BorderBrush = goodPassword;
                textBoxField.BorderBrush = goodPassword;
            } else
            {
                passwordBoxField.BorderBrush = strongPassword;
                textBoxField.BorderBrush = strongPassword;
            }
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
