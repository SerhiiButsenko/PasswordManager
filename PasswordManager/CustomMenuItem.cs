using System;
using System.Collections.Generic;
using System.Text;

namespace PasswordManager
{
   public class CustomMenuItem
    {
        private string text;
        private string source;
        private string elementName;

        public CustomMenuItem(string text, string source, string elementName)
        {
            this.text = text;
            this.source = source;
            this.elementName = elementName;
        }

        public string ElementName
        {
            get { return elementName; }
            set { elementName = value; }
        }

        public string Text
        {
            get { return text; }
            set { text = value; }
        }

        public string Source
        {
            get { return source; }
            set { source = value; }
        }
    }
}
