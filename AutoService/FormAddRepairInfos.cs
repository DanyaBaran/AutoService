using AutoService.Shared.Models;

namespace AutoService
{
    public partial class FormAddRepairInfos : Form
    {
        private readonly RepairInfoApiClient _apiClient;

        public FormAddRepairInfos(RepairInfoApiClient apiClient)
        {
            InitializeComponent();
            _apiClient = apiClient;
            StartPosition = FormStartPosition.CenterScreen;
        }
        private async void SaveButton_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(repairIdTextBox.Text, out int repairId) ||
                !int.TryParse(assemblyIdTextBox.Text, out int assemblyId) ||
                !int.TryParse(amountPriceTextBox.Text, out int amountPrice) ||
                !int.TryParse(coefDifficultTextBox.Text, out int coefDifficult))
            {
                MessageBox.Show("Будь ласка, перевірте коректність введених числових даних (RepairId, AssemblyId, AmountPrice, CoefDifficult).", "Некоректний ввід", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var newRepairInfo = new RepairInfo
                {
                    RepairId = repairId,
                    AssemblyId = assemblyId,
                    AmountPrice = amountPrice,
                    CoefDifficult = coefDifficult
                };
                await _apiClient.AddAsync(newRepairInfo);
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
