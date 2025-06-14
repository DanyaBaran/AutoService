using AutoService.Shared.Models;
using AutoService.Infrastructure;

namespace AutoService
{
    public partial class FormRepairInfos : BaseForm
    {
        private readonly RepairInfoApiClient _apiClient;

        public FormRepairInfos(CheckUser user, ServiceProvider serviceProvider) : base(user, serviceProvider)
        {
            InitializeComponent();
            _apiClient = _serviceProvider.RepairInfoApiClient;
            StartPosition = FormStartPosition.CenterScreen;
        }
        
        private async void FormRepairInfos_Load(object sender, EventArgs e)
        {
            base.SetUserStatus(TlsUserStatus);
            base.SetupPermissions(UpdateButton, DeleteButton, ControlStripMenuItem, ToolStripMenuItem1);
            CreateColumns();
            await RefreshDataGridAsync();
        }

        private void CreateColumns()
        {
            RepairInfoDataGridView.Columns.Clear();
            RepairInfoDataGridView.Columns.Add(nameof(RepairInfo.RepairId), "IdRepair");
            RepairInfoDataGridView.Columns.Add(nameof(RepairInfo.AssemblyId), "IdAssembly");
            RepairInfoDataGridView.Columns.Add(nameof(RepairInfo.AmountPrice), "Загальна ціна");
            RepairInfoDataGridView.Columns.Add(nameof(RepairInfo.CoefDifficult), "Коефіцієнт складності");
            RepairInfoDataGridView.Columns[nameof(RepairInfo.RepairId)].ReadOnly = true;
        }

        private async Task RefreshDataGridAsync()
        {
            RepairInfoDataGridView.Rows.Clear();
            try
            {
                var repairInfos = await _apiClient.GetAllAsync();
                foreach (var repairInfo in repairInfos)
                {
                    RepairInfoDataGridView.Rows.Add(repairInfo.RepairId, repairInfo.AssemblyId, repairInfo.AmountPrice, repairInfo.CoefDifficult);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка завантаження: {ex.Message}");
            }
        }

        private void ClearFields()
        {
            RepairIdTextBox.Text = string.Empty;
            AssemblyIdTextBox.Text = string.Empty;
            AmountPriceTextBox.Text = string.Empty;
            CoefDifficultTextBox.Text = string.Empty;
        }

        private void RepairInfoDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var row = RepairInfoDataGridView.Rows[e.RowIndex];
            RepairIdTextBox.Text = row.Cells[0].Value.ToString();
            AssemblyIdTextBox.Text = row.Cells[1].Value.ToString();
            AmountPriceTextBox.Text = row.Cells[2].Value.ToString();
            CoefDifficultTextBox.Text = row.Cells[3].Value.ToString();
        }

        private async void AddButton_Click(object sender, EventArgs e)
        {
            new FormAddRepairInfos(new RepairInfoApiClient()).ShowDialog();
            await RefreshDataGridAsync();
        }

        private async Task UpdateRowAsync()
        {
            if (string.IsNullOrWhiteSpace(RepairIdTextBox.Text))
            {
                MessageBox.Show("Будь ласка, перевірте коректність введених даних (RepairId, AssemblyId).", "Некоректний ввід", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                var repairInfo = new RepairInfo
                {
                    RepairId = int.Parse(RepairIdTextBox.Text),
                    AssemblyId = int.Parse(AssemblyIdTextBox.Text),
                    AmountPrice = int.Parse(AmountPriceTextBox.Text),
                    CoefDifficult = int.Parse(CoefDifficultTextBox.Text)
                };
                await _apiClient.UpdateAsync(repairInfo);
                MessageBox.Show("Запис успішно оновлено!", "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearFields();
                await RefreshDataGridAsync();
            }
            catch (Exception ex) { MessageBox.Show($"Помилка оновлення: {ex.Message}"); }
        }

        private async Task DeleteRowAsync()
        {
            if (RepairInfoDataGridView.CurrentRow == null) return;
            int id = Convert.ToInt32(RepairInfoDataGridView.CurrentRow.Cells[0].Value);
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
            RepairInfoDataGridView.Rows.Clear();
            try
            {
                var repairInfos = await _apiClient.SearchAsync(searchQuery);
                if (repairInfos != null)
                {
                    foreach (var repairInfo in repairInfos)
                    {
                        RepairInfoDataGridView.Rows.Add(
                            repairInfo.RepairId,
                            repairInfo.AssemblyId,
                            repairInfo.AmountPrice,
                            repairInfo.CoefDifficult
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