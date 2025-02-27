namespace Honeycomb.UI
{
    partial class DbImportDialouge
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            errorProvider1 = new ErrorProvider(components);
            dataGridView1 = new DataGridView();
            SaveIdColumn = new DataGridViewTextBoxColumn();
            DateColumn = new DataGridViewTextBoxColumn();
            UnderwriterNameColumn = new DataGridViewTextBoxColumn();
            PolicyNameColumn = new DataGridViewTextBoxColumn();
            EffectiveDateColumn = new DataGridViewTextBoxColumn();
            StateColumn = new DataGridViewTextBoxColumn();
            LoadSelectedPolicy = new Button();
            label2 = new Label();
            UnderWriterNameBox = new TextBox();
            PolicyNameBox = new TextBox();
            StateBox = new TextBox();
            tableLayoutPanel1 = new TableLayoutPanel();
            label9 = new Label();
            label6 = new Label();
            SaveDateEndBox = new DateTimePicker();
            label5 = new Label();
            SaveDateStartBox = new DateTimePicker();
            label3 = new Label();
            label4 = new Label();
            label7 = new Label();
            EffectiveDateStartBox = new DateTimePicker();
            label8 = new Label();
            EffectiveDateEndBox = new DateTimePicker();
            label11 = new Label();
            PolicyTypeBox = new ComboBox();
            label10 = new Label();
            RefreshAvailablePolicies = new Button();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AllowUserToOrderColumns = true;
            dataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { SaveIdColumn, DateColumn, UnderwriterNameColumn, PolicyNameColumn, EffectiveDateColumn, StateColumn });
            dataGridView1.Location = new Point(12, 27);
            dataGridView1.MinimumSize = new Size(880, 0);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Size = new Size(910, 229);
            dataGridView1.TabIndex = 0;
            // 
            // SaveIdColumn
            // 
            SaveIdColumn.HeaderText = "Save Id";
            SaveIdColumn.Name = "SaveIdColumn";
            SaveIdColumn.ReadOnly = true;
            // 
            // DateColumn
            // 
            DateColumn.HeaderText = "Save Date";
            DateColumn.Name = "DateColumn";
            // 
            // UnderwriterNameColumn
            // 
            UnderwriterNameColumn.HeaderText = "Underwriter Name";
            UnderwriterNameColumn.Name = "UnderwriterNameColumn";
            UnderwriterNameColumn.ReadOnly = true;
            // 
            // PolicyNameColumn
            // 
            PolicyNameColumn.HeaderText = "Policy Name";
            PolicyNameColumn.Name = "PolicyNameColumn";
            // 
            // EffectiveDateColumn
            // 
            EffectiveDateColumn.HeaderText = "Effective Date";
            EffectiveDateColumn.Name = "EffectiveDateColumn";
            // 
            // StateColumn
            // 
            StateColumn.HeaderText = "State";
            StateColumn.Name = "StateColumn";
            // 
            // LoadSelectedPolicy
            // 
            LoadSelectedPolicy.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            LoadSelectedPolicy.Location = new Point(751, 277);
            LoadSelectedPolicy.Name = "LoadSelectedPolicy";
            LoadSelectedPolicy.Size = new Size(79, 23);
            LoadSelectedPolicy.TabIndex = 1;
            LoadSelectedPolicy.Text = "Load ";
            LoadSelectedPolicy.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(12, 9);
            label2.Name = "label2";
            label2.Size = new Size(101, 15);
            label2.TabIndex = 2;
            label2.Text = "Available Policies:";
            // 
            // UnderWriterNameBox
            // 
            tableLayoutPanel1.SetColumnSpan(UnderWriterNameBox, 3);
            UnderWriterNameBox.Dock = DockStyle.Fill;
            UnderWriterNameBox.Location = new Point(110, 24);
            UnderWriterNameBox.Margin = new Padding(0, 0, 0, 1);
            UnderWriterNameBox.Name = "UnderWriterNameBox";
            UnderWriterNameBox.Size = new Size(215, 23);
            UnderWriterNameBox.TabIndex = 5;
            // 
            // PolicyNameBox
            // 
            tableLayoutPanel1.SetColumnSpan(PolicyNameBox, 3);
            PolicyNameBox.Dock = DockStyle.Fill;
            PolicyNameBox.Location = new Point(110, 48);
            PolicyNameBox.Margin = new Padding(0, 0, 0, 1);
            PolicyNameBox.Name = "PolicyNameBox";
            PolicyNameBox.Size = new Size(215, 23);
            PolicyNameBox.TabIndex = 6;
            // 
            // StateBox
            // 
            StateBox.Dock = DockStyle.Fill;
            StateBox.Location = new Point(430, 24);
            StateBox.Margin = new Padding(0, 0, 0, 1);
            StateBox.Name = "StateBox";
            StateBox.Size = new Size(100, 23);
            StateBox.TabIndex = 9;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            tableLayoutPanel1.AutoSize = true;
            tableLayoutPanel1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            tableLayoutPanel1.ColumnCount = 9;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel1.Controls.Add(label9, 5, 1);
            tableLayoutPanel1.Controls.Add(label6, 0, 2);
            tableLayoutPanel1.Controls.Add(StateBox, 6, 1);
            tableLayoutPanel1.Controls.Add(SaveDateEndBox, 3, 0);
            tableLayoutPanel1.Controls.Add(label5, 2, 0);
            tableLayoutPanel1.Controls.Add(SaveDateStartBox, 1, 0);
            tableLayoutPanel1.Controls.Add(PolicyNameBox, 1, 2);
            tableLayoutPanel1.Controls.Add(label3, 0, 0);
            tableLayoutPanel1.Controls.Add(label4, 0, 1);
            tableLayoutPanel1.Controls.Add(UnderWriterNameBox, 1, 1);
            tableLayoutPanel1.Controls.Add(label7, 5, 0);
            tableLayoutPanel1.Controls.Add(EffectiveDateStartBox, 6, 0);
            tableLayoutPanel1.Controls.Add(label8, 7, 0);
            tableLayoutPanel1.Controls.Add(EffectiveDateEndBox, 8, 0);
            tableLayoutPanel1.Controls.Add(label11, 5, 2);
            tableLayoutPanel1.Controls.Add(PolicyTypeBox, 6, 2);
            tableLayoutPanel1.Location = new Point(12, 277);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 3;
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.Size = new Size(648, 72);
            tableLayoutPanel1.TabIndex = 10;
            // 
            // label9
            // 
            label9.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            label9.AutoSize = true;
            label9.Location = new Point(394, 24);
            label9.Name = "label9";
            label9.Size = new Size(33, 24);
            label9.TabIndex = 11;
            label9.Text = "State";
            label9.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            label6.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            label6.AutoSize = true;
            label6.Location = new Point(33, 48);
            label6.Name = "label6";
            label6.Size = new Size(74, 24);
            label6.TabIndex = 6;
            label6.Text = "Policy Name";
            label6.TextAlign = ContentAlignment.MiddleRight;
            // 
            // SaveDateEndBox
            // 
            SaveDateEndBox.Anchor = AnchorStyles.Left;
            SaveDateEndBox.Checked = false;
            SaveDateEndBox.Format = DateTimePickerFormat.Short;
            SaveDateEndBox.Location = new Point(228, 0);
            SaveDateEndBox.Margin = new Padding(0, 0, 0, 1);
            SaveDateEndBox.MinimumSize = new Size(77, 23);
            SaveDateEndBox.Name = "SaveDateEndBox";
            SaveDateEndBox.ShowCheckBox = true;
            SaveDateEndBox.Size = new Size(97, 23);
            SaveDateEndBox.TabIndex = 4;
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            label5.AutoSize = true;
            label5.FlatStyle = FlatStyle.Popup;
            label5.Location = new Point(210, 0);
            label5.Margin = new Padding(0);
            label5.Name = "label5";
            label5.Size = new Size(18, 24);
            label5.TabIndex = 3;
            label5.Text = "to";
            label5.TextAlign = ContentAlignment.MiddleRight;
            // 
            // SaveDateStartBox
            // 
            SaveDateStartBox.Anchor = AnchorStyles.Left;
            SaveDateStartBox.Checked = false;
            SaveDateStartBox.Format = DateTimePickerFormat.Short;
            SaveDateStartBox.Location = new Point(110, 0);
            SaveDateStartBox.Margin = new Padding(0, 0, 0, 1);
            SaveDateStartBox.MinimumSize = new Size(77, 23);
            SaveDateStartBox.Name = "SaveDateStartBox";
            SaveDateStartBox.ShowCheckBox = true;
            SaveDateStartBox.Size = new Size(100, 23);
            SaveDateStartBox.TabIndex = 0;
            SaveDateStartBox.Value = new DateTime(2023, 12, 24, 0, 0, 0, 0);
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            label3.AutoSize = true;
            label3.Location = new Point(49, 0);
            label3.Name = "label3";
            label3.Size = new Size(58, 24);
            label3.TabIndex = 1;
            label3.Text = "Save Date";
            label3.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            label4.AutoSize = true;
            label4.Location = new Point(3, 24);
            label4.Name = "label4";
            label4.Size = new Size(104, 24);
            label4.TabIndex = 2;
            label4.Text = "Underwriter Name";
            label4.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label7
            // 
            label7.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            label7.AutoSize = true;
            label7.Location = new Point(348, 0);
            label7.Name = "label7";
            label7.Size = new Size(79, 24);
            label7.TabIndex = 7;
            label7.Text = "Effective Date";
            label7.TextAlign = ContentAlignment.MiddleRight;
            // 
            // EffectiveDateStartBox
            // 
            EffectiveDateStartBox.Anchor = AnchorStyles.Left;
            EffectiveDateStartBox.Checked = false;
            EffectiveDateStartBox.Format = DateTimePickerFormat.Short;
            EffectiveDateStartBox.Location = new Point(430, 0);
            EffectiveDateStartBox.Margin = new Padding(0, 0, 0, 1);
            EffectiveDateStartBox.MinimumSize = new Size(77, 23);
            EffectiveDateStartBox.Name = "EffectiveDateStartBox";
            EffectiveDateStartBox.ShowCheckBox = true;
            EffectiveDateStartBox.Size = new Size(100, 23);
            EffectiveDateStartBox.TabIndex = 8;
            EffectiveDateStartBox.Value = new DateTime(2023, 12, 24, 0, 0, 0, 0);
            // 
            // label8
            // 
            label8.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            label8.AutoSize = true;
            label8.FlatStyle = FlatStyle.Popup;
            label8.Location = new Point(530, 0);
            label8.Margin = new Padding(0);
            label8.Name = "label8";
            label8.Size = new Size(18, 24);
            label8.TabIndex = 9;
            label8.Text = "to";
            label8.TextAlign = ContentAlignment.MiddleRight;
            // 
            // EffectiveDateEndBox
            // 
            EffectiveDateEndBox.Anchor = AnchorStyles.Left;
            EffectiveDateEndBox.Checked = false;
            EffectiveDateEndBox.Format = DateTimePickerFormat.Short;
            EffectiveDateEndBox.Location = new Point(548, 0);
            EffectiveDateEndBox.Margin = new Padding(0, 0, 0, 1);
            EffectiveDateEndBox.MinimumSize = new Size(77, 23);
            EffectiveDateEndBox.Name = "EffectiveDateEndBox";
            EffectiveDateEndBox.ShowCheckBox = true;
            EffectiveDateEndBox.Size = new Size(100, 23);
            EffectiveDateEndBox.TabIndex = 10;
            // 
            // label11
            // 
            label11.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            label11.AutoSize = true;
            label11.Location = new Point(364, 48);
            label11.Name = "label11";
            label11.Size = new Size(63, 24);
            label11.TabIndex = 12;
            label11.Text = "PolicyType";
            label11.TextAlign = ContentAlignment.MiddleRight;
            // 
            // PolicyTypeBox
            // 
            PolicyTypeBox.Dock = DockStyle.Fill;
            PolicyTypeBox.FormattingEnabled = true;
            PolicyTypeBox.Items.AddRange(new object[] { "New", "Renewal" });
            PolicyTypeBox.Location = new Point(430, 48);
            PolicyTypeBox.Margin = new Padding(0, 0, 0, 1);
            PolicyTypeBox.Name = "PolicyTypeBox";
            PolicyTypeBox.Size = new Size(100, 23);
            PolicyTypeBox.TabIndex = 13;
            // 
            // label10
            // 
            label10.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI Symbol", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label10.Location = new Point(12, 259);
            label10.Name = "label10";
            label10.Size = new Size(83, 15);
            label10.TabIndex = 11;
            label10.Text = "Search Critera:";
            // 
            // RefreshAvailablePolicies
            // 
            RefreshAvailablePolicies.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            RefreshAvailablePolicies.Location = new Point(666, 277);
            RefreshAvailablePolicies.Name = "RefreshAvailablePolicies";
            RefreshAvailablePolicies.Size = new Size(79, 23);
            RefreshAvailablePolicies.TabIndex = 12;
            RefreshAvailablePolicies.Text = "Search";
            RefreshAvailablePolicies.UseVisualStyleBackColor = true;
            // 
            // DbImportDialouge
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoValidate = AutoValidate.EnableAllowFocusChange;
            ClientSize = new Size(934, 361);
            Controls.Add(RefreshAvailablePolicies);
            Controls.Add(label10);
            Controls.Add(tableLayoutPanel1);
            Controls.Add(label2);
            Controls.Add(LoadSelectedPolicy);
            Controls.Add(dataGridView1);
            MinimumSize = new Size(950, 400);
            Name = "DbImportDialouge";
            Text = "Import From DB";
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Button button2;
        private Label label1;
        private ErrorProvider errorProvider1;
        private Honeycomb.UI.StronglyTypedControls.TextBoxes.DoubleTextBox decimalTextBox1;
        private Label label2;
        private TextBox PolicyNameBox;
        private TextBox UnderWriterNameBox;
        private TextBox StateBox;
        private Label label10;
        private TableLayoutPanel tableLayoutPanel1;
        private Label label9;
        private Label label6;
        private DateTimePicker SaveDateEndBox;
        private Label label5;
        private DateTimePicker SaveDateStartBox;
        private Label label3;
        private Label label4;
        private Label label7;
        private DateTimePicker EffectiveDateStartBox;
        private Label label8;
        private DateTimePicker EffectiveDateEndBox;
        private Label label11;
        private ComboBox PolicyTypeBox;
        private DataGridViewTextBoxColumn SaveIdColumn;
        private DataGridViewTextBoxColumn DateColumn;
        private DataGridViewTextBoxColumn UnderwriterNameColumn;
        private DataGridViewTextBoxColumn PolicyNameColumn;
        private DataGridViewTextBoxColumn EffectiveDateColumn;
        private DataGridViewTextBoxColumn StateColumn;
        public DataGridView dataGridView1;
        public Button LoadSelectedPolicy;
        public Button RefreshAvailablePolicies;
    }
}