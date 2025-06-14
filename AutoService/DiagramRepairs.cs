using System.Data;
using System.Windows.Forms.DataVisualization.Charting;

namespace AutoService
{
    public partial class DiagramRepairs : Form
    {
        private readonly StatisticsApiClient _apiClient;

        public DiagramRepairs(StatisticsApiClient apiClient)
        {
            InitializeComponent();
            _apiClient = apiClient;
            StartPosition = FormStartPosition.CenterScreen;
        }

        private async void DiagramRepairs_Load(object sender, EventArgs e)
        {
            await PopulateChartDataAsync();
        }
        
        private async Task PopulateChartDataAsync()
        {
            try
            {
                var repairsPerMonth = await _apiClient.GetRepairsPerMonthAsync();
                var series = chart1.Series["RepairsPerMonth"];

                series.Points.Clear();
                series.XValueType = ChartValueType.Int32;
                var chartArea = chart1.ChartAreas[0];
                chartArea.AxisX.Minimum = 0;
                chartArea.AxisX.Maximum = 12;
                chartArea.AxisX.Interval = 1;

                if (repairsPerMonth == null || !repairsPerMonth.Any())
                {
                    MessageBox.Show("Немає даних для побудови діаграми.", "Інформація", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                foreach (var entry in repairsPerMonth.OrderBy(e => e.Key))
                {
                    series.Points.AddXY(entry.Key, entry.Value);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка завантаження статистики: {ex.Message}", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
