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

        // 로그인 버튼 클릭 시 DB 연결 시도
        // 사용자 ID 및 비밀번호 유효성 검사
        // 연결 성공 시 테이블 조회 및 연결 해제 버튼 활성화
        private void button1_Click(object sender, EventArgs e)
        {
            string user = tb_User.Text.Trim();
            string password = tb_Password.Text;

            string[] allowedUsers = { "mes" };
            string[] restrictChar = { ";", "--", "'", "#", "=", "%", "/*", "*/", "\"", "\\" };

            if (!allowedUsers.Contains(user))
            {
                MessageBox.Show("허용되지 않은 사용자 형식입니다.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            foreach (string c in restrictChar)
            {
                if (user.Contains(c) || password.Contains(c))
                {
                    MessageBox.Show("비밀번호에 허용되지 않은 문자가 포함되어 있습니다.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

                    MessageBox.Show("DB 연결 성공");
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

        // 선택된 테이블의 모든 데이터를 조회하여 DataGridView에 표시
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
                MessageBox.Show($"데이터 조회 실패: {ex.Message}");
            }
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            tokenSource = new CancellationTokenSource();
            await StartPolling(tokenSource.Token);
        }

        // DB 연결 해제
        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            if (conn != null && isConnected)
            {
                conn.Close();
                isConnected = conn.State == ConnectionState.Closed;
                dataGridView1.DataSource = null; // Clear the DataGridView
                MessageBox.Show("DB 연결 해제됨.");

                btnLoadTable.Enabled = false;
                btnDisconnect.Enabled = false;
                btnConnect.Enabled = true;
            }
        }

        // DropDown 테이블 목록을 조회
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
                    MessageBox.Show($"테이블 로드 실패: {ex.Message}");
                }

            }
        }

        // 현재 시간 비동기로 표시
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
