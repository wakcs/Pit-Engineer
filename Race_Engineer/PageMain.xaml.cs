using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Race_Engineer {
    /// <summary>
    /// Interaction logic for PageMain.xaml
    /// </summary>
    public partial class PageMain : Page {
        public PageMain() {
            InitializeComponent();
            MainWindow main = (MainWindow)App.Current.MainWindow;
            bool isDark = main.tgTheme.IsChecked ?? false;
            SetDarkImages(isDark);
        }

        private void ClickButton(object sender, MouseButtonEventArgs e) {
            NavigationService nav = NavigationService.GetNavigationService(this);
            FrameworkElement border = (FrameworkElement)sender;
            nav.Content = new PageQuestion(border.Tag.ToString(), 0);
        }

        public void SetDarkImages(bool isDark) {
            if (isDark) {
                imgBraking.Source = new BitmapImage(new Uri("pack://application:,,,/Race_Engineer;component/Resources/RE_Brake_D.png"));
                imgDownforce.Source = new BitmapImage(new Uri("pack://application:,,,/Race_Engineer;component/Resources/RE_Downforce_D.png"));
                imgSuspension.Source = new BitmapImage(new Uri("pack://application:,,,/Race_Engineer;component/Resources/RE_Suspension_D.png"));
                imgGearing.Source = new BitmapImage(new Uri("pack://application:,,,/Race_Engineer;component/Resources/RE_Gearing_D.png"));
            }
            else {
                imgBraking.Source = new BitmapImage(new Uri("pack://application:,,,/Race_Engineer;component/Resources/RE_Brake_L.png"));
                imgDownforce.Source = new BitmapImage(new Uri("pack://application:,,,/Race_Engineer;component/Resources/RE_Downforce_L.png"));
                imgSuspension.Source = new BitmapImage(new Uri("pack://application:,,,/Race_Engineer;component/Resources/RE_Suspension_L.png"));
                imgGearing.Source = new BitmapImage(new Uri("pack://application:,,,/Race_Engineer;component/Resources/RE_Gearing_L.png"));

            }
        }
    }
}
