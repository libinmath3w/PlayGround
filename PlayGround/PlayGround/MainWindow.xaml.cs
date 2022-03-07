using EntityLayer;
using FontAwesome.WPF;
using MaterialDesignThemes.Wpf;
using PlayGround.View;
using PlayGround.ViewModel;
using System;
using System.Collections.Generic;
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

namespace PlayGround
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public bool IsDarknLightMode { get; set; }
        private readonly PaletteHelper paletteHelper = new PaletteHelper();
        public MainWindow(UsersModel usersModel)
        {
            InitializeComponent();
            UserLoginView userLoginView = new UserLoginView();
            userLoginView.Close();
           Icon = ImageAwesome.CreateImageSource(FontAwesomeIcon.SoccerBallOutline, Brushes.Green);
            DataContext = new MainViewModel(usersModel);
        }
        private void TongleTheme (object sender, RoutedEventArgs e)
        {
            ITheme theme = paletteHelper.GetTheme();
            if (IsDarknLightMode = theme.GetBaseTheme() == BaseTheme.Dark)
            {
                IsDarknLightMode = false;
                theme.SetBaseTheme(Theme.Light);
                //darkmodes.Content = "Dark Mode";
            }
            else
            {
                IsDarknLightMode = true;
                theme.SetBaseTheme(Theme.Dark);
                //darkmodes.Content = "Light Mode";
            }
            paletteHelper.SetTheme(theme);
        }
        private void ButtonOpenMenu_Click(object sender, RoutedEventArgs e)
        {
            ButtonCloseMenu.Visibility = Visibility.Visible;
            ButtonOpenMenu.Visibility = Visibility.Collapsed;
        }

        private void ButtonCloseMenu_Click(object sender, RoutedEventArgs e)
        {
            ButtonCloseMenu.Visibility = Visibility.Collapsed;
            ButtonOpenMenu.Visibility = Visibility.Visible;
        }
    }
}
