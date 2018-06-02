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
    /// Interaction logic for LookUpPage.xaml
    /// </summary>
    public partial class LookUpPage : Page
    {
        public LookUpPage()
        {
            InitializeComponent();
            App.pageswitch = true;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Clipboard.SetText("01012345678");
            MessageBox.Show("전화번호가 복사되었습니다.","System");
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var chat = new Chat();
            chat.Show();
        }
    }
}
