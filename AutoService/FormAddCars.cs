using AutoService.Shared.Models;
using System.Data.SqlClient;

namespace AutoService
{
    public partial class FormAddCars : Form
    {
        private readonly CarApiClient _carApiClient;

        public FormAddCars(CarApiClient carApiClient)
        {
            InitializeComponent();
            _carApiClient = carApiClient;
            StartPosition = FormStartPosition.CenterScreen;
        }
        private async void SaveButton_Click(object sender, EventArgs e)
        {
            var nameMark = NameMarkTextBox.Text.Trim();
            var nameModel = NameModelTextBox.Text.Trim();
            var dateReleaseCarText = dateReleaseCarTextBox.Text.Trim();
            DateTime parsedDate;

            if (string.IsNullOrEmpty(nameMark) || string.IsNullOrEmpty(nameModel) || string.IsNullOrEmpty(dateReleaseCarText))
            {
                MessageBox.Show("Будь ласка, заповніть всі поля.", "Некоректний ввід", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!DateTime.TryParse(dateReleaseCarText, out parsedDate))
            {
                MessageBox.Show("Некоректний формат дати. Використовуйте формат РРРР-ММ-ДД.", "Помилка вводу", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var newCar = new Car
                {
                    NameMark = nameMark,
                    NameModel = nameModel,
                    DateReleaseCar = parsedDate
                };
                await _carApiClient.AddAsync(newCar);
                MessageBox.Show("Запис успішно створено!", "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка додавання: {ex.Message}", "Помилка сервера", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FormAddCars_Load(object sender, EventArgs e)
        {
        }
    }
}
