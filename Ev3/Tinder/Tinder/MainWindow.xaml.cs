using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace Tinder
{
    //Class to manage the main window of the app
    public partial class MainWindow : Window
    {
        #region CONSTRUCTOR
        //Initializes this component, the items source target and subscribess to UserChange event
        public MainWindow()
        {
            InitializeComponent();
            ListViewUsers.ItemsSource = AppManager.Instance.UserList;
            AppManager.Instance.UserChange += UpdateInfo;
        }
        #endregion

        #region FUNCTIONS
        //Update the fields that we visualize of the selected user
        public void UpdateInfo(object sender, EventArgs e)
        {
            User u = AppManager.Instance.SelectedUser;
            if (u == null)
                return;
            
            TextSelectedName.Text = u.Name;
            TextSelectedAgeAndGender.Text = u.Age + " años, " + u.Gender;
            TextSelectedDescription.Text = u.Description;
            ValorationGradient.EndPoint = u.ValorationEndPoint;
            try
            {
                SetImage(ImgSelectedUser, new Uri(AppManager.Instance.SelectedUser.Image));
            }
            catch //When uri is invalid, default image
            {

                SetImage(ImgSelectedUser, new Uri("https://static.vecteezy.com/system/resources/previews/000/440/531/original/question-mark-vector-icon.jpg"));
            }
        }

        //Updates the data source of an image, need to recieve an URI
        public void SetImage(Image img, Uri uri)
        {
                BitmapImage bi = new();
                bi.BeginInit();
                bi.UriSource = uri;
                bi.EndInit();
                img.Source = bi;
        }

        //This is called when the filter textbox content is changed
        private void TextChangedEventHandler(object sender, TextChangedEventArgs args)
        {
            UpdateUsers();
        }

        //Calls the AppManager to filter users. Delays 2 seconds in order to not overflow the program while the user is writing
        private async Task UpdateUsers()
        {
            string keyword = TextBoxFilterUsers.Text;
            await Task.Delay(2000);
            if (TextBoxFilterUsers.Text == keyword)
                AppManager.Instance.FilterUsers(keyword);
        }
        
        //Opens the add user window
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Window addWindow = new AddUserWindow();
            addWindow.Show();
        }
        #endregion

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Window w = new EditUserWindow(AppManager.Instance.SelectedUser.Id);
            w.Show();
        }
    }
}
