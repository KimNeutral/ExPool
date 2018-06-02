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
            _home.MenuToggleButton.Visibility = stack.Count == 1 ? System.Windows.Visibility.Visible : System.Windows.Visibility.Collapsed;
            _home.tbtnBack.Visibility = stack.Count != 1 ? System.Windows.Visibility.Visible : System.Windows.Visibility.Collapsed;
        }

        public void ShowCard()
        {
            if (stack.Count == 1)
            {
                ((HomePage)stack.Peek()).Card.Visibility = System.Windows.Visibility.Visible;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged(string propertyName) => PropertyChanged?.Invoke(null, new PropertyChangedEventArgs(propertyName));
    }
}
