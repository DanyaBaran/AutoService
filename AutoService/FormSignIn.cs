using AutoService.Infrastructure;

namespace AutoService
{
    public partial class FormSignIn : Form
    {
        private readonly AuthApiClient _authApiClient;

        public FormSignIn(ServiceProvider serviceProvider)
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            _authApiClient = new AuthApiClient();
        }

        private void FormSignIn_Load(object sender, EventArgs e)
        {
            passwordTextBox.PasswordChar = '•';
            logInTextBox.MaxLength = 50;
            passwordTextBox.MaxLength = 50;
        }

        private async void SignInButton_Click(object sender, EventArgs e)
        {
            var request = new RegisterRequest(logInTextBox.Text.Trim(), passwordTextBox.Text.Trim());
            if (string.IsNullOrEmpty(request.Username) || string.IsNullOrEmpty(request.Password))
            {
                MessageBox.Show("Будь ласка, введіть логін та пароль.", "Помилка реєстрації", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                bool isSuccess = await _authApiClient.RegisterAsync(request);
                if (isSuccess)
                {
                    MessageBox.Show("Реєстрація успішна! Тепер ви можете увійти, використовуючи свої дані.", "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Користувач з таким іменем вже існує.", "Помилка реєстрації", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка з'єднання з сервером: {ex.Message}", "Помилка мережі", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
