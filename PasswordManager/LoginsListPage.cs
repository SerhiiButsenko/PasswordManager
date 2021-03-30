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
        private int numberOfElements;

        public LoginsListPage(UserLogin[] elements, int pageNumber)
        {
            this.elements = elements;
            this.pageNumber = pageNumber;
            this.numberOfElements = 0;
        }

        public void addNewElement(UserLogin newLogin)
        {
            if(numberOfElements == 0)
            {
                newLogin.GridRow = 0;
                newLogin.GridColumn = 0;
            } else if(numberOfElements > 0 && numberOfElements < 4)
            {
                newLogin.GridRow = 0;
                newLogin.GridColumn = elements.Length;
            } else if(numberOfElements == 4)
            {
                newLogin.GridRow = 1;
                newLogin.GridColumn = 0;
            } else if (numberOfElements > 4 && numberOfElements < 8)
            {
                newLogin.GridRow = 1;
                newLogin.GridColumn = elements.Length - 4;
            } 
        }

        public int NumberOfElements
        {
            get { return numberOfElements; }
        }

        public int PageNumber
        {
            get { return pageNumber; }
        }

        public UserLogin[] Elements
        {
            get { return elements; }
        }
    }
}
