using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace ExPool
{
    /// <summary>
    /// App.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class App : Application
    {
    }

    public class Profile
    {
        public String UserName { get; set; }
        public int Age { get; set; }
        public String Location { get; set; }
        public String Exercise { get; set; }
    }
}
