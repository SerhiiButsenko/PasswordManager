using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;


namespace PasswordManager
{
    public class LoginsListPage
    {
        private int pageNumber;
        private List<UserLogin> elements;
        private int numberOfElements;

        public LoginsListPage(int pageNumber)
        {
            this.pageNumber = pageNumber;
            this.elements = new List<UserLogin>();
            this.numberOfElements = 0;
        }

        public void addNewElement(UserLogin newLogin)
        {
            if(numberOfElements < 4)
            {
                newLogin.GridRow = 0;
                newLogin.GridColumn = numberOfElements;
            } else 
            {
                newLogin.GridRow = 1;
                newLogin.GridColumn = numberOfElements - 4;
            }
            elements.Add(newLogin);
            numberOfElements++;
        }

        public int NumberOfElements
        {
            get { return numberOfElements; }
        }

        public int PageNumber
        {
            get { return pageNumber; }
        }

        public List<UserLogin> Elements
        {
            get { return elements; }
        }
    }
}
