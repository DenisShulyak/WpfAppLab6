using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Controls;
using Microsoft.EntityFrameworkCore;
using WpfApplab6.Objects;
using WpfAppLab6.Services;

namespace WpfAppLab6.Views
{
    public partial class ClaimsRegistryViewModel : UserControl, INotifyPropertyChanged
    {
        private ObservableCollection<Claim> _claims;
        private Claim _selectedClaim;

        public ObservableCollection<Claim> Claims
        {
            get => _claims;
            set
            {
                _claims = value;
                OnPropertyChanged();
            }
        }

        public Claim SelectedClaim
        {
            get => _selectedClaim;
            set
            {
                _selectedClaim = value;
                OnPropertyChanged();
            }
        }

        public ClaimsRegistryViewModel()
        {
            InitializeComponent();
            LoadClaims();
        }

        private void LoadClaims()
        {
            var dbContext = AppDbContextSingleton.Instance;
            Claims = new ObservableCollection<Claim>(dbContext.Claims.Include(c => c.City));
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}