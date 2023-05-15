using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Cryptography;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace Tinder
{
    //Makes the bridge between our data and the application
    internal class AppManager
    {
        #region SINGLETON
        private static AppManager _instance;

        public static AppManager Instance => _instance;

        static AppManager()
        {
            _instance = new AppManager();
            _instance.Init();
        }
        #endregion

        #region VARIABLES
        public User SelectedUser;
        public event EventHandler UserChange;
        public ObservableCollection<User> UserList;
        #endregion

        #region CONSTRUCTOR
        public AppManager()
        {
            UserList = new ObservableCollection<User>();
        }
        #endregion

        //Initialize list and selected user
        //It has to be async and wait a short while because it needs all the application to be initialized
        private async Task Init()
        {
            await Task.Delay(1000);
            DBManager.Filter("");
            SelectedUser = UserList[0];
            OnUserChange();
        }

        //Invokes the event that we set up for a change of the selected user
        public virtual void OnUserChange()
        {
            UserChange?.Invoke(this, EventArgs.Empty);
        }

        //Updates selected user
        public void UpdateSelectedUser(int id)
        {
            try
            {
                User u = GetUserById(id);
                SelectedUser = u;
            }
            catch
            {
                SelectedUser = null;
            }
            OnUserChange();
        }
        
        //Calls the DBManager to add an user
        public void AddUser(string name, int age, string description, string image, string gender, float valoration)
        {
            DBManager.AddUser(name, age, description, image, gender, valoration);
        }

        //Calls the DBManager to delete user, also removes the user from the user list
        public void RemoveUser(int id)
        {
            DBManager.DeleteUser(id);
            User usr = GetUserById(id);
            UserList.Remove(usr);
        }

        //Calls AppManager to filter users
        public void FilterUsers(string keyword)
        {
            DBManager.Filter(keyword);
        }

        public void EditUser(int id,string name, int age, string description, string image, string gender, float valoration)
        {
            DBManager.EditUser(id, name, age, description, image, gender, valoration);
        }

        //Returns user by its id
        public User GetUserById(int id)
        {
            return (from u in UserList
                    where u.Id == id
                    select u).First();
        }

        //Just didn't want to make an utils class just for this
        public static string AdaptStringToFloat(string s)
        {
            return s.Replace('.', ',');
        }
    }
}
