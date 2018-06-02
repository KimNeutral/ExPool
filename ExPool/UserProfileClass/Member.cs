using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExPool;
using UserProfile.Exercise;

namespace UserProfile.Model
{

    public enum StateType
    {
        DISCONNECT,
        AWAY,
        CONNECT,
        REFUSE
    }
    public class User : INotifyPropertyChanged
    {
		private string id;
		private string pw;
        private string name;
        private int departmentIdx;
        private string department;
		private string profileImage;
        private int age;
        private string location;
        private string tel;
        private string mobile;
        private string email;
        private bool isDriver;
        private int auth;
        
        
		public string Id 
		{ 
			get{
					return id;
			}
			set
			{
					id = value;
			}
		}
		
		public string password
		{
			get
			{
					return pw;
			}
			set
			{
					pw = value;
			}
		}
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
                NotifyPropertyChanged("Name");
            }
        }
        public int DepartmentIdx
        {
            get
            {
                return departmentIdx;
            }
            set
            {
                if(value >0 && value <=4)
                    departmentIdx = value;
                //TO DO : 부서 구분

                // 1 : 축구
                // 2 : 농구
                // 3 : 탁구
                // 4 : 배드민턴

                //department = App.dicDepartment[departmentIdx];
                NotifyPropertyChanged("Department");
            }
        }
        public string Department
        {
            get
            {
                var item = Departments.FirstOrDefault(x => x.Idx == departmentIdx);
                return item?.Name;
            }
        }
        
        public string ProfileImage
        {
            get
            {
                return profileImage;
            }
            set
            {
                profileImage = value;
                NotifyPropertyChanged("ProfileImage");
                if (string.IsNullOrEmpty(profileImage))
                {
                    profileImage = "Image\\default-profile-image.jpg";
                }
            }
        }
		public int Age
		{
			get
			{
				return age;
			}
			set
			{
				age = value;
				NotifyPropertyChanged("Age");
			}
		}
        public string Location
        {
            get
            {
                return location;
            }
            set
            {
                location = value;
                NotifyPropertyChanged("Location");
            }
        }
        
        public string Tel
        {
            get
            {
                return tel;
            }
            set
            {
                tel = value;
                NotifyPropertyChanged("Tel");
            }
        }
        public string Mobile
        {
            get
            {
                return mobile;
            }
            set
            {
                mobile = value;
                NotifyPropertyChanged("Mobile");
            }
        }
        public string Email
        {
            get
            {
                return email;
            }
            set
            {
                email = value;
                NotifyPropertyChanged("Email");
            }
        }
        public bool IsDriver
        {
            get
            {
                return isDriver;
            }
            set
            {
                isDriver = value;
                NotifyPropertyChanged("IsDriver");
            }
        }
        public int Auth
        {
            get
            {
                return auth;
            }
            set
            {
                auth = value;
                NotifyPropertyChanged("Auth");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(String propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (null != handler)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
