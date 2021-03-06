﻿using System;
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
using Newtonsoft.Json.Linq;
using System.Net;
using System.IO;
using RestSharp;
using ExPool.Network;

namespace ExPool
{

    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            /*var client = new RestClient("http://192.168.43.47:8080");
            var request = new RestRequest("auth", Method.GET);
            IRestResponse response = client.Execute(request);
            var content = response.Content;
            MessageBox.Show(content);*/
              
            App.myprofile.Id = IdBox.Text.ToString();
            App.myprofile.password = PwBox.Password.ToString();
            String json_source = "{\"" + App.myprofile.Id + "\", \"" + App.myprofile.password + "\"}";

            NetworkManager.CreateClient();
            NetworkManager.CreateRequest("//auth//signin", Method.POST, json_source);


            var home = new Home();
            home.Show();
            this.Close();
        }

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            var registerWindow = new RegisterWindow();
            registerWindow.Owner = this;
            registerWindow.ShowDialog();
            this.Show();
        }
    }
}
