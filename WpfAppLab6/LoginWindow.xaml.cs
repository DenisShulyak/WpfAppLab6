using System.Linq;
using System.Windows;
using WpfAppLab6.Services;

namespace WpfAppLab6
{
    public partial class LoginWindow : Window
    {
        private readonly JwtTokenManager _tokenManager;

        public LoginWindow()
        {
            InitializeComponent();
            _tokenManager = new JwtTokenManager("8Zz5tw0Ionm3XPZZfN0NOml3z9FMfmpgXwovR9fp6ryDIoGRM8EPHAB6iHsc0fb");
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Password;

            bool isAuthenticated = AuthenticateUser(username, password);

            if (isAuthenticated)
            {
                var mainWindow = new MainWindow();
                
                mainWindow.Show();
                Close();
            }
            else
            {
                MessageBox.Show("Неправильное имя пользователя или пароль.");
            }
        }

        private bool AuthenticateUser(string username, string password)
        {
            var dbContext = AppDbContextSingleton.Instance;

            var user = dbContext.Users.SingleOrDefault(u => u.Login == username && u.Password == password);
            if (user != null)
            {
                App.Token = _tokenManager.GenerateToken(user);
                return true;
            }
            return false;
        }
    }
}