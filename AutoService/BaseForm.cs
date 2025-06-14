using AutoService.Infrastructure;

namespace AutoService
{
    public partial class BaseForm : Form
    {
        protected readonly CheckUser _user;
        protected readonly ServiceProvider _serviceProvider;

        private Form _nextForm = null;

        protected BaseForm()
        {
            if (!DesignMode)
            {
                InitializeComponent();
            }
        }

        protected BaseForm(CheckUser user, ServiceProvider serviceProvider)
        {
            InitializeComponent();
            _user = user;
            _serviceProvider = serviceProvider;
            StartPosition = FormStartPosition.CenterScreen;

            this.FormClosed += BaseForm_FormClosed;
        }

        private void BaseForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            _nextForm?.Show();
        }

        protected void NavigateTo(Form nextForm)
        {
            _nextForm = nextForm;
            this.Close();
        }

        protected void SetupPermissions(Button updateButton, Button deleteButton, ToolStripMenuItem controlMenuItem, ToolStripMenuItem statisticMenuItem)
        {
            bool isAdmin = _user.IsAdmin;

            updateButton.Enabled = isAdmin;
            deleteButton.Enabled = isAdmin;
            controlMenuItem.Enabled = isAdmin;
            statisticMenuItem.Enabled = isAdmin;
        }

        protected void SetUserStatus(ToolStripTextBox tlsUserStatus)
        {
            tlsUserStatus.Text = $"{_user.Name} : {_user.Status}";
        }

        protected void OpenForm(Form form)
        {
            this.Hide();
            form.FormClosed += (s, args) => this.Show();
            form.Show();
        }

        protected void NavigateToRepairs() => NavigateTo(new FormRepairs(_user, _serviceProvider));
        protected void NavigateToEmployees() => NavigateTo(new FormEmployees(_user, _serviceProvider));
        protected void NavigateToRepairInfos() => NavigateTo(new FormRepairInfos(_user, _serviceProvider));
        protected void NavigateToAssemblys() => NavigateTo(new FormAssemblys(_user, _serviceProvider));
        protected void NavigateToCars() => NavigateTo(new FormCars(_user, _serviceProvider));

        protected void ShowAdminPanel()
        {
            var panelAdmin = new Panel_Admin(_serviceProvider.UserManagementApiClient);
            panelAdmin.ShowDialog();
        }

        protected void ShowStatistics()
        {
            var statistic = new Statistic(_serviceProvider.StatisticsApiClient);
            statistic.ShowDialog();
        }
    }
}
