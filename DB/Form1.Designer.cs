namespace DB
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            cmbTableSelect = new ComboBox();
            tb_User = new TextBox();
            tb_Password = new TextBox();
            label1 = new Label();
            label2 = new Label();
            btnConnect = new Button();
            btnDisconnect = new Button();
            label3 = new Label();
            btnLoadTable = new Button();
            dataGridView1 = new DataGridView();
            statusStrip1 = new StatusStrip();
            toolStripStatusLabel1 = new ToolStripStatusLabel();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            statusStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // cmbTableSelect
            // 
            cmbTableSelect.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTableSelect.FormattingEnabled = true;
            cmbTableSelect.Items.AddRange(new object[] { "OK", "NG" });
            cmbTableSelect.Location = new Point(191, 131);
            cmbTableSelect.Name = "cmbTableSelect";
            cmbTableSelect.Size = new Size(134, 23);
            cmbTableSelect.TabIndex = 0;
            // 
            // tb_User
            // 
            tb_User.Location = new Point(191, 36);
            tb_User.Name = "tb_User";
            tb_User.Size = new Size(134, 23);
            tb_User.TabIndex = 1;
            // 
            // tb_Password
            // 
            tb_Password.Location = new Point(191, 65);
            tb_Password.Name = "tb_Password";
            tb_Password.PasswordChar = '*';
            tb_Password.Size = new Size(134, 23);
            tb_Password.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(111, 39);
            label1.Name = "label1";
            label1.Size = new Size(59, 15);
            label1.TabIndex = 3;
            label1.Text = "username";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(111, 68);
            label2.Name = "label2";
            label2.Size = new Size(57, 15);
            label2.TabIndex = 4;
            label2.Text = "password";
            // 
            // btnConnect
            // 
            btnConnect.Location = new Point(381, 39);
            btnConnect.Name = "btnConnect";
            btnConnect.Size = new Size(153, 23);
            btnConnect.TabIndex = 5;
            btnConnect.Text = "Database Connect";
            btnConnect.UseVisualStyleBackColor = true;
            btnConnect.Click += button1_Click;
            // 
            // btnDisconnect
            // 
            btnDisconnect.Location = new Point(381, 68);
            btnDisconnect.Name = "btnDisconnect";
            btnDisconnect.Size = new Size(153, 23);
            btnDisconnect.TabIndex = 6;
            btnDisconnect.Text = "Database Disconnect";
            btnDisconnect.UseVisualStyleBackColor = true;
            btnDisconnect.Click += btnDisconnect_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(111, 134);
            label3.Name = "label3";
            label3.Size = new Size(72, 15);
            label3.TabIndex = 7;
            label3.Text = "Select_Table";
            // 
            // btnLoadTable
            // 
            btnLoadTable.Location = new Point(381, 130);
            btnLoadTable.Name = "btnLoadTable";
            btnLoadTable.Size = new Size(153, 24);
            btnLoadTable.TabIndex = 8;
            btnLoadTable.Text = "Database Load";
            btnLoadTable.UseVisualStyleBackColor = true;
            btnLoadTable.Click += btnLoadTable_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridView1.BackgroundColor = SystemColors.ButtonHighlight;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(22, 175);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(623, 291);
            dataGridView1.TabIndex = 9;
            // 
            // statusStrip1
            // 
            statusStrip1.Items.AddRange(new ToolStripItem[] { toolStripStatusLabel1 });
            statusStrip1.Location = new Point(0, 483);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(675, 22);
            statusStrip1.TabIndex = 10;
            statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            toolStripStatusLabel1.Size = new Size(121, 17);
            toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(675, 505);
            Controls.Add(statusStrip1);
            Controls.Add(dataGridView1);
            Controls.Add(btnLoadTable);
            Controls.Add(label3);
            Controls.Add(btnDisconnect);
            Controls.Add(btnConnect);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(tb_Password);
            Controls.Add(tb_User);
            Controls.Add(cmbTableSelect);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cmbTableSelect;
        private TextBox tb_User;
        private TextBox tb_Password;
        private Label label1;
        private Label label2;
        private Button btnConnect;
        private Button btnDisconnect;
        private Label label3;
        private Button btnLoadTable;
        private DataGridView dataGridView1;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel toolStripStatusLabel1;
    }
}
