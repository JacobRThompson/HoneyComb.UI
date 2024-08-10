﻿namespace HoneyCombTests
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
            HoneyComb.UI.StronglyTypedControls.StronglyTypedTag stronglyTypedTag2 = new HoneyComb.UI.StronglyTypedControls.StronglyTypedTag();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DemoForm));
            intComboBox1 = new Honeycomb.UI.StronglyTypedControls.ComboBoxes.IntComboBox();
            intTextBox1 = new Honeycomb.UI.StronglyTypedControls.TextBoxes.IntTextBox();
            button1 = new Button();
            button2 = new Button();
            label1 = new Label();
            adaptiveFontLabel1 = new HoneyComb.UI.BaseComponents.AdaptiveFontLabel();
            SuspendLayout();
            // 
            // intComboBox1
            // 
            intComboBox1.Available = true;
            intComboBox1.DropdownStyle = ComboBoxStyle.DropDownList;
            intComboBox1.Location = new Point(726, 404);
            intComboBox1.Name = "intComboBox1";
            intComboBox1.SelectedIndex = -1;
            intComboBox1.Size = new Size(225, 31);
            intComboBox1.TabIndex = 0;
            stronglyTypedTag1.PasteableFromExcel = true;
            intComboBox1.Tag = stronglyTypedTag1;
            intComboBox1.TemporaryText = null;
            // 
            // intTextBox1
            // 
            intTextBox1.Available = true;
            intTextBox1.Location = new Point(1169, 398);
            intTextBox1.Name = "intTextBox1";
            intTextBox1.Size = new Size(233, 31);
            intTextBox1.TabIndex = 1;
            stronglyTypedTag2.PasteableFromExcel = true;
            intTextBox1.Tag = stronglyTypedTag2;
            intTextBox1.TemporaryText = null;
            // 
            // button1
            // 
            button1.Location = new Point(1517, 374);
            button1.Name = "button1";
            button1.Size = new Size(230, 61);
            button1.TabIndex = 2;
            button1.Text = "button1";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(1532, 490);
            button2.Name = "button2";
            button2.Size = new Size(212, 46);
            button2.TabIndex = 3;
            button2.Text = "button2";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // label1
            // 
            label1.Location = new Point(640, 631);
            label1.Name = "label1";
            label1.Size = new Size(116, 61);
            label1.TabIndex = 4;
            label1.Text = "label1";
            // 
            // adaptiveFontLabel1
            // 
            adaptiveFontLabel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            adaptiveFontLabel1.AvailableFontSizes = (List<float>)resources.GetObject("adaptiveFontLabel1.AvailableFontSizes");
            adaptiveFontLabel1.BackColor = SystemColors.ControlDark;
            adaptiveFontLabel1.Font = new Font("Segoe UI", 20F, FontStyle.Regular, GraphicsUnit.Point);
            adaptiveFontLabel1.Location = new Point(177, 98);
            adaptiveFontLabel1.Name = "adaptiveFontLabel1";
            adaptiveFontLabel1.Size = new Size(528, 175);
            adaptiveFontLabel1.TabIndex = 5;
            adaptiveFontLabel1.Text = "This is some text that needs to be resized";
            // 
            // DemoForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(2169, 1062);
            Controls.Add(adaptiveFontLabel1);
            Controls.Add(label1);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(intTextBox1);
            Controls.Add(intComboBox1);
            DoubleBuffered = true;
            Name = "DemoForm";
            Text = "Form1";
            ResumeLayout(false);
        }

        #endregion

        private Honeycomb.UI.StronglyTypedControls.ComboBoxes.IntComboBox intComboBox1;
        private Honeycomb.UI.StronglyTypedControls.TextBoxes.IntTextBox intTextBox1;
        private Button button1;
        private Button button2;
        private Label label1;
        private HoneyComb.UI.BaseComponents.AdaptiveFontLabel adaptiveFontLabel1;
    }
}