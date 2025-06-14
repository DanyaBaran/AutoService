namespace AutoService
{
    public partial class Statistic : Form
    {
        private readonly StatisticsApiClient _apiClient;

        public Statistic(StatisticsApiClient apiClient)
        {
            InitializeComponent();
            _apiClient = apiClient;
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void MonthButton_Click(object sender, EventArgs e)
        {
            new DiagramRepairs(_apiClient).ShowDialog();
        }

        private void YearButton_Click(object sender, EventArgs e)
        {
            new DiagramYear(_apiClient).ShowDialog();
        }

        private void MarksButton_Click(object sender, EventArgs e)
        {
            new PopularMarks(_apiClient).ShowDialog();
        }
    }
}
