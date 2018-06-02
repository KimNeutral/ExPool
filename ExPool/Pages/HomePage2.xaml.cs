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

namespace ExPool.Pages
{
    /// <summary>
    /// Interaction logic for HomePage.xaml
    /// </summary>
    public partial class HomePage2 : Page
    {
        public HomePage2()
        {
            InitializeComponent();
        }

        private void btnDriver_Click(object sender, RoutedEventArgs e)
        {
            App.stack.Add(new AddDriverPage());
        }

        private void btnPassenger_Click(object sender, RoutedEventArgs e)
        {
            App.pageswitch = false;
            App.stack.Add(new HomePage());

        }

        private void Card_MouseUp(object sender, MouseButtonEventArgs e)
        {
            App.stack.Add(new LookUpPage());
        }
    }
}
