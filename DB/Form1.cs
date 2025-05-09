using MySql.Data.MySqlClient;
using System.Data;

namespace DB
{
    public partial class Form1 : Form
    {
        private MySqlConnection conn;
        private bool isConnected = false;

        private CancellationTokenSource? tokenSource;

        public Form1()
        {
            InitializeComponent();

            btnLoadTable.Enabled = false;
            btnDisconnect.Enabled = false;
        }


        private void CurrentTime()
        {
            toolStripStatusLabel1.Text = DateTime.Now.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string user = tb_User.Text.Trim();
            string password = tb_Password.Text;

            string[] allowedUsers = { "mes" };
            string[] restrictChar = { ";", "--", "'", "#", "=", "%", "/*", "*/", "\"", "\\" };

            if (!allowedUsers.Contains(user))
            {
                MessageBox.Show("������ ���� ����� �����Դϴ�.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            foreach (string c in restrictChar)
            {
                if (user.Contains(c) || password.Contains(c))
                {
                    MessageBox.Show("��й�ȣ�� ������ ���� ���ڰ� ���ԵǾ� �ֽ��ϴ�.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            string strConn = @$"server=10.10.24.179;
                            port=3306;database=product_db;
                            uid={user};password={password};";
            try
            {
                conn = new MySqlConnection(strConn);
                conn.Open();
                isConnected = conn.State == ConnectionState.Open;

                if (isConnected)
                {
                    btnLoadTable.Enabled = true;
                    btnDisconnect.Enabled = true;
                    btnConnect.Enabled = false;

                    MessageBox.Show("DB ���� ����");
                    tb_User.Text = "";
                    tb_Password.Text = "";
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }

        private void LoadTable(string tableName)
        {
            try
            {
                string query = $"SELECT * FROM {tableName} ORDER BY id ASC";
                MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"������ ��ȸ ����: {ex.Message}");
            }
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            tokenSource = new CancellationTokenSource();
            await StartPolling(tokenSource.Token);
        }

        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            if (conn != null && isConnected)
            {
                conn.Close();
                isConnected = conn.State == ConnectionState.Closed;
                dataGridView1.DataSource = null; // Clear the DataGridView
                MessageBox.Show("DB ���� ������.");

                btnLoadTable.Enabled = false;
                btnDisconnect.Enabled = false;
                btnConnect.Enabled = true;
            }
        }

        private void btnLoadTable_Click(object sender, EventArgs e)
        {
            if (isConnected)
            {
                try
                {
                    string tableName = cmbTableSelect.SelectedItem.ToString();
                    LoadTable(tableName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"���̺� �ε� ����: {ex.Message}");
                }

            }
        }

        private async Task StartPolling(CancellationToken token)
        {
            while (!token.IsCancellationRequested)
            {
                await Task.Run(() => CurrentTime());
                await Task.Delay(1, token);
            }
        }
    }
}
