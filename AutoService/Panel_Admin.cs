using AutoService.Shared.Models;

namespace AutoService
{
    public partial class Panel_Admin : Form
    {
        private readonly UserManagementApiClient _apiClient;
        private List<User> _initialUsers;
        public Panel_Admin(UserManagementApiClient apiClient)
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            _apiClient = apiClient;
        }

        private async void Panel_Admin_Load(object sender, EventArgs e)
        {
            CreateColumns();
            await RefreshDataGridAsync();
        }

        private void CreateColumns()
        {
            dataGridView1.Columns.Clear();
            dataGridView1.Columns.Add(nameof(User.Id), "ID");
            dataGridView1.Columns.Add(nameof(User.Name), "Логін");
            var checkColumn = new DataGridViewCheckBoxColumn
            {
                HeaderText = "IsAdmin",
                Name = nameof(User.IsAdmin),
                ReadOnly = false
            };
            dataGridView1.Columns.Add(checkColumn);
            dataGridView1.Columns[nameof(User.Id)].ReadOnly = true;
            dataGridView1.Columns[nameof(User.Name)].ReadOnly = true;
        }

        private async Task RefreshDataGridAsync()
        {
            dataGridView1.Rows.Clear();

            try
            {
                _initialUsers = await _apiClient.GetAllAsync();
                if (_initialUsers != null)
                {
                    foreach (var user in _initialUsers)
                    {
                        dataGridView1.Rows.Add(user.Id, user.Name, user.IsAdmin);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка завантаження користувачів: {ex.Message}", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void SaveButton_Click(object sender, EventArgs e)
        {
            try
            {
                for(int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    var row = dataGridView1.Rows[i];
                    if (row.IsNewRow) continue;

                    int id = Convert.ToInt32(row.Cells[nameof(User.Id)].Value);
                    bool newIsAdmin = Convert.ToBoolean(row.Cells[nameof(User.IsAdmin)].Value);

                    var originalUser = _initialUsers.Find(u => u.Id == id);
                    if (originalUser != null && originalUser.IsAdmin != newIsAdmin)
                    {
                        await _apiClient.UpdateAdminStatusAsync(id, newIsAdmin);
                    }
                }
                MessageBox.Show("Зміни збережено успішно!", "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);
                await RefreshDataGridAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка збереження: {ex.Message}", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void DeleteButton_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentCell == null)
            {
                MessageBox.Show("Будь ласка, виберіть рядок для видалення.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
            string name = dataGridView1.CurrentRow.Cells[nameof(User.Name)].Value.ToString();

            if (MessageBox.Show($"Ви впевнені, що хочете видалити користувача '{name}' (ID: {id})?", "Підтвердження видалення", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                try
                {
                    await _apiClient.DeleteAsync(id);
                    await RefreshDataGridAsync();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Помилка видалення: {ex.Message}", "Помилка сервера", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }
    }
}
