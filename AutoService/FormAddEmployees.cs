using AutoService.Shared.Models;

namespace AutoService
{
    public partial class FormAddEmployees : Form
    {
        private readonly EmployeeApiClient _apiClient;

        public FormAddEmployees(EmployeeApiClient apiClient)
        {
            InitializeComponent();
            _apiClient = apiClient;
            StartPosition = FormStartPosition.CenterScreen;
        }

        private async void SaveButton_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(salaryTextBox.Text, out int salary) ||
                !DateTime.TryParse(employmentDateTextBox.Text, out DateTime employmentDate))
            {
                MessageBox.Show("Будь ласка, перевірте коректність зарплати та дати.", "Некоректний ввід", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var newEmployee = new Employee
            {
                Name = nameTextBox.Text.Trim(),
                Address = addressTextBox.Text.Trim(),
                Phone = phoneTextBox.Text.Trim(),
                EmploymentDate = employmentDate,
                Salary = salary
            };

            if (string.IsNullOrEmpty(newEmployee.Name) || string.IsNullOrEmpty(newEmployee.Address) || string.IsNullOrEmpty(newEmployee.Phone))
            {
                MessageBox.Show("Будь ласка, заповніть всі текстові поля.", "Некоректний ввід", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                await _apiClient.AddAsync(newEmployee);
                MessageBox.Show("Працівника успішно додано!", "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка додавання працівника: {ex.Message}", "Помилка сервера", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
