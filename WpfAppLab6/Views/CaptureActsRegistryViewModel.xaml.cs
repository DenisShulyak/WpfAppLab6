using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Controls;
using Microsoft.EntityFrameworkCore;
using WpfApplab6.Objects;
using WpfAppLab6.Services;

namespace WpfAppLab6.Views
{
    public partial class CaptureActsRegistryViewModel : UserControl, INotifyPropertyChanged
    {
        private ObservableCollection<CaptureAct> _captureActs;
        private Claim _selectedCaptureAct;

        public ObservableCollection<CaptureAct> CaptureActs
        {
            get => _captureActs;
            set
            {
                _captureActs = value;
                OnPropertyChanged();
            }
        }

        public Claim SelectedCaptureAct
        {
            get => _selectedCaptureAct;
            set
            {
                _selectedCaptureAct = value;
                OnPropertyChanged();
            }
        }

        public CaptureActsRegistryViewModel()
        {
            InitializeComponent();
            LoadClaims();
        }

        private void LoadClaims()
        {
            var dbContext = AppDbContextSingleton.Instance;
            CaptureActs = new ObservableCollection<CaptureAct>(dbContext.CaptureActs.Include(c => c.Claim)
                .Include(x => x.Organization)
                .Include(x => x.Contract));
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}