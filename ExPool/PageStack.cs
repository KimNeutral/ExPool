using ExPool.Pages;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ExPool
{
    public class PageStack : INotifyPropertyChanged
    {
        private Stack<Page> stack = new Stack<Page>();
        private Home _home;

        private Page currentPage;
        public Page CurrentPage
        {
            get
            {
                return currentPage;
            }
            set
            {
                currentPage = value;
                NotifyPropertyChanged(nameof(CurrentPage));
            }
        }

        public PageStack(Home home)
        {
            _home = home;
            Add(new HomePage());
        }

        public void Add(Page page)
        {
            stack.Push(page);
            SetCurrentPage();
        }

        public void Pop()
        {
            if (stack.Count == 1) return;
            stack.Pop();
            SetCurrentPage();
        }

        private void SetCurrentPage()
        {
            CurrentPage = stack.Peek();
            _home.Frame.Content = CurrentPage;
            _home.tbtnHamburger.IsChecked = stack.Count != 1;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged(string propertyName) => PropertyChanged?.Invoke(null, new PropertyChangedEventArgs(propertyName));
    }
}
