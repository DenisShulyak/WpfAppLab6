using System.Collections.Generic;
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
                Title = user.Role.Name;
                AddClaimsRegistryTab();
                AddCaptureActsRegistryTab();
                AddContractsRegistryTab();
                AddOrganizationsRegistryTab(new List<string>
                {
                    "Приют",
                    "Организация по отлову",
                    "Организация по отлову и приют",
                    "Организация по транспортировке",
                    "Ветеринарная клиника: государственная",
                    "Ветеринарная клиника: частная",
                    "Благотворительный фонд",
                    "Организации по продаже товаров и предоставлению услуг для животных"
                });
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
            CaptureActsRegistryViewModel captureActsRegistryViewModel = new CaptureActsRegistryViewModel();

            // Создание вкладки
            TabItem tabItem = new TabItem();
            tabItem.Header = "Capture Acts Registry";
            tabItem.Content = captureActsRegistryViewModel;

            // Добавление вкладки в TabControl
            RegistryTabControl.Items.Add(tabItem);
        }
        
        private void AddContractsRegistryTab()
        {
            // Создание представления для реестра Claims
            ContractsRegistryViewModel contractsRegistryViewModel = new ContractsRegistryViewModel();

            // Создание вкладки
            TabItem tabItem = new TabItem();
            tabItem.Header = "Contracts Registry";
            tabItem.Content = contractsRegistryViewModel;

            // Добавление вкладки в TabControl
            RegistryTabControl.Items.Add(tabItem);
        }
        
        private void AddOrganizationsRegistryTab(List<string> organizationTypes = null)
        {
            OrganizationsRegistryViewModel organizationsRegistryView = new OrganizationsRegistryViewModel(organizationTypes);

            // Создание вкладки
            TabItem tabItem = new TabItem();
            tabItem.Header = "Organizations Registry";
            tabItem.Content = organizationsRegistryView;

            // Добавление вкладки в TabControl
            RegistryTabControl.Items.Add(tabItem);
        }

    }
}