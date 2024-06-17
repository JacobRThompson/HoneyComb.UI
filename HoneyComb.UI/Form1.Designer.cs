namespace HoneyCombTests
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
            dataGridView1 = new DataGridView();
            Column1 = new DataGridViewTextBoxColumn();
            Column2 = new DataGridViewTextBoxColumn();
            Column3 = new DataGridViewTextBoxColumn();
            Column4 = new DataGridViewTextBoxColumn();
            Column5 = new HoneyComb.UI.StronglyTypedControls.TextBoxes.IntDataGridViewTextBox();
            button1 = new Button();
            button2 = new Button();
            honeycombComboBox1 = new Honeycomb.UI.HoneycombComboBox();
            intTextBox1 = new Honeycomb.UI.StronglyTypedControls.TextBoxes.IntTextBox();
            intTextBox2 = new Honeycomb.UI.StronglyTypedControls.TextBoxes.IntTextBox();
            intTextBox3 = new Honeycomb.UI.StronglyTypedControls.TextBoxes.IntTextBox();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.AllowDrop = true;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { Column1, Column2, Column3, Column4, Column5 });
            dataGridView1.Location = new Point(632, 208);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 62;
            dataGridView1.Size = new Size(826, 412);
            dataGridView1.TabIndex = 0;
            // 
            // Column1
            // 
            Column1.HeaderText = "Column1";
            Column1.MinimumWidth = 8;
            Column1.Name = "Column1";
            Column1.Width = 150;
            // 
            // Column2
            // 
            Column2.HeaderText = "Column2";
            Column2.MinimumWidth = 8;
            Column2.Name = "Column2";
            Column2.Width = 150;
            // 
            // Column3
            // 
            Column3.HeaderText = "Column3";
            Column3.MinimumWidth = 8;
            Column3.Name = "Column3";
            Column3.Width = 150;
            // 
            // Column4
            // 
            Column4.HeaderText = "Column4";
            Column4.MinimumWidth = 8;
            Column4.Name = "Column4";
            Column4.Width = 150;
            // 
            // Column5
            // 
            Column5.HeaderText = "Column5";
            Column5.MinimumWidth = 8;
            Column5.Name = "Column5";
            Column5.Width = 150;
            // 
            // button1
            // 
            button1.Location = new Point(1043, 76);
            button1.Name = "button1";
            button1.Size = new Size(135, 43);
            button1.TabIndex = 1;
            button1.Text = "button1";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(267, 73);
            button2.Name = "button2";
            button2.Size = new Size(164, 48);
            button2.TabIndex = 2;
            button2.Text = "button2";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // honeycombComboBox1
            // 
            honeycombComboBox1.FormattingEnabled = true;
            honeycombComboBox1.ItemHeight = 25;
            honeycombComboBox1.Location = new Point(103, 208);
            honeycombComboBox1.Name = "honeycombComboBox1";
            honeycombComboBox1.Size = new Size(132, 33);
            honeycombComboBox1.TabIndex = 3;
            // 
            // intTextBox1
            // 
            intTextBox1.Available = true;
            intTextBox1.Location = new Point(389, 208);
            intTextBox1.Name = "intTextBox1";
            intTextBox1.Size = new Size(153, 31);
            intTextBox1.TabIndex = 4;
            // 
            // intTextBox2
            // 
            intTextBox2.Available = true;
            intTextBox2.Location = new Point(376, 324);
            intTextBox2.Name = "intTextBox2";
            intTextBox2.Size = new Size(153, 31);
            intTextBox2.TabIndex = 5;
            // 
            // intTextBox3
            // 
            intTextBox3.Available = true;
            intTextBox3.Location = new Point(82, 324);
            intTextBox3.Name = "intTextBox3";
            intTextBox3.Size = new Size(153, 31);
            intTextBox3.TabIndex = 6;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1621, 809);
            Controls.Add(intTextBox3);
            Controls.Add(intTextBox2);
            Controls.Add(intTextBox1);
            Controls.Add(honeycombComboBox1);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(dataGridView1);
            DoubleBuffered = true;
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewTextBoxColumn Column2;
        private DataGridViewTextBoxColumn Column3;
        private Button button1;
        private DataGridViewTextBoxColumn Column4;
        private HoneyComb.UI.StronglyTypedControls.TextBoxes.IntDataGridViewTextBox Column5;
        private Button button2;
        private Honeycomb.UI.HoneycombComboBox honeycombComboBox1;
        private Honeycomb.UI.StronglyTypedControls.TextBoxes.IntTextBox intTextBox1;
        private Honeycomb.UI.StronglyTypedControls.TextBoxes.IntTextBox intTextBox2;
        private Honeycomb.UI.StronglyTypedControls.TextBoxes.IntTextBox intTextBox3;
    }
}