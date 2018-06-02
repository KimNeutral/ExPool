using ExPool.Pages;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace ExPool
{
    public class PageStack : INotifyPropertyChanged
    {
        private Stack<Page> stack = new Stack<Page>();

        public Page CurrentPage
        {
            get
            {
                if (stack.Count != 0)
                    return stack.Peek();
                else
                    return null;
            }
        }

        public PageStack()
        {
            Add(new HomePage());
        }

        public void Add(Page page)
        {
            stack.Push(page);
            NotifyPropertyChanged(nameof(CurrentPage));
        }

        public void Pop()
        {
            if (stack.Count == 1) return;
            stack.Pop();
            NotifyPropertyChanged(nameof(CurrentPage));
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged(string propertyName) => PropertyChanged?.Invoke(null, new PropertyChangedEventArgs(propertyName));
    }

    /// <summary>
    /// Home.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class Home : Window
    {
        public Home()
        {
            InitializeComponent();
            this.DataContext = new PageStack();
        }
    }
}
