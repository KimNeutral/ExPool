using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using UserProfile.Model;

namespace ExPool
{
    /// <summary>
    /// App.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class App : Application
    {
        public static PageStack stack;

        public static User myprofile { get; set; } = new User();
        public static bool pageswitch { get; set; } = false;
    }
}
