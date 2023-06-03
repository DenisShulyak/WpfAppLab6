using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using Microsoft.EntityFrameworkCore;
using WpfApplab6.Objects;
using WpfAppLab6.Services;
using WpfAppLab6.Views.Organizations;

namespace WpfAppLab6.Views
{
    public partial class OrganizationsRegistryViewModel : UserControl, INotifyPropertyChanged
    {
        private ObservableCollection<Organization> _organizations;
        private Organization _selectedOrganization;

        public ObservableCollection<Organization> Organizations
        {
            get => _organizations;
            set
            {
                _organizations = value;
                OnPropertyChanged();
            }
        }

        public Organization SelectedOrganization
        {
            get => _selectedOrganization;
            set
            {
                _selectedOrganization = value;
                OnPropertyChanged();
            }
        }

        public OrganizationsRegistryViewModel(List<string> listNames = null)
        {
            InitializeComponent();
            LoadOrganizations();
        }

        private void LoadOrganizations(List<string> listNames = null)
        {
            var dbContext = AppDbContextSingleton.Instance;
            
            Organizations = new ObservableCollection<Organization>(dbContext.Organizations
                .Include(c => c.City)
                .Include(c => c.OrganizationType));
            if (listNames != null)
            {
                foreach (var name in listNames)
                {
                    Organizations = new ObservableCollection<Organization>(Organizations.Where(x => x.OrganizationType.Name == name));
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        
        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            // Обработчик события нажатия кнопки "Изменить"
            // Получить выбранную организацию
            Organization selectedOrganization = SelectedOrganization;

            // Провести необходимые действия при изменении организации
            // Например, открыть окно редактирования организации
            EditOrganizationWindow editWindow = new EditOrganizationWindow(selectedOrganization);
            editWindow.ShowDialog();

            // Обновить данные после изменения организации
            LoadOrganizations();
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            // Обработчик события нажатия кнопки "Удалить"
            // Получить выбранную организацию
            Organization selectedOrganization = SelectedOrganization;

            // Провести необходимые действия при удалении организации
            // Например, отобразить диалоговое окно подтверждения удаления
            MessageBoxResult result = MessageBox.Show("Вы уверены, что хотите удалить организацию?", "Подтверждение удаления", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                // Удалить организацию
                DeleteOrganization();
            }
        }
        
        private void DeleteOrganization()
        {
            if (SelectedOrganization != null)
            {
                var dbContext = AppDbContextSingleton.Instance;
                dbContext.Organizations.Remove(SelectedOrganization);
                dbContext.SaveChanges();
                Organizations.Remove(SelectedOrganization);
            }
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            // Обработчик события нажатия кнопки "Добавить"
            // Открыть окно для добавления новой организации
            //AddOrganizationWindow addWindow = new AddOrganizationWindow();
            //addWindow.ShowDialog();

            // Обновить данные после добавления организации
            LoadOrganizations();
        }
    }
}