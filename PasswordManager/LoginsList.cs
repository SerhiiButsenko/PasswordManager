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
        private ItemsControl list;
        private List<LoginsListPage> pages;
        private StackPanel navigationPanel;
        private Image leftArrow, rightArrow, firstPageArrow, lastPageArrow;
        private TextBlock text;
        private LoginsListPage currentPage;

        public LoginsList(ItemsControl list, StackPanel navigationPanel)
        {
            this.list = list;

            //List<UserLogin> allLogins = list.ItemsSource as List<UserLogin>;
            // for (int i = 0; i < allLogins.Count; i += 8)
            //   pages.Add(new LoginsListPage(allLogins.GetRange(i, Math.Min(8, allLogins.Count - i)).ToArray(), i / 8));

            pages = new List<LoginsListPage>();
            pages.Add(new LoginsListPage(0));
          
            this.navigationPanel = navigationPanel;
            this.currentPage = pages[0];
            this.firstPageArrow = (navigationPanel.Children[0] as Grid).Children[0] as Image;
            this.leftArrow = (navigationPanel.Children[0] as Grid).Children[1] as Image;
            this.text = (navigationPanel.Children[0] as Grid).Children[2] as TextBlock;
            this.rightArrow = (navigationPanel.Children[0] as Grid).Children[3] as Image;
            this.lastPageArrow = (navigationPanel.Children[0] as Grid).Children[4] as Image;
          //  LoadCurrentPage();
        }

       private void LoadCurrentPage()
        {
            if(pages.Count == 1)
            {
                leftArrow.Opacity = rightArrow.Opacity = firstPageArrow.Opacity = lastPageArrow.Opacity = 0.5;
                leftArrow.IsEnabled = rightArrow.IsEnabled = firstPageArrow.IsEnabled = lastPageArrow.IsEnabled = false;
                text.Visibility = Visibility.Visible;
                text.Text = "1";
            } else if(pages.Count > 1 && currentPage.PageNumber == 0)
            {
                firstPageArrow.Opacity = 0.5;
                firstPageArrow.IsEnabled = false;

                leftArrow.Opacity = 0.5;
                leftArrow.IsEnabled = false;

                rightArrow.Opacity = 1;
                rightArrow.IsEnabled = true;

                lastPageArrow.Opacity = 1;
                lastPageArrow.IsEnabled = true;

                text.Visibility = Visibility.Visible;
                text.Text = "1";
            } else if(pages.Count > 1 && currentPage.PageNumber == pages.Count - 1)
            {
                firstPageArrow.Opacity = 1;
                firstPageArrow.IsEnabled = true;

                leftArrow.Opacity = 1;
                leftArrow.IsEnabled = true;

                rightArrow.Opacity = 0.5;
                rightArrow.IsEnabled = false;

                lastPageArrow.Opacity = 0.5;
                lastPageArrow.IsEnabled = true;

                text.Visibility = Visibility.Visible;
                text.Text = pages.Count.ToString();
            } else if(pages.Count > 1 && currentPage.PageNumber < pages.Count - 1)
            {
                firstPageArrow.Opacity = 1;
                firstPageArrow.IsEnabled = true;

                leftArrow.Opacity = 1;
                leftArrow.IsEnabled = true;

                rightArrow.Opacity = 1;
                rightArrow.IsEnabled = true;

                lastPageArrow.Opacity = 1;
                lastPageArrow.IsEnabled = true;

                text.Visibility = Visibility.Visible;
                text.Text = (currentPage.PageNumber + 1).ToString();
            }
            list.ItemsSource = currentPage.Elements;
        }

        public void increasePage()
        {
            currentPage = pages[currentPage.PageNumber + 1];
            LoadCurrentPage();
        }

        public void decreasePage()
        {
            currentPage = pages[currentPage.PageNumber - 1]; 
            LoadCurrentPage();
        }

        public void goToLastPage()
        {
            currentPage = pages[pages.Count - 1];
            LoadCurrentPage();
        }

        public void goToFirstPage()
        {
            currentPage = pages[0];
            LoadCurrentPage();
        }

        public void goToPage(int pageNumber)
        {
            currentPage = pages[pageNumber - 1];
            LoadCurrentPage();
        }

        public void addNewLogin(UserLogin newLogin)
        {
            if (pages[pages.Count - 1].NumberOfElements == 8)
                pages.Add(new LoginsListPage(pages.Count));
           
            
            pages[pages.Count - 1].addNewElement(newLogin);
            currentPage = pages[pages.Count - 1];

            LoadCurrentPage();
        }

    }
}
