using AutoService.Shared.Models;
using AutoService.Infrastructure;

namespace AutoService
{
    public partial class FormEmployees : BaseForm
    {
        private readonly EmployeeApiClient _apiClient;

        public FormEmployees(CheckUser user, ServiceProvider serviceProvider) : base(user, serviceProvider)
        {
            InitializeComponent();
            _apiClient = _serviceProvider.EmployeeApiClient;
            StartPosition = FormStartPosition.CenterScreen;
        }

        private async void FormEmployees_Load(object sender, EventArgs e)
        {
            base.SetUserStatus(TlsUserStatus);
            base.SetupPermissions(UpdateButton, DeleteButton, ControlStripMenuItem, ToolStripMenuItem1);
            CreateColumns();
            await RefreshDataGridAsync();
        }

        private void CreateColumns()
        {
            EmployeeDataGridView.Columns.Clear();
            EmployeeDataGridView.Columns.Add(nameof(Employee.IdEmployee), "ID");
            EmployeeDataGridView.Columns.Add(nameof(Employee.Name), "Ім'я");
            EmployeeDataGridView.Columns.Add(nameof(Employee.Address), "Адреса");
            EmployeeDataGridView.Columns.Add(nameof(Employee.Phone), "Телефон");
            EmployeeDataGridView.Columns.Add(nameof(Employee.EmploymentDate), "Дата працевлаштування");
            EmployeeDataGridView.Columns.Add(nameof(Employee.Salary), "Зарплатня");
            EmployeeDataGridView.Columns[nameof(Employee.IdEmployee)].ReadOnly = true;
        }

        private async Task RefreshDataGridAsync()
        {
            EmployeeDataGridView.Rows.Clear();
            try
            {
                var employees = await _apiClient.GetAllAsync();
                foreach (var emp in employees)
                {
                    EmployeeDataGridView.Rows.Add(emp.IdEmployee, emp.Name, emp.Address, emp.Phone, emp.EmploymentDate.ToShortDateString(), emp.Salary);
                }
            }
            catch (Exception ex) 
            { 
                MessageBox.Show($"Помилка завантаження: {ex.Message}"); 
            }
        }

        private void ClearFields()
        {
            IdEmployeesTextBox.Text = string.Empty;
            NameTextBox.Text = string.Empty;
            AddressTextBox.Text = string.Empty;
            PhoneTextBox.Text = string.Empty;
            EmploymentDateTextBox.Text = string.Empty;
            SalaryTextBox.Text = string.Empty;
        }

        private void EmployeeDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var row = EmployeeDataGridView.Rows[e.RowIndex];
            IdEmployeesTextBox.Text = row.Cells[0].Value.ToString();
            NameTextBox.Text = row.Cells[1].Value.ToString();
            AddressTextBox.Text = row.Cells[2].Value.ToString();
            PhoneTextBox.Text = row.Cells[3].Value.ToString();
            EmploymentDateTextBox.Text = row.Cells[4].Value.ToString();
            SalaryTextBox.Text = row.Cells[5].Value.ToString();
        }

        private async Task UpdateRowAsync()
        {
            if (string.IsNullOrWhiteSpace(IdEmployeesTextBox.Text))
            {
                MessageBox.Show("Будь ласка, перевірте коректність введених даних (ID, EmploymentDate, Salary).", "Некоректний ввід", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var employee = new Employee
                {
                    IdEmployee = int.Parse(IdEmployeesTextBox.Text),
                    Name = NameTextBox.Text,
                    Address = AddressTextBox.Text,
                    Phone = PhoneTextBox.Text,
                    EmploymentDate = DateTime.Parse(EmploymentDateTextBox.Text),
                    Salary = int.Parse(SalaryTextBox.Text)
                };
                await _apiClient.UpdateAsync(employee);
                MessageBox.Show("Запис успішно оновлено!", "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearFields();
                await RefreshDataGridAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка оновлення: {ex.Message}");
            }
        }

        private async Task DeleteRowAsync()
        {
            if (EmployeeDataGridView.CurrentCell == null)
            {
                MessageBox.Show("Будь ласка, виберіть рядок для видалення.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int id = Convert.ToInt32(EmployeeDataGridView.CurrentRow.Cells[0].Value);
            if (MessageBox.Show($"Видалити працівника ID: {id}?", "Підтвердження", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    await _apiClient.DeleteAsync(id);
                    MessageBox.Show("Запис успішно видалено.", "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearFields();
                    await RefreshDataGridAsync();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Помилка видалення: {ex.Message}", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

		private async Task SearchAsync(string searchQuery)
		{
			EmployeeDataGridView.Rows.Clear();
			try
			{
				var employees = await _apiClient.SearchAsync(searchQuery);
				if (employees != null)
				{
					foreach (var employee in employees)
					{
						EmployeeDataGridView.Rows.Add(
							employee.IdEmployee,
							employee.Name,
							employee.Address,
							employee.Phone,
							employee.EmploymentDate.ToShortDateString(),
							employee.Salary
						);
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show($"Помилка пошуку: {ex.Message}");
			}
		}

		private async void AddButton_Click(object sender, EventArgs e)
        {
            new FormAddEmployees(new EmployeeApiClient()).ShowDialog();
            await RefreshDataGridAsync();
        }

        private async void UpdateButton_Click(object sender, EventArgs e) => await UpdateRowAsync();
        private async void DeleteButton_Click(object sender, EventArgs e) => await DeleteRowAsync();
        private async void SaveButton_Click(object sender, EventArgs e) => await UpdateRowAsync();
        private async void RefreshLabel_Click(object sender, EventArgs e) => await RefreshDataGridAsync();
        private async void SearchTextBox_TextChanged(object sender, EventArgs e)
		{
			string searchQuery = searchTextBox.Text;

			if (string.IsNullOrWhiteSpace(searchQuery))
			{
				await RefreshDataGridAsync();
			}
			else
			{
				await SearchAsync(searchQuery);
			}
		}

		private void RepairsButton_Click(object sender, EventArgs e) => base.NavigateToRepairs();
        private void EployeesButton_Click(object sender, EventArgs e) => base.NavigateToEmployees();
        private void RepairInfosButton_Click(object sender, EventArgs e) => base.NavigateToRepairInfos();
        private void AssemblysButton_Click(object sender, EventArgs e) => base.NavigateToAssemblys();
        private void CarsButton_Click(object sender, EventArgs e) => base.NavigateToCars();
        private void ControlStripMenuItem_Click(object sender, EventArgs e) => base.ShowAdminPanel();
        private void ToolStripMenuItem1_Click(object sender, EventArgs e) => base.ShowStatistics();
    }
}