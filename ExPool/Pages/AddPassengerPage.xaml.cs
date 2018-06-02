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
    /// Interaction logic for AddPassengerPage.xaml
    /// </summary>
    public partial class AddPassengerPage : Page
    {
        public AddPassengerPage()
        {
            InitializeComponent();
        }

        private void StartBact_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (StartBact.SelectedIndex == 0)
            {
                StartMact.Items.Clear();
                StartMact.Items.Add("종로구");
                StartMact.Items.Add("종구");
                StartMact.Items.Add("용산구");
                StartMact.Items.Add("성동구");
                StartMact.Items.Add("광진구");
                StartMact.Items.Add("동대문구");
                StartMact.Items.Add("중량구");
                StartMact.Items.Add("성복구");
                StartMact.Items.Add("강북구");
                StartMact.Items.Add("도봉구");
                StartMact.Items.Add("노원구");
                StartMact.Items.Add("은평구");
            }
            else if (StartBact.SelectedIndex == 8)
            {
                StartMact.Items.Clear();
                StartMact.Items.Add("수원시 장안구");
                StartMact.Items.Add("수원시 권선구");
                StartMact.Items.Add("수원시 팔달구");
                StartMact.Items.Add("수원시 영통구");
                StartMact.Items.Add("성남시 수정구");
                StartMact.Items.Add("성남시 중원구");
                StartMact.Items.Add("성남시 분당구");
                StartMact.Items.Add("안양시 만안구");
                StartMact.Items.Add("안양시 동안구");
                StartMact.Items.Add("안산시 단원구");
                StartMact.Items.Add("안산시 상록구");
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            App.stack.Pop();
        }
    }
}
