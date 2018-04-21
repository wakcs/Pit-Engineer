using MaterialDesignThemes.Wpf.Transitions;
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

namespace Race_Engineer {
    /// <summary>
    /// Interaction logic for MainUC.xaml
    /// </summary>
    public partial class MainUC : UserControl {
        public MainUC() {
            InitializeComponent();
            MainWindow main = (MainWindow)App.Current.MainWindow;
            bool isDark = main.tgTheme.IsChecked ?? false;
            SetDarkImages(isDark);
        }
        private void ClickButton(object sender, MouseButtonEventArgs e) {
            //NavigationService nav = NavigationService.GetNavigationService(this);
            //FrameworkElement border = (FrameworkElement)sender;
            //nav.Content = new PageQuestion(border.Tag.ToString(), 0);

            FrameworkElement obj = sender as FrameworkElement;
            MainWindow main = App.Current.MainWindow as MainWindow;
            Transitioner trans = main.tsMain;
            QuestionUC questionUC = trans.Items.GetItemAt(1) as QuestionUC;
            questionUC.GeneratePage(obj.Tag.ToString(), 0);
            trans.SelectedIndex = 1;
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
