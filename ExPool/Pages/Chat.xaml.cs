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
using System.Windows.Shapes;

namespace ExPool.Pages
{
    /// <summary>
    /// Chat.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class Chat : Window
    {
        public Chat()
        {
            InitializeComponent();
            ChatRecord.Items.Add(newChat.Text);
            newChat.Text = null;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ChatRecord.Items.Add(newChat.Text);
            newChat.Text = null;
        }

        private void newChat_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key==Key.Return)
            {
                ChatRecord.Items.Add(newChat.Text);
                newChat.Text = null;
            }
        }
    }
}
