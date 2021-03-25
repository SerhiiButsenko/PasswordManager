using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PasswordManager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<UserLogin> Logins { get; set; }
        public ObservableCollection<CustomMenuItem> MenuItemsCollection { get; set; }

        private Ellipse HoveredBackground, HoveredIcon;

        private void InitializeEllipses()
        {
            HoveredBackground = new Ellipse(); HoveredIcon = new Ellipse();
            HoveredBackground.Width = HoveredIcon.Width = HoveredBackground.Height = HoveredIcon.Height = 75;
            HoveredBackground.Stroke = HoveredIcon.Stroke = new SolidColorBrush(Color.FromRgb(0, 0, 0));
            HoveredBackground.StrokeThickness = HoveredIcon.StrokeThickness = 2;
            HoveredBackground.Cursor = HoveredIcon.Cursor = Cursors.Hand;

            HoveredBackground.Fill = new SolidColorBrush(Color.FromArgb(50, 255, 255, 255));
            HoveredIcon.Fill = new ImageBrush(new BitmapImage(new Uri("Images/InterfaceIcons/ShowUserElement.png", UriKind.Relative)));
        }

        public MainWindow()
        {
            InitializeComponent();
            InitializeEllipses();
            
            Logins = new ObservableCollection<UserLogin>
            {
                new UserLogin("Facebook", "www.facebook.com", "butsenko2001@gmail.com", "08122001Butsilion", 
                "This is my Facebook password", "/Images/LoginIcons/0.png" ),
                 new UserLogin("SoundCloud", "www.facebook.com", "butsenko2001@gmail.com", "08122001Butsilion",
                "This is my Facebook password", "/Images/LoginIcons/1.png" ),
                  new UserLogin("YouTube", "www.facebook.com", "butsenko2001@gmail.com", "08122001Butsilion",
                "This is my Facebook password", "/Images/LoginIcons/2.png" ),
                   new UserLogin("Twitter", "www.facebook.com", "butsenko2001@gmail.com", "08122001Butsilion",
                "This is my Facebook password", "/Images/LoginIcons/3.png" ),
                    new UserLogin("Instagram", "www.facebook.com", "butsenko2001@gmail.com", "08122001Butsilion",
                "This is my Facebook password", "/Images/LoginIcons/4.png" ),
                     new UserLogin("Spotify", "www.facebook.com", "butsenko2001@gmail.com", "08122001Butsilion",
                "This is my Facebook password", "/Images/LoginIcons/5.png" ),
                      new UserLogin("LinkedIn", "www.facebook.com", "butsenko2001@gmail.com", "08122001Butsilion",
                "This is my Facebook password", "/Images/LoginIcons/6.png" ),
                       new UserLogin("TikTok", "www.facebook.com", "butsenko2001@gmail.com", "08122001Butsilion",
                "This is my Facebook password", "/Images/LoginIcons/7.png" )
            };
            //loginsList.ItemsSource = Logins;

            MenuItemsCollection = new ObservableCollection<CustomMenuItem>
            {
                new CustomMenuItem("Logins", "/Images/InterfaceIcons/LoginIcon.png", "LoginsMenuButton"),
                new CustomMenuItem("Passwords", "/Images/InterfaceIcons/PasswordIcon.png", "PasswordsMenuButton"),
                new CustomMenuItem("Credit cards", "/Images/InterfaceIcons/CreditCardIcon.png", "CreditCardsMenuButton"),
                new CustomMenuItem("Safe notes", "/Images/InterfaceIcons/NotesIcon.png", "SafeNotesMenuButton"),
                new CustomMenuItem("Forms Wizard", "/Images/InterfaceIcons/FormsIcon.png", "FormsWizardMenuButton")
            };
            LeftMenu.ItemsSource = MenuItemsCollection;


            //--------------------------------------------------------Visible Controls---------------------------------------------------------------//
            OpenMenuButton.Visibility = Visibility.Visible;
            AddNewElementButton.Visibility = Visibility.Visible;
            LeftMenu.Visibility = Visibility.Visible;
            LogOutBtn.Visibility = Visibility.Visible;
            SettingsBtn.Visibility = Visibility.Visible;
            closeElementInfoPanel.Visibility = Visibility.Visible;
            ElementImagePanel.Visibility = Visibility.Visible;

            //--------------------------------------------------------Hidden Controls---------------------------------------------------------------//
            MenuOpenedCoverPanel.Visibility = Visibility.Hidden;
            loginsList.Visibility = Visibility.Hidden;
            ElementInfoPanel.Visibility = Visibility.Hidden;
            MenuStackPanel.Visibility = Visibility.Hidden;
            HoveredBackground.Visibility = HoveredIcon.Visibility = Visibility.Hidden;

            //--------------------------------------------------------Z-Indicees---------------------------------------------------------------//
            Panel.SetZIndex(MenuStackPanel, 1);
            Panel.SetZIndex(loginsList, 0);
            Panel.SetZIndex(HoveredBackground, 1);
            Panel.SetZIndex(HoveredIcon, 2);
            Panel.SetZIndex(MenuOpenedCoverPanel, 3);


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
            ElementInfoPanel.Visibility = Visibility.Hidden;
            AddNewElementButton.Visibility = Visibility.Visible;
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

        private void OpenMenuBtn_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            OpenMenuButton.Visibility = Visibility.Hidden;
            MenuStackPanel.Visibility = Visibility.Visible;
            MenuOpenedCoverPanel.Visibility = Visibility.Visible;
        }

        private void LogOutBtn_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("Do you really want to exit?");
        }

        private void MenuOpenedCoverPanel_MouseDown(object sender, MouseButtonEventArgs e)
        {
            OpenMenuButton.Visibility = Visibility.Visible;
            MenuStackPanel.Visibility = Visibility.Hidden;
            MenuOpenedCoverPanel.Visibility = Visibility.Hidden;
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
