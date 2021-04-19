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
    /// Interaction logic for CustomInputField.xaml
    /// </summary>
    /// 
    public partial class CustomTextBoxField : UserControl
    {

        Style selectedInputFieldStyle;
        

        public CustomTextBoxField() : base()
        {
            InitializeComponent();
          
            selectedInputFieldStyle = (Style)Application.Current.Resources["selectedTextContainer"];
          
            setStateNotSelected(); 
        }

        private void CustomTextBoxField_Loaded(object sender, RoutedEventArgs e)
        {    
            if(IsFieldRequired)
                    InputFieldName += "*";
        }

        private void setStateNotSelected()
        {
            titleLabel.setStateNotSelected();

            inputField.Style = notSelectedTextContainerStyle;
            inputField.Background = new SolidColorBrush(Color.FromRgb(250, 250, 250));

            errorMessage.Visibility = Visibility.Hidden;
            /*if (!parentParent.Children.Contains(this.errorMessage))
                parentParent.Children.Add(this.errorMessage); */

            state = TextContainerState.NotSelected; 
        }

        private void setStateSelected()
        {
            inputField.Style = selectedInputFieldStyle;
            inputField.Background = new SolidColorBrush(Color.FromRgb(241, 241, 241));

            labelText.Style = selectedTextContainerLabelStyle;
            labelText.Foreground = new SolidColorBrush(Color.FromRgb(0, 0, 0));

            clearErrorMessage();
            errorMessageLabel.Visibility = Visibility.Hidden;
            /*  if (!parentParent.Children.Contains(this.errorMessage))
                  parentParent.Children.Add(this.errorMessage); */

            state = TextContainerState.Selected;
        }

        public void displayError(string errorMessage)
        {
            inputField.Style = errorTextContainerStyle;

            labelText.Style = selectedTextContainerLabelStyle;
            labelText.Foreground = new SolidColorBrush(Color.FromRgb(255, 0, 0));

            errorMessageLabel.Visibility = Visibility.Visible;

            //setErrorMessage(errorMessage);
        }

        public string checkIfHasNoErrors()
        {
            if (IsFieldRequired)
            {
                if (inputField.Text != "")
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

        private void inputField_MouseEnter(object sender, MouseEventArgs e)
        {
            inputField.Background = new SolidColorBrush(Color.FromRgb(241, 241, 241));
        }

        private void inputField_MouseLeave(object sender, MouseEventArgs e)
        {
            if (state != TextContainerState.Selected)
                inputField.Background = new SolidColorBrush(Color.FromRgb(250, 250, 250));             
        }

    }
}
