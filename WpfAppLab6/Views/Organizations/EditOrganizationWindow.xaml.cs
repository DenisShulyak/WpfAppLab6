using System.Windows;
using WpfApplab6.Objects;

namespace WpfAppLab6.Views.Organizations
{
    public partial class EditOrganizationWindow : Window
    {
        private Organization _organization;

        public EditOrganizationWindow(Organization organization)
        {
            InitializeComponent();
            _organization = organization;

            // Заполнить поля окна данными организации
            FillFormFields();
        }

        private void FillFormFields()
        {
            // Заполнить поля окна данными организации
            // Например:
            nameTextBox.Text = _organization.Name;
            innTextBox.Text = _organization.Inn;
            kppTextBox.Text = _organization.Kpp;
            addressTextBox.Text = _organization.Address;
            // и так далее...
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            // Обработчик события нажатия кнопки "Сохранить"

            // Сохранить изменения в организации на основе данных из полей окна
            // Например:
            _organization.Name = nameTextBox.Text;
            _organization.Inn = innTextBox.Text;
            _organization.Kpp = kppTextBox.Text;
            _organization.Address = addressTextBox.Text;
            // и так далее...

            // Закрыть окно редактирования
            Close();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            // Обработчик события нажатия кнопки "Отмена"

            // Закрыть окно редактирования без сохранения изменений
            Close();
        }
    }
}