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

namespace Tinder
{
    //A windows where we can edit an user
    public partial class EditUserWindow : Window
    {
        #region VARIABLES
        private User _user;
        #endregion

        #region CONSTRUCTOR
        public EditUserWindow(int id)
        {
            InitializeComponent();
            _user = AppManager.Instance.GetUserById(id);
            Init(_user);
        }
        #endregion

        #region FUNCTIONS
        //Sets up all the text boxes with the current info
        private void Init(User user)
        {
            TextBoxName.Text = user.Name;
            TextBoxAge.Text = user.Age.ToString();
            TextBoxGender.Text = user.Gender;
            TextBoxImage.Text = user.Image;
            TextBoxValoration.Text = user.Valoration.ToString();
            TextBoxDescription.Text = user.Description;
        }

        //Applies cthe changes we made to the user
        private void ButtonEditUser_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                AppManager am = AppManager.Instance;

                am.EditUser(_user.Id,
                            TextBoxName.Text,
                            Int32.Parse(TextBoxAge.Text),
                            TextBoxDescription.Text,
                            TextBoxImage.Text,
                            TextBoxGender.Text,
                            Convert.ToSingle(AppManager.AdaptStringToFloat(TextBoxValoration.Text)));

                am.FilterUsers("");
                am.UpdateSelectedUser(_user.Id);
                Close();
            }
            catch
            {
                MessageBox.Show("Ha ocurrido un error. Revisa los campos antes de insertarlos.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        #endregion
    }
}
