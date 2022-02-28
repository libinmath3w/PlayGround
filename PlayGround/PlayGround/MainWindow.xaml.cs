using FontAwesome.WPF;
using MaterialDesignThemes.Wpf;
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
        public MainWindow()
        {
            InitializeComponent();
            Icon = ImageAwesome.CreateImageSource(FontAwesomeIcon.SoccerBallOutline, Brushes.Green);
            DataContext = new MainViewModel();
        }
        private void TongleTheme (object sender, RoutedEventArgs e)
        {
            ITheme theme = paletteHelper.GetTheme();
            if (IsDarknLightMode = theme.GetBaseTheme() == BaseTheme.Dark)
            {
                IsDarknLightMode = false;
                theme.SetBaseTheme(Theme.Light);
            }
            else
            {
                IsDarknLightMode = true;
                theme.SetBaseTheme(Theme.Dark);
            }
            paletteHelper.SetTheme(theme);
        }
    }
}
