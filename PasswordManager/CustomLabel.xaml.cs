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
    /// Interaction logic for CustomLabel.xaml
    /// </summary>
    public partial class CustomLabel : UserControl
    {

        private Style notSelectedLabel, selectedLabel;
        private SolidColorBrush blackColor, redColor;
     
        public CustomLabel()
        {
            InitializeComponent();

            notSelectedLabel = (Style) Resources["notSelectedLabel"];
            selectedLabel = (Style)Resources["selectedLabel"];

            blackColor = new SolidColorBrush(Color.FromRgb(0, 0, 0));
            redColor = new SolidColorBrush(Color.FromRgb(255, 0, 0));

            setStateNotSelected();
        }
        public void setStateNotSelected()
        {
            labelText.Style = notSelectedLabel;
            labelText.Foreground = blackColor;
        }

        public void setStateSelected()
        {
            labelText.Style = selectedLabel;
            labelText.Foreground = blackColor;
        }

        public void setStateError(string errorMessage)
        {
            labelText.Style = selectedLabel;
            labelText.Foreground = redColor;
            labelText.HorizontalAlignment = HorizontalAlignment.Left;
            labelText.Text = errorMessage;
        }

    }
}
