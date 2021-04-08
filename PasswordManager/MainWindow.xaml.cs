using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
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

        TextBoxEditor titleEditor, websiteEditor, loginEditor;

        PasswordBoxEditor passwordEditor;

        bool richTextBoxSelected, filledWithImage;

        Uri currentElementInfoImage;


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

            ListOfLogins = new LoginsList(loginsList, changePagePanel);
            
            ListOfLogins.addNewLogin(new UserLogin("Facebook", "www.facebook.com", "butsenko2001@gmail.com", "08122001Butsilion",
                "This is my Facebook password", new Uri("/Images/LoginIcons/0.png", UriKind.Relative)));

            ListOfLogins.addNewLogin(new UserLogin("SoundCloud", "www.facebook.com", "butsenko2001@gmail.com", "08122001Butsilion",
            "This is my Facebook password", new Uri("/Images/LoginIcons/1.png", UriKind.Relative)));

            ListOfLogins.addNewLogin(new UserLogin("YouTube", "www.facebook.com", "butsenko2001@gmail.com", "08122001Butsilion",
                "This is my Facebook password", new Uri("/Images/LoginIcons/2.png", UriKind.Relative)));

            ListOfLogins.addNewLogin(new UserLogin("Twitter", "www.facebook.com", "butsenko2001@gmail.com", "08122001Butsilion",
                "This is my Facebook password", new Uri("/Images/LoginIcons/3.png", UriKind.Relative)));

            ListOfLogins.addNewLogin(new UserLogin("Instagram", "www.facebook.com", "butsenko2001@gmail.com", "08122001Butsilion",
                "This is my Facebook password", new Uri("/Images/LoginIcons/4.png", UriKind.Relative)));

            ListOfLogins.addNewLogin(new UserLogin("Spotify", "www.facebook.com", "butsenko2001@gmail.com", "08122001Butsilion",
                "This is my Facebook password", new Uri("/Images/LoginIcons/spotify.png", UriKind.Relative)));

            ListOfLogins.addNewLogin(new UserLogin("LinkedIn", "www.facebook.com", "butsenko2001@gmail.com", "08122001Butsilion",
                "This is my Facebook password", new Uri("/Images/LoginIcons/6.png", UriKind.Relative)));

            ListOfLogins.addNewLogin(new UserLogin("TikTok", "www.facebook.com", "butsenko2001@gmail.com", "08122001Butsilion",
                "This is my Facebook password", new Uri("/Images/LoginIcons/7.png", UriKind.Relative)));


            ListOfLogins.addNewLogin(new UserLogin("TikTok", "www.facebook.com", "butsenko2001@gmail.com", "08122001Butsilion",
                "This is my Facebook password", new Uri("/Images/LoginIcons/7.png", UriKind.Relative)));

            ListOfLogins.addNewLogin(new UserLogin("LinkedIn", "www.facebook.com", "butsenko2001@gmail.com", "08122001Butsilion",
                "This is my Facebook password", new Uri("/Images/LoginIcons/6.png", UriKind.Relative)));

            ListOfLogins.addNewLogin(new UserLogin("Spotify", "www.facebook.com", "butsenko2001@gmail.com", "08122001Butsilion",
                "This is my Facebook password", new Uri("/Images/LoginIcons/spotify.png", UriKind.Relative)));

            ListOfLogins.addNewLogin(new UserLogin("YouTube", "www.facebook.com", "butsenko2001@gmail.com", "08122001Butsilion",
                "This is my Facebook password", new Uri("/Images/LoginIcons/2.png", UriKind.Relative)));

            ListOfLogins.addNewLogin(new UserLogin("Facebook", "www.facebook.com", "butsenko2001@gmail.com", "08122001Butsilion",
                "This is my Facebook password",new Uri( "/Images/LoginIcons/0.png", UriKind.Relative)));

            ListOfLogins.addNewLogin(new UserLogin("SoundCloud", "www.facebook.com", "butsenko2001@gmail.com", "08122001Butsilion",
                "This is my Facebook password", new Uri("/Images/LoginIcons/1.png", UriKind.Relative)));

            ListOfLogins.addNewLogin(new UserLogin("Twitter", "www.facebook.com", "butsenko2001@gmail.com", "08122001Butsilion",
                "This is my Facebook password", new Uri("/Images/LoginIcons/3.png", UriKind.Relative)));

            ListOfLogins.addNewLogin(new UserLogin("Instagram", "www.facebook.com", "butsenko2001@gmail.com", "08122001Butsilion",
                "This is my Facebook password", new Uri("/Images/LoginIcons/4.png", UriKind.Relative)));


            ListOfLogins.addNewLogin(new UserLogin("Spotify", "www.facebook.com", "butsenko2001@gmail.com", "08122001Butsilion",
                "This is my Facebook password", new Uri("/Images/LoginIcons/spotify.png", UriKind.Relative)));  

           ListOfLogins.addNewLogin(new UserLogin("LinkedIn", "www.facebook.com", "butsenko2001@gmail.com", "08122001Butsilion",
                "This is my Facebook password", new Uri("/Images/LoginIcons/6.png", UriKind.Relative)));

            ListOfLogins.addNewLogin(new UserLogin("TikTok", "www.facebook.com", "butsenko2001@gmail.com", "08122001Butsilion",
                "This is my Facebook password", new Uri("/Images/LoginIcons/7.png", UriKind.Relative)));

            ListOfLogins.addNewLogin(new UserLogin("YouTube", "www.facebook.com", "butsenko2001@gmail.com", "08122001Butsilion",
                "This is my Facebook password", new Uri("/Images/LoginIcons/2.png", UriKind.Relative))); 

            ListOfLogins.goToFirstPage();


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

            titleEditor = new TextBoxEditor(titleStackPanel, true);
            titleEditor.BindedTextBox.Tag = titleEditor;

            websiteEditor = new TextBoxEditor(websiteStackPanel, true);
            websiteEditor.BindedTextBox.Tag = websiteEditor;

            loginEditor = new TextBoxEditor(loginStackPanel, true);
            loginEditor.BindedTextBox.Tag = loginEditor;
            passwordEditor = new PasswordBoxEditor(passwordStackPanel, true);
            passwordEditor.BindedPasswordBox.Tag = passwordEditor;

            richTextBoxSelected = false;
            filledWithImage = false;
            currentElementInfoImage = null;


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

        private UserLogin readUserLogin()
        {
            string title = (titleStackPanel.Children[1] as TextBox).Text;
            string website = (websiteStackPanel.Children[1] as TextBox).Text;
            string login = (loginStackPanel.Children[1] as TextBox).Text;
            string password = (passwordStackPanel.Children[1] as TextBox).Text;
            RichTextBox commentBox = (commentStackPanel.Children[1] as RichTextBox);
            string comment = new TextRange(commentBox.Document.ContentStart, commentBox.Document.ContentEnd).Text;
            return new UserLogin(title, website, login, password, comment, currentElementInfoImage);
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
           /* bool thereIsNoErrors = true;

            foreach(TextBoxEditor txtBox in formElements)
            {
                string error = txtBox.checkIfHasNoErrors();
                if(error != "")
                {
                    thereIsNoErrors = false;
                    txtBox.displayError(error);
                }
            }

            if (thereIsNoErrors)
            {
                ListOfLogins.addNewLogin(readUserLogin());
                ListOfLogins.goToLastPage();
                ElementInfoPanel.Visibility = Visibility.Hidden;
                AddNewElementButton.Visibility = Visibility.Visible;
            } */
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

        private void TextBox_MouseEnter(object sender, MouseEventArgs e)
        {
            (sender as Control).Background = new SolidColorBrush(Color.FromRgb(241, 241, 241));
        }

        private void TextBox_MouseLeave(object sender, MouseEventArgs e)
        {
            Control currentTextContainer = sender as Control;
            if((currentTextContainer.Tag as TextContainerEditor).State != TextContainerState.Selected)
                currentTextContainer.Background = new SolidColorBrush(Color.FromRgb(250, 250, 250)); 
        }

        private void RichTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            (sender as RichTextBox).BorderBrush = new SolidColorBrush(Color.FromRgb(0, 0, 0));
            (sender as RichTextBox).Background = new SolidColorBrush(Color.FromRgb(241, 241, 241));
            (commentStackPanel.Children[0] as TextBlock).Style = (Style) Resources["selectedTextBoxLabel"];
            richTextBoxSelected = true;
        }

        private void RichTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            (sender as RichTextBox).BorderBrush = new SolidColorBrush(Color.FromRgb(51, 108, 166));
            (sender as RichTextBox).Background = new SolidColorBrush(Color.FromRgb(250, 250, 250));
            (commentStackPanel.Children[0] as TextBlock).Style = (Style)Resources["textBoxLabel"];
            richTextBoxSelected = false;
        }

        private void RichTextBox_MouseEnter(object sender, MouseEventArgs e)
        {
            (sender as RichTextBox).Background = new SolidColorBrush(Color.FromRgb(241, 241, 241));
        }

        private void RichTextBox_MouseLeave(object sender, MouseEventArgs e)
        {
            if(!richTextBoxSelected)
                (sender as RichTextBox).Background = new SolidColorBrush(Color.FromRgb(250, 250, 250));
        }

        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            TextContainerEditor focusedElement = (sender as Control).Tag as TextContainerEditor;
            if (focusedElement == titleEditor)
                titleEditor.selectTextBox();
            else if (focusedElement == websiteEditor)
                websiteEditor.selectTextBox();
            else if (focusedElement == loginEditor)
                loginEditor.selectTextBox();           
        }

        private void TextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            TextContainerEditor focusedElement = (sender as Control).Tag as TextContainerEditor;
            if (focusedElement == titleEditor)
                titleEditor.unselectTextBox();
            else if (focusedElement == websiteEditor)
                websiteEditor.unselectTextBox();
            else if (focusedElement == loginEditor)
                loginEditor.unselectTextBox();
        }

        private void OpenMenuButton_MouseEnter(object sender, MouseEventArgs e)
        {
            openedMenuTaskbarIcon.Visibility = Visibility.Visible;
            Sidebar.Visibility = Visibility.Visible;
        }

        private void ImageEllipse_MouseEnter(object sender, MouseEventArgs e)
        {
            if(!filledWithImage)
            imageBackgroundEllipse.Fill = new SolidColorBrush(Color.FromRgb(241, 241, 241));
            //(ElementImagePanel.Children[1] as TextBlock).Style = (Style)Resources["selectedTextBoxLabel"];
        }

        private void Ellipse_MouseLeave(object sender, MouseEventArgs e)
        {
            if(!filledWithImage)
            imageBackgroundEllipse.Fill = new SolidColorBrush(Color.FromRgb(250, 250, 250));
            //(ElementImagePanel.Children[1] as TextBlock).Style = (Style)Resources["textBoxLabel"];
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
           // (formElements[3] as TE).changeText();
            
        }

        private void imageBackgroundEllipse_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            OpenFileDialog dialogWindow = new OpenFileDialog();
            dialogWindow.Title = "Choose an image";
            dialogWindow.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";
            if(dialogWindow.ShowDialog() == true)
            {
                currentElementInfoImage = new Uri(dialogWindow.FileName, UriKind.Absolute);
                BitmapImage img = new BitmapImage(currentElementInfoImage);
                imageIconEllipse.Fill = null;
                ImageBrush newImage = new ImageBrush(img); newImage.Stretch = Stretch.Fill; 
                imageBackgroundEllipse.Fill = newImage;
                filledWithImage = true;
            }
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
