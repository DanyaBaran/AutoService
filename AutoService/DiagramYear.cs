using System.Data;
using System.Windows.Forms.DataVisualization.Charting;

namespace AutoService
{
    public partial class DiagramYear : Form
    {
        private readonly StatisticsApiClient _apiClient;

        public DiagramYear(StatisticsApiClient apiClient)
        {
            InitializeComponent();
            _apiClient = apiClient;
            StartPosition = FormStartPosition.CenterScreen;
        }

        private async void DiagramYear_Load(object sender, EventArgs e)
        {
            await PopulateChartDataAsync();
        }

        private async Task PopulateChartDataAsync()
        {
            try
            {
                var repairsPerYear = await _apiClient.GetRepairsPerYearAsync();

                var series = chart1.Series["RepairsPerYear"];
                series.Points.Clear();
                series.XValueType = ChartValueType.Int32;

                foreach (var entry in repairsPerYear.OrderBy(e => e.Key))
                {
                    series.Points.AddXY(entry.Key, entry.Value);
                }

                if (series.Points.Count == 0)
                {
                    MessageBox.Show("Немає даних для побудови діаграми.", "Інформація", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка завантаження статистики: {ex.Message}", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
