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
            HoneyComb.UI.StronglyTypedControls.StronglyTypedTag stronglyTypedTag2 = new HoneyComb.UI.StronglyTypedControls.StronglyTypedTag();
            HoneyComb.UI.StronglyTypedControls.StronglyTypedTag stronglyTypedTag3 = new HoneyComb.UI.StronglyTypedControls.StronglyTypedTag();
            intComboBox1 = new Honeycomb.UI.StronglyTypedControls.ComboBoxes.IntComboBox();
            intTextBox1 = new Honeycomb.UI.StronglyTypedControls.TextBoxes.IntTextBox();
            button1 = new Button();
            button2 = new Button();
            flowLayoutPanel1 = new FlowLayoutPanel();
            decimalCompositeFactor1 = new HoneyComb.UI.StronglyTypedControls.CompositeControls.DecimalCompositeFactor();
            label1 = new Label();
            decimalTextBox1 = new Honeycomb.UI.StronglyTypedControls.TextBoxes.DecimalTextBox();
            decimalCompositeFactor1.SuspendLayout();
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
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Location = new Point(1315, 136);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(227, 96);
            flowLayoutPanel1.TabIndex = 6;
            // 
            // decimalCompositeFactor1
            // 
            decimalCompositeFactor1.BackColor = SystemColors.ButtonShadow;
            decimalCompositeFactor1.Controls.Add(label1);
            decimalCompositeFactor1.Controls.Add(decimalTextBox1);
            decimalCompositeFactor1.FactorBox = decimalTextBox1;
            decimalCompositeFactor1.Label = label1;
            decimalCompositeFactor1.Location = new Point(380, 64);
            decimalCompositeFactor1.Name = "decimalCompositeFactor1";
            decimalCompositeFactor1.Padding = new Padding(10);
            decimalCompositeFactor1.Size = new Size(507, 93);
            decimalCompositeFactor1.TabIndex = 7;
            decimalCompositeFactor1.Text = "decimalCompositeFactor1";
            // 
            // label1
            // 
            label1.BackColor = SystemColors.ActiveCaption;
            label1.Location = new Point(13, 19);
            label1.Margin = new Padding(3, 0, 0, 0);
            label1.Name = "label1";
            label1.Size = new Size(129, 51);
            label1.TabIndex = 8;
            label1.Text = "label1";
            // 
            // decimalTextBox1
            // 
            decimalTextBox1.Available = true;
            decimalTextBox1.BackColor = SystemColors.Window;
            decimalTextBox1.Location = new Point(172, 19);
            decimalTextBox1.Margin = new Padding(30, 3, 3, 3);
            decimalTextBox1.Name = "decimalTextBox1";
            decimalTextBox1.Size = new Size(173, 31);
            decimalTextBox1.TabIndex = 8;
            stronglyTypedTag3.PasteableFromExcel = true;
            decimalTextBox1.Tag = stronglyTypedTag3;
            decimalTextBox1.TemporaryText = null;
            // 
            // DemoForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(2169, 1062);
            Controls.Add(decimalCompositeFactor1);
            Controls.Add(flowLayoutPanel1);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(intTextBox1);
            Controls.Add(intComboBox1);
            DoubleBuffered = true;
            Name = "DemoForm";
            Text = "Form1";
            decimalCompositeFactor1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Honeycomb.UI.StronglyTypedControls.ComboBoxes.IntComboBox intComboBox1;
        private Honeycomb.UI.StronglyTypedControls.TextBoxes.IntTextBox intTextBox1;
        private Button button1;
        private Button button2;
        private HoneyComb.UI.BaseComponents.FontScalingLabel adaptiveFontLabel1;
        private FlowLayoutPanel flowLayoutPanel1;
        private HoneyComb.UI.StronglyTypedControls.CompositeControls.DecimalCompositeFactor decimalCompositeFactor1;
        private Label label1;
        private Honeycomb.UI.StronglyTypedControls.TextBoxes.DecimalTextBox decimalTextBox1;
    }
}