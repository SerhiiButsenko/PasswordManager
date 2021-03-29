using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;


namespace PasswordManager
{
    public class LoginsList
    {
        public ItemsControl list;
        private List<LoginsListPage> pages;
        private int currentPage;
        private int lastPage;

        public LoginsList(ItemsControl list)
        {
            List<UserLogin> allLogins = list.ItemsSource as List<UserLogin>;
            pages = new List<LoginsListPage>();
            for (int i = 0; i < allLogins.Count; i += 8)
                pages.Add(new LoginsListPage(allLogins.GetRange(i, Math.Min(8, allLogins.Count - i)).ToArray(), i / 8));
        }



        void LoadCurrentPage()
        {
            
        }
    }
}
