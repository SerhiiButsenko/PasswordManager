using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;


namespace PasswordManager
{
   public class LoginsListPage
    {
       private int pageNumber;
       private UserLogin[] elements;

        public LoginsListPage(UserLogin[] elements, int pageNumber)
        {
            this.elements = elements;
            this.pageNumber = pageNumber;
        }


       public int numberOfElements()
        {
            return elements.Length;
        }
    }
}
