using Honeycomb.UI.StronglyTypedControls.ComboBoxes;
using System.CodeDom.Compiler;
using HoneyComb.UI.Utils.Extensions;
using HoneyComb.UI.BaseComponents;
using Honeycomb.UI.Utils;
using HoneyComb.UI.BaseComponents.MultiSelect;
using Honeycomb.UI.StronglyTypedControls.TextBoxes;
namespace HoneyCombTests
{
    public partial class DemoForm : Form
    {
        //private readonly MultiSelector _multSelector;
        public DemoForm()
        {
            InitializeComponent();
            //_multSelector = new MultiSelector(this)
            //{
            //    SelectionColor = Color.Blue.ToAlpha(20)
            //};

            intComboBox1.RawValues = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (intTextBox1.TryGetValue(out int value))
            {
                intComboBox1.SetValue(value);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (intTextBox1.TryGetValue(out int value))
            {
                intComboBox1.RawValues = intComboBox1.RawValues.Append(value);
            }
        }
    }
}