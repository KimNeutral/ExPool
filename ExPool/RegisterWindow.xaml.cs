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
using ExPool.Network;
using RestSharp;
using UserProfile.Model;

namespace ExPool
{
    /// <summary>
    /// Interaction logic for RegisterWindow.xaml
    /// </summary>
    public partial class RegisterWindow : Window
    {
        public RegisterWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            /*var client = new RestClient("http://192.168.43.47:8080");
            var request = new RestRequest("auth", Method.GET);
            IRestResponse response = client.Execute(request);
            var content = response.Content;
            MessageBox.Show(content);*/
            /*User{String id;
            String pw;
            String name;
            String region;
            String email;
            String phone;}
             */
            try
            {
                User a = new User
                {
                    Id = signUpId.Text,
                    password = signUpPass.Password,
                    Name = signUpName.Text,
                    Location = null,
                    Email = signUpEmail.Text,
                    Mobile = signUpPhone.Text
                };

                string Json = a.Id + "," + a.password + "," + a.Name
                    + "," + a.Location + "," + a.Email + "," +
                    a.Mobile;
                
                NetworkManager.CreateClient();
                NetworkManager.CreateRequest("Post /auth/signup",
                    Method.POST, Json, null, null);
            }
            catch (Exception asd)
            {
                MessageBox.Show(asd.ToString());
            }
            
            //RestRequest c = b. CreateRequest(restRequset = ‘url’, ”POST”,User UserProfile,”login”);

            this.Close();
        }
    }
}
