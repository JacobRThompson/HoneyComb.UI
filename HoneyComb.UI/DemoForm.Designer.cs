namespace HoneyCombTests
{
    partial class DemoForm
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
            HoneyComb.UI.StronglyTypedControls.StronglyTypedTag stronglyTypedTag1 = new HoneyComb.UI.StronglyTypedControls.StronglyTypedTag();
            button1 = new Button();
            button2 = new Button();
            intComboBox1 = new Honeycomb.UI.StronglyTypedControls.ComboBoxes.IntComboBox();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(663, 330);
            button1.Name = "button1";
            button1.Size = new Size(135, 43);
            button1.TabIndex = 1;
            button1.Text = "button1";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(467, 330);
            button2.Name = "button2";
            button2.Size = new Size(164, 48);
            button2.TabIndex = 2;
            button2.Text = "button2";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // intComboBox1
            // 
            intComboBox1.Available = true;
            intComboBox1.DropdownStyle = ComboBoxStyle.DropDownList;
            intComboBox1.FormatString = "0";
            intComboBox1.Location = new Point(900, 656);
            intComboBox1.Name = "intComboBox1";
            intComboBox1.SelectedIndex = -1;
            intComboBox1.Size = new Size(220, 31);
            intComboBox1.Suffix = " Items";
            intComboBox1.TabIndex = 20;
            stronglyTypedTag1.PasteableFromExcel = true;
            intComboBox1.Tag = stronglyTypedTag1;
            // 
            // DemoForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(2168, 1141);
            Controls.Add(intComboBox1);
            Controls.Add(button2);
            Controls.Add(button1);
            DoubleBuffered = true;
            Name = "DemoForm";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
        }

        #endregion
        private Button button1;
        private Button button2;
        private Honeycomb.UI.StronglyTypedControls.ComboBoxes.IntComboBox intComboBox1;
    }
}