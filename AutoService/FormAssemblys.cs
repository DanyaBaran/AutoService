using AutoService.Shared.Models;
using AutoService.Infrastructure;

namespace AutoService
{
    public partial class FormAssemblys : BaseForm
    {
        private readonly AssemblyApiClient _apiClient;

        public FormAssemblys(CheckUser user, ServiceProvider serviceProvider) : base(user, serviceProvider)
        {
            InitializeComponent();
            _apiClient = _serviceProvider.AssemblyApiClient;
            StartPosition = FormStartPosition.CenterScreen;
        }

        private async void FormAssemblys_Load(object sender, EventArgs e)
        {
            base.SetUserStatus(TlsUserStatus);
            base.SetupPermissions(UpdateButton, DeleteButton, ControlStripMenuItem, ToolStripMenuItem1);
            CreateColumns();
            await RefreshDataGridAsync();
        }

        private void CreateColumns()
        {
            AssemblyDataGridView.Columns.Clear();
            AssemblyDataGridView.Columns.Add(nameof(Assembly.IdAssembly), "ID");
            AssemblyDataGridView.Columns.Add(nameof(Assembly.NameAssembly), "Назва вузла");
            AssemblyDataGridView.Columns.Add(nameof(Assembly.PriceAssembly), "Ціна");
            AssemblyDataGridView.Columns.Add(nameof(Assembly.Description), "Опис");
            AssemblyDataGridView.Columns[nameof(Assembly.IdAssembly)].ReadOnly = true;
        }

        private async Task RefreshDataGridAsync()
        {
            AssemblyDataGridView.Rows.Clear();
            try
            {
                var items = await _apiClient.GetAllAsync();
                foreach (var item in items)
                {
                    AssemblyDataGridView.Rows.Add(item.IdAssembly, item.NameAssembly, item.PriceAssembly, item.Description);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка завантаження: {ex.Message}");
            }
        }

        private void ClearFields()
        {
            idAssemblyTextBox.Text = string.Empty;
            NameAssemblyTextBox.Text = string.Empty;
            PriceAssemblyTextBox.Text = string.Empty;
            DescriptionTextBox.Text = string.Empty;
        }

        private void AssemblyDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var row = AssemblyDataGridView.Rows[e.RowIndex];
            idAssemblyTextBox.Text = row.Cells[0].Value.ToString();
            NameAssemblyTextBox.Text = row.Cells[1].Value.ToString();
            PriceAssemblyTextBox.Text = row.Cells[2].Value.ToString();
            DescriptionTextBox.Text = row.Cells[3].Value.ToString();
        }

        private async Task UpdateRowAsync()
        {
            if (!int.TryParse(idAssemblyTextBox.Text, out int id) ||
                !int.TryParse(PriceAssemblyTextBox.Text, out int priceAssembly))
            {
                MessageBox.Show("Будь ласка, перевірте коректність ID та ціни.", "Некоректний ввід", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var nameAssembly = NameAssemblyTextBox.Text.Trim();
            var description = DescriptionTextBox.Text.Trim();

            try
            {
                var assembly = new Assembly
                {
                    IdAssembly = id,
                    NameAssembly = nameAssembly,
                    PriceAssembly = priceAssembly,
                    Description = description
                };
                await _apiClient.UpdateAsync(assembly);
                MessageBox.Show("Запис успішно оновлено!", "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearFields();
                await RefreshDataGridAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка оновлення: {ex.Message}", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task DeleteRowAsync()
        {
            if (AssemblyDataGridView.CurrentCell == null)
            {
                MessageBox.Show("Будь ласка, виберіть рядок для видалення.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            int id = Convert.ToInt32(AssemblyDataGridView.CurrentRow.Cells[0].Value);

            if (MessageBox.Show($"Видалити вузол ID: {id}?", "Підтвердження", MessageBoxButtons.YesNo) == DialogResult.Yes)
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
            AssemblyDataGridView.Rows.Clear();
            try
            {
                var items = await _apiClient.SearchAsync(searchTextBox.Text);
                if (items != null)
                {
                    foreach (var item in items)
                    {
                        AssemblyDataGridView.Rows.Add(
                            item.IdAssembly, 
                            item.NameAssembly, 
                            item.PriceAssembly, 
                            item.Description
                        );
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show($"Помилка пошуку: {ex.Message}"); }
        }

        private async void AddButton_Click(object sender, EventArgs e)
        {
            new FormAddAssemblys(new AssemblyApiClient()).ShowDialog();
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

