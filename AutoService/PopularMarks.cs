using System.Windows.Forms.DataVisualization.Charting;

namespace AutoService
{
    public partial class PopularMarks : Form
    {
        private readonly StatisticsApiClient _apiClient;

        public PopularMarks(StatisticsApiClient apiClient)
        {
            InitializeComponent();
            _apiClient = apiClient;
            StartPosition = FormStartPosition.CenterScreen;
        }

        private async void PopularMarks_Load(object sender, EventArgs e)
        {
            await PopulateChartDataAsync();
        }

        private async Task PopulateChartDataAsync()
        {
            try
            {
                var popularMarksData = await _apiClient.GetPopularCarMarksAsync();

                var series = chart1.Series["PopularCarMarks"];
                series.Points.Clear();
                series.ChartType = SeriesChartType.Pie;

                foreach (var entry in popularMarksData)
                {
                    DataPoint dataPoint = new DataPoint();
                    dataPoint.SetValueY(entry.Value);
                    dataPoint.AxisLabel = entry.Key;
                    dataPoint.Label = $"{entry.Key} ({entry.Value})";
                    series.Points.Add(dataPoint);
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
