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

namespace ExPool
{

    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        /*private string Request_Json()
        {
            string result = null;
            string url = "http://192.168.43.47:8080/auth";
            //Console.WriteLine("url : " + url);

            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream stream = response.GetResponseStream();
                StreamReader reader = new StreamReader(stream);
                result = reader.ReadToEnd();
                stream.Close();
                response.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

            return result;
        }*/
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var client = new RestClient("http://192.168.43.47:8080");
            var request = new RestRequest("auth", Method.GET);
            IRestResponse response = client.Execute(request);
            var content = response.Content;
            MessageBox.Show(content);
        }
    }
}
