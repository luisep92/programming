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
    //Window where you can add an user
    public partial class AddUserWindow : Window
    {
        #region CONSTRUCTOR
        public AddUserWindow()
        {
            InitializeComponent();
        }
        #endregion

        #region FUNCTIONS
        //Calls appmanager to add user using the fields of the window. If the fields are incorrect, opens an error message box
        private void ButtonAddUser_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                AppManager.Instance.AddUser(TextBoxName.Text, 
                                            Int32.Parse(TextBoxAge.Text), 
                                            TextBoxDescription.Text, 
                                            TextBoxImage.Text, 
                                            TextBoxGender.Text, 
                                            Convert.ToSingle(AppManager.AdaptStringToFloat(TextBoxValoration.Text)));
                
                AppManager.Instance.FilterUsers("");
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
