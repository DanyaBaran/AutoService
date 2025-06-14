using AutoService.Infrastructure;
using AutoService.Shared.Models;

namespace AutoService
{
    public partial class FormRepairs : BaseForm
    {
        private readonly RepairApiClient _apiClient;

        public FormRepairs(CheckUser user, ServiceProvider serviceProvider) : base(user, serviceProvider)
        {
            InitializeComponent();
            _apiClient = new RepairApiClient();
        }

        private async void FormRepairs_Load(object sender, EventArgs e)
        {
            base.SetUserStatus(TlsUserStatus);
            base.SetupPermissions(UpdateButton, DeleteButton, ControlStripMenuItem, ToolStripMenuItem1);
            CreateColumns();
            await RefreshDataGridAsync();
        }

        private void CreateColumns()
        {
            RepairDataGridView.Columns.Clear();
            RepairDataGridView.Columns.Add(nameof(Repair.IdRepair), "ID");
            RepairDataGridView.Columns.Add(nameof(Repair.EmployeeId), "ID Працівника");
            RepairDataGridView.Columns.Add(nameof(Repair.CarId), "ID Авто");
            RepairDataGridView.Columns.Add(nameof(Repair.ContactOwner), "Контакт власника");
            RepairDataGridView.Columns.Add(nameof(Repair.DateBegin), "Дата початку");
            RepairDataGridView.Columns.Add(nameof(Repair.DateEnd), "Дата кінця");
            RepairDataGridView.Columns[nameof(Repair.IdRepair)].ReadOnly = true;
        }

        private async Task RefreshDataGridAsync()
        {
            RepairDataGridView.Rows.Clear();
            try
            {
                var repairs = await _apiClient.GetAllAsync();
                foreach (var repair in repairs)
                {
                    RepairDataGridView.Rows.Add(repair.IdRepair, repair.EmployeeId, repair.CarId, repair.ContactOwner, repair.DateBegin.ToShortDateString(), repair.DateEnd.HasValue ? repair.DateEnd.Value.ToShortDateString() : "");
                }
            }
            catch (Exception ex) { MessageBox.Show($"Помилка завантаження даних: {ex.Message}"); }
        }

        private void ClearFields()
        {
            idRepairTextBox.Text = string.Empty;
            employeeIdTextBox.Text = string.Empty;
            carIdTextBox.Text = string.Empty;
            contactOwnerTextBox.Text = string.Empty;
            dateBeginTextBox.Text = string.Empty;
            dateEndTextBox.Text = string.Empty;
        }

        private void RepairDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var row = RepairDataGridView.Rows[e.RowIndex];
            idRepairTextBox.Text = row.Cells[0].Value.ToString();
            employeeIdTextBox.Text = row.Cells[1].Value.ToString();
            carIdTextBox.Text = row.Cells[2].Value.ToString();
            contactOwnerTextBox.Text = row.Cells[3].Value.ToString();
            dateBeginTextBox.Text = row.Cells[4].Value.ToString();
            dateEndTextBox.Text = row.Cells[5].Value.ToString();
        }

        private async void AddButton_Click(object sender, EventArgs e)
        {
            new FormAddRepair(new RepairApiClient()).ShowDialog();
            await RefreshDataGridAsync();
        }

        private async Task UpdateRowAsync()
        {
            if (string.IsNullOrWhiteSpace(idRepairTextBox.Text))
            {
                MessageBox.Show("Будь ласка, перевірте коректність введених даних (ID, EmployeeId, CarId).", "Некоректний ввід", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                var repair = new Repair
                {
                    IdRepair = int.Parse(idRepairTextBox.Text),
                    EmployeeId = int.Parse(employeeIdTextBox.Text),
                    CarId = int.Parse(carIdTextBox.Text),
                    ContactOwner = contactOwnerTextBox.Text,
                    DateBegin = DateTime.Parse(dateBeginTextBox.Text),
                    DateEnd = DateTime.Parse(dateEndTextBox.Text)
                };
                await _apiClient.UpdateAsync(repair);
                MessageBox.Show("Запис успішно оновлено!", "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearFields();
                await RefreshDataGridAsync();
            }
            catch (Exception ex) { MessageBox.Show($"Помилка оновлення: {ex.Message}"); }
        }

        private async Task DeleteRowAsync()
        {
            if (RepairDataGridView.CurrentRow == null) return;
            int id = Convert.ToInt32(RepairDataGridView.CurrentRow.Cells[0].Value);
            if (MessageBox.Show($"Видалити запис ID: {id}?", "Підтвердження", MessageBoxButtons.YesNo) == DialogResult.Yes)
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
			RepairDataGridView.Rows.Clear();
			try
			{
				var items = await _apiClient.SearchAsync(searchQuery);
				if (items != null)
				{
					foreach (var item in items)
					{
						RepairDataGridView.Rows.Add(
							item.IdRepair,
							item.EmployeeId,
							item.CarId,
							item.ContactOwner,
							item.DateBegin.ToShortDateString(),
							item.DateEnd.HasValue ? item.DateEnd.Value.ToShortDateString() : ""
						);
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show($"Помилка пошуку: {ex.Message}");
			}
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