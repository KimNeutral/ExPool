﻿using ExPool.Pages;
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
    /// <summary>
    /// Home.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class Home : Window
    {
        public Home()
        {
            InitializeComponent();
            App.stack = new PageStack(this);
            this.DataContext = App.stack;
        }

        private void tbtnBack_Unchecked(object sender, RoutedEventArgs e)
        {
            tbtnBack.IsChecked = true;
            App.stack.Pop();
        }
    }
}
