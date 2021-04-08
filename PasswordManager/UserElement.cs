using System;
using System.Collections.Generic;
using System.Text;

namespace PasswordManager
{
   public class UserElement
    {
        private string title;
        private string comment;
        private Uri imageSource;
        private int gridRow;
        private int gridColumn;


        public UserElement(string title)
        {
            this.title = title;
        }

        public UserElement(string title, string comment, Uri imageSource)
        {
            this.title = title;
            this.comment = comment;
            this.imageSource = imageSource;
            this.gridRow = this.gridColumn = -1;
        }

        public UserElement(string title, string comment, Uri imageSource, int gridRow, int gridColumn)
        {
            this.title = title;
            this.comment = comment;
            this.imageSource = imageSource;
            this.gridRow = gridRow;
            this.gridColumn = gridColumn;
        }     

        public int GridRow
        {
            get { return gridRow; }
            set { gridRow = value; }
        }

        public int GridColumn
        {
            get { return gridColumn; }
            set { gridColumn = value; }
        }

        public string Title
        {
            get { return title; }
            set { title = value; }
        }

        public string Comment
        {
            get { return comment; }
            set { comment = value; }
        }

        public Uri ImageSource
        {
            get { return imageSource; }
            set { imageSource = value; }
        }
    }
}
