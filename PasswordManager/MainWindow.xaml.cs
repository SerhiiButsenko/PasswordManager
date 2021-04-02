using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace PasswordManager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<UserLogin> Logins { get; set; }
        public List<MenuItem> SideBarImages { get; set; }
        public List<MenuItem> OpenedBarImages { get; set; }

        LoginsList ListOfLogins;

        private Ellipse HoveredBackground, HoveredIcon;

        TextBoxEditor titleElement, websiteElement, loginElement, passwordElement;


        private void InitializeEllipses()
        {
            HoveredBackground = new Ellipse(); HoveredIcon = new Ellipse();
            HoveredBackground.Width = HoveredIcon.Width = HoveredBackground.Height = HoveredIcon.Height = 75;
            HoveredBackground.Stroke = HoveredIcon.Stroke = new SolidColorBrush(Color.FromRgb(0, 0, 0));
            HoveredBackground.StrokeThickness = HoveredIcon.StrokeThickness = 2;
            HoveredBackground.Cursor = HoveredIcon.Cursor = Cursors.Hand;

            HoveredBackground.Fill = new SolidColorBrush(Color.FromArgb(50, 255, 255, 255));
            HoveredIcon.Fill = new ImageBrush(new BitmapImage(new Uri("/Images/InterfaceIcons/OpenMenuIcon.png", UriKind.Relative)));
        }

       
        public MainWindow()
        {
            InitializeComponent();
            InitializeEllipses();
            
            Logins = new List<UserLogin>
            {
                new UserLogin("Facebook", "www.facebook.com", "butsenko2001@gmail.com", "08122001Butsilion", 
                "This is my Facebook password", "/Images/LoginIcons/0.png", 0, 0 ),
                 new UserLogin("SoundCloud", "www.facebook.com", "butsenko2001@gmail.com", "08122001Butsilion",
                "This is my Facebook password", "/Images/LoginIcons/1.png", 0, 1 ),
                  new UserLogin("YouTube", "www.facebook.com", "butsenko2001@gmail.com", "08122001Butsilion",
                "This is my Facebook password", "/Images/LoginIcons/2.png", 0, 2 ),
                   new UserLogin("Twitter", "www.facebook.com", "butsenko2001@gmail.com", "08122001Butsilion",
                "This is my Facebook password", "/Images/LoginIcons/3.png", 0, 3 ),
                    new UserLogin("Instagram", "www.facebook.com", "butsenko2001@gmail.com", "08122001Butsilion",
                "This is my Facebook password", "/Images/LoginIcons/4.png", 1, 0 ),
                     new UserLogin("Spotify", "www.facebook.com", "butsenko2001@gmail.com", "08122001Butsilion",
                "This is my Facebook password", "/Images/LoginIcons/spotify.png", 1, 1 ),
                      new UserLogin("LinkedIn", "www.facebook.com", "butsenko2001@gmail.com", "08122001Butsilion",
                "This is my Facebook password", "/Images/LoginIcons/6.png", 1, 2 ),
                       new UserLogin("TikTok", "www.facebook.com", "butsenko2001@gmail.com", "08122001Butsilion",
                "This is my Facebook password", "/Images/LoginIcons/7.png", 1, 3 ),

                          new UserLogin("TikTok", "www.facebook.com", "butsenko2001@gmail.com", "08122001Butsilion",
                "This is my Facebook password", "/Images/LoginIcons/7.png", 0, 0 ),
                            new UserLogin("LinkedIn", "www.facebook.com", "butsenko2001@gmail.com", "08122001Butsilion",
                "This is my Facebook password", "/Images/LoginIcons/6.png", 0, 1),
                            new UserLogin("Spotify", "www.facebook.com", "butsenko2001@gmail.com", "08122001Butsilion",
                "This is my Facebook password", "/Images/LoginIcons/spotify.png", 0, 2 ),
                             new UserLogin("YouTube", "www.facebook.com", "butsenko2001@gmail.com", "08122001Butsilion",
                "This is my Facebook password", "/Images/LoginIcons/2.png", 0, 3 ),
                        new UserLogin("Facebook", "www.facebook.com", "butsenko2001@gmail.com", "08122001Butsilion",
                "This is my Facebook password", "/Images/LoginIcons/0.png", 1, 0),
                 new UserLogin("SoundCloud", "www.facebook.com", "butsenko2001@gmail.com", "08122001Butsilion",
                "This is my Facebook password", "/Images/LoginIcons/1.png", 1, 1 ),
                   new UserLogin("Twitter", "www.facebook.com", "butsenko2001@gmail.com", "08122001Butsilion",
                "This is my Facebook password", "/Images/LoginIcons/3.png", 1, 2 ),
                    new UserLogin("Instagram", "www.facebook.com", "butsenko2001@gmail.com", "08122001Butsilion",
                "This is my Facebook password", "/Images/LoginIcons/4.png", 1, 3 ),
                     
                    
                     new UserLogin("Spotify", "www.facebook.com", "butsenko2001@gmail.com", "08122001Butsilion",
                "This is my Facebook password", "/Images/LoginIcons/spotify.png", 0, 0 ),
                      new UserLogin("LinkedIn", "www.facebook.com", "butsenko2001@gmail.com", "08122001Butsilion",
                "This is my Facebook password", "/Images/LoginIcons/6.png", 0, 1 ),
                       new UserLogin("TikTok", "www.facebook.com", "butsenko2001@gmail.com", "08122001Butsilion",
                "This is my Facebook password", "/Images/LoginIcons/7.png", 0, 2 ),
                         new UserLogin("YouTube", "www.facebook.com", "butsenko2001@gmail.com", "08122001Butsilion",
                "This is my Facebook password", "/Images/LoginIcons/2.png", 0, 3 ),
            };
            loginsList.ItemsSource = Logins;
            ListOfLogins = new LoginsList(loginsList, changePagePanel);

            SideBarImages = new List<MenuItem>
            {
                new MenuItem("", "/Images/InterfaceIcons/blueUser.png", "LoginSideBarBtn", 0, 0),
                new MenuItem("", "/Images/InterfaceIcons/bluePassword.png", "PasswordSideBarBtn", 1, 0),
                new MenuItem("", "/Images/InterfaceIcons/blueCreditCards.png", "CreditCardSideBarBtn", 2, 0),
                new MenuItem("", "/Images/InterfaceIcons/blueNote.png", "NoteSideBarBtn", 3, 0),
                new MenuItem("", "/Images/InterfaceIcons/blueIdentity.png", "IdentitySideBarBtn", 4, 0),
                new MenuItem("", "/Images/InterfaceIcons/blueSettings.png", "SettingsSideBarBtn", 6, 0),
                //new MenuItem("", "/Images/InterfaceIcons/blueUser.png", "TestIcon", 5, 0),
                new MenuItem("", "/Images/InterfaceIcons/simpleLogOut.png", "LogOutSideBarBtn", 7, 0),
                //new MenuItem("", "/Images/InterfaceIcons/blueMenu.png", "LogOutSideBarBtn", 8, 0),
            };
            Sidebar.ItemsSource = SideBarImages;

            OpenedBarImages = new List<MenuItem>
            {
                new MenuItem("Logins", "/Images/InterfaceIcons/blueUser.png", "LoginOpenedSideBarBtn", 0, 0),
                new MenuItem("Passwords", "/Images/InterfaceIcons/bluePassword.png", "PasswordOpenedSideBarBtn", 1, 0),
                new MenuItem("CreditCards", "/Images/InterfaceIcons/blueCreditCards.png", "CreditCardsOpenedSideBarBtn", 2, 0),
                new MenuItem("Notes", "/Images/InterfaceIcons/blueNote.png", "NotesOpenedSideBarBtn", 3, 0),
                new MenuItem("Form Wizard", "/Images/InterfaceIcons/blueIdentity.png", "IdentitiesOpenedSideBarBtn", 4, 0),
                new MenuItem("Settings", "/Images/InterfaceIcons/blueSettings.png", "SettingsOpenedSideBarBtn", 6, 0),
                new MenuItem("Log Out", "/Images/InterfaceIcons/simpleLogOut.png", "LogOutOpenedSideBarBtn", 7, 0),
            };
            OpenedSidebar.ItemsSource = OpenedBarImages;

            titleElement = new TextBoxEditor(titleStackPanel, true);
            websiteElement = new TextBoxEditor(websiteStackPanel, true);
            loginElement = new TextBoxEditor(loginStackPanel, true);
            passwordElement = new TextBoxEditor(passwordStackPanel, true);


            //--------------------------------------------------------Visible Controls---------------------------------------------------------------//
            OpenMenuButton.Visibility = Visibility.Visible;
            AddNewElementButton.Visibility = Visibility.Visible;
            closeElementInfoPanel.Visibility = Visibility.Visible;
            ElementImagePanel.Visibility = Visibility.Visible;
            Taskbar.Visibility = Visibility.Visible;
            changePagePanel.Visibility = Visibility.Visible;

            //--------------------------------------------------------Hidden Controls---------------------------------------------------------------//
          //  MenuOpenedCoverPanel.Visibility = Visibility.Hidden;
            loginsList.Visibility = Visibility.Visible;
            ElementInfoPanel.Visibility = Visibility.Hidden;
            HoveredBackground.Visibility = HoveredIcon.Visibility = Visibility.Visible;
            OpenedSidebar.Visibility = Visibility.Hidden;
            Sidebar.Visibility = Visibility.Hidden;
            openedMenuTaskbarIcon.Visibility = Visibility.Hidden;

            //--------------------------------------------------------Z-Indicees---------------------------------------------------------------//
            Panel.SetZIndex(loginsList, 0);
            Panel.SetZIndex(HoveredBackground, 1);
            Panel.SetZIndex(HoveredIcon, 2);
          //  Panel.SetZIndex(MenuOpenedCoverPanel, 3);
            Panel.SetZIndex(Sidebar, 3);
            Panel.SetZIndex(OpenedSidebar, 4);
            Panel.SetZIndex(openedMenuTaskbarIcon, 3);
        }

        private void HoveredBackground_Loaded(object sender, RoutedEventArgs e)
        {
            StackPanel stackPanel = sender as StackPanel;
            stackPanel.Visibility = Visibility.Hidden;
        }

        private void HoveredIcon_Loaded(object sender, RoutedEventArgs e)
        {
            StackPanel stackPanel = sender as StackPanel;
            stackPanel.Visibility = Visibility.Hidden;
        }

        private void HoveredBackgroundEllipse_MouseLeave(object sender, MouseEventArgs e)
        {
            Ellipse ellipse = sender as Ellipse;
            StackPanel stackPanel = ellipse.Parent as StackPanel;
            Canvas canvas = stackPanel.Parent as Canvas;
            UIElementCollection children = canvas.Children;
            int length = children.Count;
            children[length - 2].Visibility = Visibility.Hidden;
            children[length - 3].Visibility = Visibility.Hidden;
        }

        private void HoveredIconEllipse_MouseEnter(object sender, MouseEventArgs e)
        {
            Ellipse ellipse = sender as Ellipse;
            StackPanel stackPanel = ellipse.Parent as StackPanel;
            Canvas canvas = stackPanel.Parent as Canvas;
            UIElementCollection children = canvas.Children;
            int length = children.Count;
            children[length - 2].Visibility = Visibility.Visible;
            children[length - 3].Visibility = Visibility.Visible;
        }

        private void Polygon_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            ElementInfoPanel.Visibility = Visibility.Hidden;
            AddNewElementButton.Visibility = Visibility.Visible;
        }

        private void AddNewElementBtn_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            ElementInfoPanel.Visibility = Visibility.Visible;
            AddNewElementButton.Visibility = Visibility.Hidden;
        }

        private void SaveElementButton_Click(object sender, RoutedEventArgs e)
        {
            bool thereIsNoErrors = false;

            titleElement.checkIfHasNoErrors(); websiteElement.checkIfHasNoErrors(); loginElement.checkIfHasNoErrors(); passwordElement.checkIfHasNoErrors();
           

            if (thereIsNoErrors)
            {
                ElementInfoPanel.Visibility = Visibility.Hidden;
                AddNewElementButton.Visibility = Visibility.Visible;
            }
        }

        private void CancelElementButton_Click(object sender, RoutedEventArgs e)
        {
            ElementInfoPanel.Visibility = Visibility.Hidden;
            AddNewElementButton.Visibility = Visibility.Visible;
        }


        private void Button_MouseDown(object sender, MouseButtonEventArgs e)
        {
            (sender as Button).Background = new SolidColorBrush(Color.FromRgb(0, 0, 0));
        }

        private void LogOutBtn_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("Do you really want to exit?");
        }

        private void menuElement_MouseEnter(object sender, MouseEventArgs e)
        {
            StackPanel hoveredPanel = sender as StackPanel;        
            Image hoveredImage = hoveredPanel.Children[0] as Image;
            hoveredPanel.Background = new SolidColorBrush(Color.FromRgb(236, 236, 236));

            switch ((hoveredPanel.Children[1] as TextBlock).Text)
            {
                case "Logins":
                    hoveredImage.Source = new BitmapImage(new Uri("/Images/InterfaceIcons/blueFilledUser.png", UriKind.Relative));
                    break;
                case "Passwords":
                    hoveredImage.Source = new BitmapImage(new Uri("/Images/InterfaceIcons/blueFilledPassword.png", UriKind.Relative));
                    break;
                case "CreditCards":
                    hoveredImage.Source = new BitmapImage(new Uri("/Images/InterfaceIcons/newFilledCreditCard.png", UriKind.Relative));
                    break;
                case "Notes":
                    hoveredImage.Source = new BitmapImage(new Uri("/Images/InterfaceIcons/blueFilledNote.png", UriKind.Relative));
                    break;
                case "Form Wizard":
                    hoveredImage.Source = new BitmapImage(new Uri("/Images/InterfaceIcons/bluefilledIdentity.png", UriKind.Relative));
                    break;
                case "Settings":
                    hoveredImage.Source = new BitmapImage(new Uri("/Images/InterfaceIcons/blueFilledSettings.png", UriKind.Relative));
                    break;
                case "Log Out":
                    hoveredImage.Source = new BitmapImage(new Uri("/Images/InterfaceIcons/filledLogOut.png", UriKind.Relative));
                    break;
            }
        }

        private void menuElement_MouseLeave(object sender, MouseEventArgs e)
        {
            StackPanel hoveredPanel = sender as StackPanel;
            Image hoveredImage = hoveredPanel.Children[0] as Image;
            hoveredPanel.Background = new SolidColorBrush(Color.FromRgb(255, 255, 255));

            switch ((hoveredPanel.Children[1] as TextBlock).Text)
            {
                case "Logins":
                    hoveredImage.Source = new BitmapImage(new Uri("/Images/InterfaceIcons/blueUser.png", UriKind.Relative));
                    break;
                case "Passwords":
                    hoveredImage.Source = new BitmapImage(new Uri("/Images/InterfaceIcons/bluePassword.png", UriKind.Relative));
                    break;
                case "CreditCards":
                    hoveredImage.Source = new BitmapImage(new Uri("/Images/InterfaceIcons/blueCreditCards.png", UriKind.Relative));
                    break;
                case "Notes":
                    hoveredImage.Source = new BitmapImage(new Uri("/Images/InterfaceIcons/blueNote.png", UriKind.Relative));
                    break;
                case "Form Wizard":
                    hoveredImage.Source = new BitmapImage(new Uri("/Images/InterfaceIcons/blueIdentity.png", UriKind.Relative));
                    break;
                case "Settings":
                    hoveredImage.Source = new BitmapImage(new Uri("/Images/InterfaceIcons/blueSettings.png", UriKind.Relative));
                    break;
                case "Log Out":
                    hoveredImage.Source = new BitmapImage(new Uri("/Images/InterfaceIcons/simpleLogOut.png", UriKind.Relative));
                    break;
            }
        }

        private void Sidebar_MouseEnter(object sender, MouseEventArgs e)
        {
            OpenedSidebar.Visibility = Visibility.Visible;
        }

        private void openedMenuTaskbarIcon_MouseLeave(object sender, MouseEventArgs e)
        {
            openedMenuTaskbarIcon.Visibility = Visibility.Hidden;
            Sidebar.Visibility = Visibility.Hidden;
        }

        private void OpenedSidebar_MouseEnter(object sender, MouseEventArgs e)
        {
            openedMenuTaskbarIcon.Visibility = Visibility.Visible;
            Sidebar.Visibility = Visibility.Visible;
        }

        private void OpenedSidebar_MouseLeave(object sender, MouseEventArgs e)
        {
            openedMenuTaskbarIcon.Visibility = Visibility.Hidden;
            OpenedSidebar.Visibility = Visibility.Hidden;
        }

        private void openedMenuTaskbarIcon_MouseEnter(object sender, MouseEventArgs e)
        {
            Sidebar.Visibility = Visibility.Visible;
        }

        private void arrowRight_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            ListOfLogins.increasePage();
        }

        private void arrowLeft_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            ListOfLogins.decreasePage();
        }

        private void arrowLastPage_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            ListOfLogins.goToLastPage();
        }

        private void arrowFirstPage_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            ListOfLogins.goToFirstPage();
        }

        private void AddNewElementButton_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            ElementInfoPanel.Visibility = Visibility.Visible;
        }

        private void websiteTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            websiteElement.select();
        }

        private void websiteTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            websiteElement.unselect();
        }

        private void loginTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            loginElement.select();
        }

        private void loginTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            loginElement.unselect();
        }

        private void passwordTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            passwordElement.select();
        }

        private void passwordTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            passwordElement.unselect();
        }

        private void titleTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            titleElement.select();
        }

        private void titleTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            titleElement.unselect();
        }

        private void OpenMenuButton_MouseEnter(object sender, MouseEventArgs e)
        {
            openedMenuTaskbarIcon.Visibility = Visibility.Visible;
            Sidebar.Visibility = Visibility.Visible;
        }

        private void ElementImageEllipse_MouseEnter(object sender, MouseEventArgs e)
        {
            Ellipse ellipse = sender as Ellipse;
            StackPanel stackPanel = ellipse.Parent as StackPanel;
            Canvas canvas = stackPanel.Parent as Canvas;
            UIElementCollection children = canvas.Children;
            int length = children.Count;
            children[length - 2].Visibility = Visibility.Visible;
            children[length - 3].Visibility = Visibility.Visible;
        }
    }
}
