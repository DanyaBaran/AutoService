using AutoService.Shared.Models;

namespace AutoService
{
    public partial class FormAddAssemblys : Form
    {
        private readonly AssemblyApiClient _apiClient;

        public FormAddAssemblys(AssemblyApiClient apiClient)
        {
            InitializeComponent();
            _apiClient = apiClient;
            StartPosition = FormStartPosition.CenterScreen;
        }
        private async void SaveButton_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(priceAssemblyTextBox.Text, out int price))
            {
                MessageBox.Show("Будь ласка, перевірте коректність введеної ціни вузла.", "Некоректний ввід", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var newAssembly = new Assembly
            {
                NameAssembly = nameAssemblyTextBox.Text.Trim(),
                PriceAssembly = price,
                Description = descriptionTextBox.Text.Trim()
            };

            if (string.IsNullOrWhiteSpace(newAssembly.NameAssembly))
            {
                MessageBox.Show("Назва вузла не може бути порожньою.", "Некоректний ввід", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                await _apiClient.AddAsync(newAssembly);
                MessageBox.Show("Вузол успішно додано!", "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка додавання: {ex.Message}", "Помилка сервера", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
