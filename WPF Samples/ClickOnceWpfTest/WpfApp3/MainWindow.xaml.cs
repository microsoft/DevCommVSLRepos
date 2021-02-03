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

namespace WpfApp3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Loaded += Grid_Loaded;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {

            Properties.Settings.Default.Upgrade();
            Properties.Settings.Default.TestSetting = "2";
           
            Properties.Settings.Default.Save();
            MessageBox.Show(Properties.Settings.Default.TestSetting); 
        }
        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            if (Properties.Settings.Default.updateSettings)
            {
                Properties.Settings.Default.Upgrade();
                Properties.Settings.Default.updateSettings = false;
                Properties.Settings.Default.Save();
            }
            MessageBox.Show(Properties.Settings.Default.TestSetting); 
        }
    }
}
