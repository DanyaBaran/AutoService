using AutoService.Shared.Models;

namespace AutoService
{
    public partial class FormAddRepair : Form
    {
        private readonly RepairApiClient _apiClient;

        public FormAddRepair(RepairApiClient apiClient)
        {
            InitializeComponent();
            _apiClient = apiClient;
            StartPosition = FormStartPosition.CenterScreen;
        }

        private async void SaveButton_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(employeeIdTextBox.Text, out int employeeId) ||
                !int.TryParse(carIdTextBox.Text, out int carId) ||
                !DateTime.TryParse(dateBeginTextBox.Text, out DateTime dateBegin))
            {
                MessageBox.Show("Будь ласка, перевірте коректність введених даних (EmployeesId, CarId, DateBegin).", "Некоректний ввід", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DateTime? dateEnd = null;
  
            if (!string.IsNullOrWhiteSpace(dateEndTextBox.Text))
            {
                if (DateTime.TryParse(dateEndTextBox.Text, out DateTime parsedDateEnd))
                {
                    dateEnd = parsedDateEnd;
                }
                else
                {
                    MessageBox.Show("Введено некоректний формат дати кінця.", "Помилка вводу", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            var contactOwner = contactOwnerTextBox.Text.Trim();

            try
            {
                var newRepair = new Repair
                {
                    EmployeeId = employeeId,
                    CarId = carId,
                    ContactOwner = contactOwner,
                    DateBegin = dateBegin,
                    DateEnd = dateEnd
                };
                await _apiClient.AddAsync(newRepair);
                MessageBox.Show("Запис успішно створено!", "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка створення запису: {ex.Message}", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
