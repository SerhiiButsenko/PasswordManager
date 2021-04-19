using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;

namespace PasswordManager
{
    public class TextContainerTemplate : UserControl
    {

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

        protected TextContainerState state;
        protected Style errorTextContainerStyle;
        protected Style notSelectedTextContainerStyle;
        protected Binding labelTextBinding, messageLabelBinding;
        protected TextBlock labelText, messageLabel;
        

        /* protected Style selectedTextBoxStyle, selectedPasswordBoxStyle, notSelectedInputFieldStyle;
         SolidColorBrush strongPassword = new SolidColorBrush(Color.FromRgb(44, 180, 54));
         SolidColorBrush weakPassword = new SolidColorBrush(Color.FromRgb(255, 95, 95));
         SolidColorBrush mediumPassword = new SolidColorBrush(Color.FromRgb(255, 195, 0));
         SolidColorBrush goodPassword = new SolidColorBrush(Color.FromRgb(147, 218, 24));
         SolidColorBrush notSelectedPasswordBoxColor = (SolidColorBrush)Application.Current.FindResource("AppResBlueColor");
         SolidColorBrush selectedPasswordBoxColor = (SolidColorBrush)Application.Current.FindResource("AppResBlackColor"); */
        public TextContainerTemplate()
        {
            state = TextContainerState.NotSelected;

            errorTextContainerStyle = (Style)Application.Current.Resources["errorTextContainer"];
            notSelectedTextContainerStyle = (Style)Application.Current.Resources["notSelectedTextContainer"];

            labelTextBinding = new Binding
            {
                Source = this,
                Path = new PropertyPath("InputFieldName")
            };

            messageLabelBinding = new Binding
            {
                Source = this,
                Path = new PropertyPath("ErrorMessage")
            };
        }

    }
}
