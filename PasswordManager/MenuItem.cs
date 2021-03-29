using System;
using System.Collections.Generic;
using System.Text;

namespace PasswordManager
{
   public class MenuItem
    {
        private string text;
        private string source;
        private string elementName;
        private int rowIndex;
        private int columnIndex;

        public MenuItem(string text, string source, string elementName)
        {
            this.text = text;
            this.source = source;
            this.elementName = elementName;
            rowIndex = columnIndex = 0;
        }

        public MenuItem(string text, string source, string elementName, int rowIndex, int columnIndex)
        {
            this.text = text;
            this.source = source;
            this.elementName = elementName;
            this.rowIndex = rowIndex;
            this.columnIndex = columnIndex;
        }

        public string ElementName
        {
            get { return elementName; }
            set { elementName = value; }
        }

        public int RowIndex
        {
            get { return rowIndex; }
            set { rowIndex = value; }
        }

        public int ColumnIndex
        {
            get { return columnIndex; }
            set { columnIndex = value; }
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
