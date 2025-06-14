using AutoService.Shared.Models;
using AutoService.Infrastructure;

namespace AutoService
{
    public partial class MainForm : Form
    {
        private readonly ServiceProvider _serviceProvider;
        private readonly AuthApiClient _authApiClient;

        public MainForm(ServiceProvider serviceProvider)
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            _serviceProvider = serviceProvider;
            _authApiClient = new AuthApiClient();
        }


        private void MainForm_Load(object sender, EventArgs e)
        {
            passwordTextBox.PasswordChar = '•';
            logInTextBox.MaxLength = 50;
            passwordTextBox.MaxLength = 50;
        }

        private async void LogInButton_Click(object sender, EventArgs e)
        {
            var request = new LoginRequest(logInTextBox.Text.Trim(), passwordTextBox.Text.Trim());
            if (string.IsNullOrEmpty(request.Username) || string.IsNullOrEmpty(request.Password))
            {
                MessageBox.Show("Будь ласка, введіть логін та пароль.", "Помилка входу", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                User authenticatedUser = await _authApiClient.LoginAsync(request);
                if (authenticatedUser != null)
                {
                    var user = new CheckUser(authenticatedUser);
                    this.Hide();
                    var formRepairs = new FormRepairs(user, _serviceProvider);
                    formRepairs.Show();
                }
                else
                {
                    MessageBox.Show("Такого акаунта не існує або невірний логін/пароль.", "Акаунт не існує", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка з'єднання з сервером: {ex.Message}", "Помилка мережі", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LinkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var formSignIn = new FormSignIn(_serviceProvider);
            formSignIn.ShowDialog();
        }
    }
}

