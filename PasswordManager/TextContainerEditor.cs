using System;
using System.Windows.Controls;
using System.Text;

namespace PasswordManager
{
    public abstract class TextContainerEditor
    {
        protected StackPanel stackPanel;
        protected Control textContainer;
        protected TextBlock errorMessage, label;
        protected TextContainerState state;
        protected bool isFieldRequired;

        public TextContainerEditor(StackPanel stackPanel, bool isFieldRequired)
        {
            this.stackPanel = stackPanel;
            this.label = stackPanel.Children[0] as TextBlock;
            state = TextContainerState.NotSelected;
            this.isFieldRequired = isFieldRequired;
        }

        public TextContainerState State
        {
            get { return state; }
        }

        protected void clearErrorMessage()
        {
            errorMessage.Text = "";
        }

        protected void setErrorMessage(string message)
        {
            errorMessage.Text = message;
        }

       
    }
}
