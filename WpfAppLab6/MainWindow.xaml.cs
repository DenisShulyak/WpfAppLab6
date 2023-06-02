using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using WpfAppLab6.Services;
using WpfAppLab6.Views;

namespace WpfAppLab6
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly JwtTokenManager _tokenManager;

        public MainWindow()
        {
            InitializeComponent();
            _tokenManager = new JwtTokenManager("8Zz5tw0Ionm3XPZZfN0NOml3z9FMfmpgXwovR9fp6ryDIoGRM8EPHAB6iHsc0fb");
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            Loaded += MainWindow_Loaded;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            var token = App.Token;
            if (!_tokenManager.ValidateToken(App.Token))
            {
                LoginWindow loginWindow = new LoginWindow();
                loginWindow.Show();
                Close();
                return;
            }

            var user = _tokenManager.GetUserFromToken(token);

            if (user.Role.Name == "Оператор ОМСУ")
            {
                AddClaimsRegistryTab();
                AddCaptureActsRegistryTab();
                //акты отлова
                //организации по OrganiztionTypes
                //контракты
            }
            else if (user.Role.Name == "Другая роль")
            {
                //AddOtherRegistryTab();
            }
        }

        private void AddClaimsRegistryTab()
        {
            // Создание представления для реестра Claims
            ClaimsRegistryViewModel claimsRegistryView = new ClaimsRegistryViewModel();

            // Создание вкладки
            TabItem tabItem = new TabItem();
            tabItem.Header = "Claims Registry";
            tabItem.Content = claimsRegistryView;

            // Добавление вкладки в TabControl
            RegistryTabControl.Items.Add(tabItem);
        }
        
        private void AddCaptureActsRegistryTab()
        {
            // Создание представления для реестра Claims
            CaptureActsViewModel captureActsViewModel = new CaptureActsViewModel();

            // Создание вкладки
            TabItem tabItem = new TabItem();
            tabItem.Header = "Capture Acts Registry";
            tabItem.Content = captureActsViewModel;

            // Добавление вкладки в TabControl
            RegistryTabControl.Items.Add(tabItem);
        }

    }
}