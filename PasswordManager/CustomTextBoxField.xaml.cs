﻿using System;
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

        private TextContainerState state;
        Style textBoxLabelStyle;
        Style selectedTextBoxLabelStyle;
        Style selectedInputFieldStyle, notSelectedInputFieldStyle, errorInputFieldStyle;


        /*--------------------------------------------------------------------------------------------------------------------------------------------------------*/
        /*----------------------------------------------------------------PROPERTIES------------------------------------------------------------------------------*/
        /*--------------------------------------------------------------------------------------------------------------------------------------------------------*/

        public static readonly DependencyProperty InputFieldNameProperty = DependencyProperty.Register(
                    "InputFieldName",
                    typeof(string),
                    typeof(CustomTextBoxField));
        public string InputFieldName
        {
            get { return (string)GetValue(InputFieldNameProperty); }
            set { SetValue(InputFieldNameProperty, value); }
        }



        public static readonly DependencyProperty IsFieldRequiredProperty = DependencyProperty.Register(
                   "IsFieldRequired",
                   typeof(bool),
                   typeof(CustomTextBoxField));
        public bool IsFieldRequired
        {
            get { return (bool)GetValue(IsFieldRequiredProperty); }
            set { SetValue(IsFieldRequiredProperty, value); }
        }



        public static readonly DependencyProperty ErrorMessageProperty = DependencyProperty.Register(
                  "ErrorMessage",
                  typeof(string),
                  typeof(CustomTextBoxField));
        public string ErrorMessage
        {
            get { return (string)GetValue(ErrorMessageProperty); }
            set { SetValue(ErrorMessageProperty, value); }
        }

        /*--------------------------------------------------------------------------------------------------------------------------------------------------------*/
        /*--------------------------------------------------------------------------------------------------------------------------------------------------------*/
        /*--------------------------------------------------------------------------------------------------------------------------------------------------------*/

        public CustomTextBoxField()
        {
            InitializeComponent();
            this.DataContext = this;

            textBoxLabelStyle = (Style)Application.Current.MainWindow.Resources["textBoxLabel"];
            selectedTextBoxLabelStyle = (Style)Application.Current.MainWindow.Resources["selectedTextBoxLabel"];
            
            selectedInputFieldStyle = new Style(inputField.GetType(), (Style)Application.Current.MainWindow.Resources["selectedTextBox"]);
            notSelectedInputFieldStyle = new Style(inputField.GetType(), (Style)Application.Current.MainWindow.Resources["notSelectedTextBox"]);
            errorInputFieldStyle = new Style(inputField.GetType(), (Style)Application.Current.MainWindow.Resources["errorTextBox"]);

            Binding labelTextBinding = new Binding();
            labelTextBinding.Source = this;
            labelTextBinding.Path = new PropertyPath("InputFieldName");
            labelText.SetBinding(TextBlock.TextProperty, labelTextBinding);
            

            Binding errorMessageLabelBinding = new Binding();
            errorMessageLabelBinding.Source = this;
            errorMessageLabelBinding.Path = new PropertyPath("ErrorMessage");
            errorMessageLabel.SetBinding(TextBlock.TextProperty, errorMessageLabelBinding);

            state = TextContainerState.NotSelected;
            labelText.Style = textBoxLabelStyle;
            errorMessageLabel.Style = textBoxLabelStyle;
            //Binding:     this.isFieldRequired = isFieldRequired;      
            setStateNotSelected(); 
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            if(IsFieldRequired)
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
            inputField.Style = notSelectedInputFieldStyle;
            inputField.Background = new SolidColorBrush(Color.FromRgb(250, 250, 250));

            labelText.Foreground = new SolidColorBrush(Color.FromRgb(0, 0, 0));

            clearErrorMessage();
            errorMessageLabel.Visibility = Visibility.Hidden;
            /*if (!parentParent.Children.Contains(this.errorMessage))
                parentParent.Children.Add(this.errorMessage); */

            state = TextContainerState.NotSelected; 
        }

        private void setStateSelected()
        {
            inputField.Style = selectedInputFieldStyle;
            inputField.Background = new SolidColorBrush(Color.FromRgb(241, 241, 241));

            labelText.Style = selectedTextBoxLabelStyle;
            labelText.Foreground = new SolidColorBrush(Color.FromRgb(0, 0, 0));

            clearErrorMessage();
            errorMessageLabel.Visibility = Visibility.Hidden;
            /*  if (!parentParent.Children.Contains(this.errorMessage))
                  parentParent.Children.Add(this.errorMessage); */

            state = TextContainerState.Selected;
        }

        public void displayError(string errorMessage)
        {
            inputField.Style = errorInputFieldStyle;

            labelText.Style = selectedTextBoxLabelStyle;
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