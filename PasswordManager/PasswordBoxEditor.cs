using Grpc.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;

namespace PasswordManager
{
    public class PasswordBoxEditor : TextContainerEditor
    {
       /* private string currentText;
        private string displayedText;
        private StringBuilder points; */

        public PasswordBoxEditor(StackPanel stackPanel, bool isFieldRequired) : base(stackPanel, isFieldRequired)
        {
            this.textContainer = stackPanel.Children[1] as PasswordBox;
           /* this.errorMessage = new TextBlock
            {
                Text = "",
                Style = (Style)Application.Current.MainWindow.Resources["selectedTextBoxLabel"],
                Foreground = new SolidColorBrush(Color.FromRgb(255, 0, 0))
            }; */
            // this.currentText = this.displayedText = textBox.Text;
            //points = new StringBuilder();
        }

        public PasswordBox BindedPasswordBox
        {
            get { return (textContainer as PasswordBox); }
        }

        /* private string createDisplayedText(string from)
         {
             points.Clear();
             for (int i = 0; i < from.Length; i++)
                 points.Append('.');
             return points.ToString();
         }

         public void changeText()
         {
             //currentText = textBox.Text;
             displayedText = createDisplayedText(currentText);
            // textBox.Text = displayedText;
         }

         public string DisplayedText
         {
             get { return displayedText; }
         } */
    }
}
