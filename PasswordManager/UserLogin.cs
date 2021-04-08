using System;
using System.Collections.Generic;
using System.Text;

namespace PasswordManager
{
    public class UserLogin : UserElement
    {
        private static int curId = 0;

        private string websiteUrl;
        private string login;
        private string password;
        private int loginID;
        

        public UserLogin(string title, string websiteUrl, string login, string password) : base(title)
        {
            this.websiteUrl = websiteUrl;
            this.login = login;
            this.password = password;
            loginID = curId++;
        }

        public UserLogin(string title, string websiteUrl, string login, string password, string comment, Uri imageSource) 
            : base(title, comment, imageSource)
        {
            this.websiteUrl = websiteUrl;
            this.login = login;
            this.password = password;
            loginID = curId++;
        }

        public UserLogin(string title, string websiteUrl, string login, string password, string comment, Uri imageSource, int gridRow, int gridColumn)
            : base(title, comment, imageSource, gridRow, gridColumn)
        {
            this.websiteUrl = websiteUrl;
            this.login = login;
            this.password = password;
            loginID = curId++;
        }

        public string WebsiteUrl
        {
            get { return websiteUrl; }
            set { websiteUrl = value; }
        }

        public string Login
        {
            get { return login; }
            set { login = value; }
        }

        public string Password
        {
            get { return password; }
            set { password = value; }
        }
    }
}
