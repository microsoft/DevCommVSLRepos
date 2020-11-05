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

namespace MyOverrideMethod
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<string> MyCollection { get; set; }
        public string MyItem { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            MyItem = "test";
            MyCollection = new List<string>();
            MyCollection.Add(MyItem);
            MyItem = "test1";
            MyCollection.Add(MyItem);
            this.DataContext = this;



            mycombo.SelectionChanged -= mycombo_SelectionChanged;
            mycombo.SelectedIndex = 1;

        }

        private void mycombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            MessageBox.Show("SelectionChanged Event Triggered!");
        }

    }
}
