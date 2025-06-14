using System.Data.SqlClient;
using AutoService.Shared.Models;
using AutoService.Infrastructure;

namespace AutoService
{

    public partial class FormCars : BaseForm
    {
        private readonly CarApiClient _apiClient;

        public FormCars(CheckUser user, ServiceProvider serviceProvider) : base(user, serviceProvider)
        {
            InitializeComponent();
            _apiClient = _serviceProvider.CarApiClient;
            StartPosition = FormStartPosition.CenterScreen;
        }

        private async void FormCars_Load(object sender, EventArgs e)
        {
            base.SetUserStatus(TlsUserStatus);
            base.SetupPermissions(UpdateButton, DeleteButton, ControlStripMenuItem, ToolStripMenuItem1);
            CreateColumns();
            await RefreshDataGridAsync();
        }

        private void CreateColumns()
        {
            CarDataGridView.Columns.Clear();
            CarDataGridView.Columns.Add(nameof(Car.IdCar), "ID");
            CarDataGridView.Columns.Add(nameof(Car.NameMark), "Марка");
            CarDataGridView.Columns.Add(nameof(Car.NameModel), "Модель");
            CarDataGridView.Columns.Add(nameof(Car.DateReleaseCar), "Дата випуску");
            CarDataGridView.Columns[nameof(Car.IdCar)].ReadOnly = true;
        }

        private async Task RefreshDataGridAsync()
        {
            CarDataGridView.Rows.Clear();
            try
            {
                var cars = await _apiClient.GetAllAsync();
                foreach (var car in cars)
                {
                    CarDataGridView.Rows.Add(car.IdCar, car.NameMark, car.NameModel, car.DateReleaseCar.ToShortDateString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Не вдалося завантажити дані з сервера: {ex.Message}", "Помилка мережі", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearFields()
        {
            idCarTextBox.Text = string.Empty;
            NameMarkTextBox.Text = string.Empty;
            NameModelTextBox.Text = string.Empty;
            DateReleaseCarTextBox.Text = string.Empty;
        }

        private async Task SearchAsync(string searchQuery)
        {
            CarDataGridView.Rows.Clear();
            try
            {
                var cars = await _apiClient.SearchAsync(searchTextBox.Text);
				if (cars != null)
				{
					foreach (var car in cars)
					{
						CarDataGridView.Rows.Add(
							car.IdCar,
							car.NameMark,
							car.NameModel,
							car.DateReleaseCar.ToShortDateString()
						);
					}
				}
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка пошуку: {ex.Message}", "Помилка мережі", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task DeleteRowAsync()
        {
            if (CarDataGridView.CurrentCell == null)
            {
                MessageBox.Show("Будь ласка, виберіть рядок для видалення.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            int carId = Convert.ToInt32(CarDataGridView.CurrentRow.Cells["IdCar"].Value);

            var result = MessageBox.Show($"Ви впевнені, що хочете видалити автомобіль з ID: {carId}?", "Підтвердження видалення", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    await _apiClient.DeleteAsync(carId);
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

        private async Task UpdateRowAsync()
        {
            if (!int.TryParse(idCarTextBox.Text, out int id) ||
                !DateTime.TryParse(DateReleaseCarTextBox.Text, out DateTime dateReleaseCar))
            {
                MessageBox.Show("Будь ласка, перевірте коректність введених даних (ID, DateReleaseCar).", "Некоректний ввід", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var nameMark = NameMarkTextBox.Text.Trim();
            var nameModel = NameModelTextBox.Text.Trim();

            try
            {
                var updatedCar = new Car
                {
                    IdCar = id,
                    NameMark = nameMark,
                    NameModel = nameModel,
                    DateReleaseCar = dateReleaseCar
                };
                await _apiClient.UpdateAsync(updatedCar);
                MessageBox.Show("Запис успішно оновлено!", "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearFields();
                await RefreshDataGridAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка оновлення: {ex.Message}", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CarDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var row = CarDataGridView.Rows[e.RowIndex];
            idCarTextBox.Text = row.Cells[0].Value.ToString();
            NameMarkTextBox.Text = row.Cells[1].Value.ToString();
            NameModelTextBox.Text = row.Cells[2].Value.ToString();
            DateReleaseCarTextBox.Text = row.Cells[3].Value.ToString();
        }

        private async void AddButton_Click(object sender, EventArgs e)
        {
            new FormAddCars(_serviceProvider.CarApiClient).ShowDialog();
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