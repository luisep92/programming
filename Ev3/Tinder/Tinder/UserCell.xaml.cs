using System.Net;
using System.Windows;
using System.Windows.Controls;

namespace Tinder
{
    //Logic of the cell that stores our users
    public partial class UserCell : UserControl
    {
        #region VARIABLES
        //I needed to do this in order to store the id of the user into the cell, in XAML
        public static readonly DependencyProperty IdProperty = DependencyProperty.Register("Id", typeof(int), typeof(UserCell), new PropertyMetadata(default(int)));

        public int Id
        {
            get { return (int)GetValue(IdProperty); }
            set { SetValue(IdProperty, value); }
        }
        #endregion

        #region CONSTRUCTOR
        public UserCell()
        {
            InitializeComponent();
        }
        #endregion

        #region FUNCTIONS
        //OnClick method for our cells. It calls the Appmanager to update selected user
        private void OnClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            AppManager.Instance.UpdateSelectedUser(Id);
        }

        //Calls the AppManager to delete an user. This method is called from a button
        private void DeleteUser(object sender, RoutedEventArgs e)
        {
            AppManager.Instance.RemoveUser(Id);
        }
        #endregion
    }
}
