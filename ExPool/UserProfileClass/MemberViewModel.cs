using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using UserProfile.Model;
using ExPool;
using UserProfile.Exercise;

namespace UserProfile.ViewModel
{
    public class UserViewModel : INotifyPropertyChanged
    {
        // http://10rem.net/blog/2012/01/20/wpf-45-cross-thread-collection-synchronization-redux
        // 크로스 스레드에서 데이터를 넣을때 발생하는 에러 방지를 위한 락
        private readonly object _lock = new object();

        public event PropertyChangedEventHandler PropertyChanged;

        public List<User> Items { get; } = new List<User>();

        /*       private List<Department> _departments = null;
               public List<Department> Departments
               {
                   get => _departments;
               }*/

        private bool IsDataLoaded { get; set; }

        public UserViewModel()
        {
            // You must lock the collection when modifying it from another thread.
            BindingOperations.EnableCollectionSynchronization(Items, _lock);
        }
        /*        
                public void SetDeaprtments(List<Department> departments)
                {
                    _departments = departments;
                }*/

        /*        public void LoadDummyData()
                {
                    Items.Add(new User
                    {
                        DepartmentIdx = 1,
                        Email = "01rlaeodyd@naver.com",
                        Name = "김대용",
                        Id = "01rlaeodyd",
                        Tel = "01087577548"
                    });
                    Items.Add(new User
                    {
                        DepartmentIdx = 1,
                        Email = "01rlaeodyd@naver.com",
                        Name = "김대용",
                        Id = "01rlaeodyd",
                        Tel = "01087577548"
                    });
                    Items.Add(new User
                    {
                        DepartmentIdx = 1,
                        Email = "01rlaeodyd@naver.com",
                        Name = "김대용",
                        Id = "01rlaeodyd",
                        Tel = "01087577548"
                    });
                    Items.Add(new User
                    {
                        DepartmentIdx = 1,
                        Email = "01rlaeodyd@naver.com",
                        Name = "김대용",
                        Id = "01rlaeodyd",
                        Tel = "01087577548"
                    });
                }*/

        public User CopyUser(User user)
        {
            User UserData = new User
            {
                Email = user.Email,
                DepartmentIdx = user.DepartmentIdx,
                Id = user.Id,
                Name = user.Name,
                Mobile = user.Mobile,
                Location = user.Location,
                ProfileImage = user.ProfileImage,
                Tel = user.Tel,
                IsDriver = user.IsDriver,
                Age = user.Age
            };
            return UserData;
        }

        public void AddUsers(List<User> Users)
        {
            // TODO : 내부 디비 연동
            foreach (var user in Users)
            {
                AddUser(user);
            }
            User driver = GetDriver(Items);
            DeleteUser(driver);
            InsertUser(0, driver);
        }

        public void AddUser(User user)
        {
            // TODO : 내부 디비 연동
            if (user.Id == App.myprofile.Id)
            {
                user = App.myprofile;
                return;
            }
            lock (_lock)
            {
                // Once locked, you can manipulate the collection safely from another thread
                Items.Add(CopyUser(user));
            }
        }

        public User GetDriver(List<User> list)
        {
            return list.ToList().Single(x => x.IsDriver);
        }



        public User GetUser(int idx)
        {
            return Items[idx];
        }
        /*
                public User GetUserById(string id)
                {
                    return Items.Single(x => x.Id == id);
                }*/

        public void InsertUser(int idx, User user)
        {
            Items.Insert(idx, user);
        }

        public void DeleteUser(int idx)
        {
            Items.RemoveAt(idx);
        }

        public void DeleteUser(User user)
        {
            Items.Remove(user);
        }

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
