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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
            bool enabled = Properties.Settings.Default.UseDarkTheme;
            tgTheme.IsChecked = enabled;
            new PaletteHelper().SetLightDark(enabled);
            fMain.Content = new PageMain();
        }

        private void ToggleButton_Click(object sender, RoutedEventArgs e) {
            ToggleButton btn = (ToggleButton)sender;
            bool enabled = btn.IsChecked ?? false;
            new PaletteHelper().SetLightDark(enabled);
            PageMain pageMain = fMain.Content as PageMain;
            if(pageMain != null) {
                pageMain.SetDarkImages(enabled);
            }
            Properties.Settings.Default.UseDarkTheme = enabled;
            Properties.Settings.Default.Save();
        }

        private void TitleBar_MouseDown(object sender, MouseButtonEventArgs e) {
            if(e.ChangedButton == MouseButton.Left) {
                this.DragMove();
            }
        }

        private void btnClose_Click(object sender, RoutedEventArgs e) {
            this.Close();
        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e) {
            WindowState = WindowState.Minimized;
        }
    }
}
