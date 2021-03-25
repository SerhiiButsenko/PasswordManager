using System;
using System.Collections.Generic;
using System.Text;

namespace PasswordManager
{
   public class UserElement
    {
        private string title;
        private string comment;
        private string imageSource;

        public UserElement(string title, string comment, string imageSource)
        {
            this.title = title;
            this.comment = comment;
            this.imageSource = imageSource;
           
        }

        public UserElement(string title)
        {
            this.title = title;
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

        public string ImageSource
        {
            get { return imageSource; }
            set { imageSource = value; }
        }
    }
}
