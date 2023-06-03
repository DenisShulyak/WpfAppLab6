using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Controls;
using Microsoft.EntityFrameworkCore;
using WpfApplab6.Objects;
using WpfAppLab6.Services;

namespace WpfAppLab6.Views
{
    public partial class ContractsRegistryViewModel : UserControl, INotifyPropertyChanged
    {
        private ObservableCollection<Contract> _contracts;
        private Contract _selectedContract;

        public ObservableCollection<Contract> Contracts
        {
            get => _contracts;
            set
            {
                _contracts = value;
                OnPropertyChanged();
            }
        }

        public Contract SelectedContract
        {
            get => _selectedContract;
            set
            {
                _selectedContract = value;
                OnPropertyChanged();
            }
        }

        public ContractsRegistryViewModel()
        {
            InitializeComponent();
            LoadClaims();
        }

        private void LoadClaims()
        {
            var dbContext = AppDbContextSingleton.Instance;
            Contracts = new ObservableCollection<Contract>(dbContext.Contracts.Include(c => c.Customer)
                .Include(c => c.Executor));
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}