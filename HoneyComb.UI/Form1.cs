using Honeycomb.UI.StronglyTypedControls.ComboBoxes;
using System.CodeDom.Compiler;
using HoneyComb.UI.Utils.Extensions;
using Honeycomb.UI.Utils;
using HoneyComb.UI.BaseComponents.MultiSelect;
namespace HoneyCombTests
{
    public partial class Form1 : Form
    {

        private readonly MultiSelector _multSelector;
        public Form1()
        {
            InitializeComponent();
            _multSelector = new MultiSelector(this)
            {
                SelectionColor = Color.Blue.ToAlpha(5)
            };


        }

        private void Form1_Load(object sender, EventArgs e)
        {         
            dataGridView1.Rows.Add();
            dataGridView1.Rows.Add();
            dataGridView1.Rows.Add();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var valueSource = StringExtensions.
                SplitClipboardCells(Clipboard.GetText()).
                GetEnumerator();

            var rowSource = dataGridView1.SelectedCells.
                OrderByPosition().
                GetEnumerator();

            IEnumerable<string> newRowValues;
            while (rowSource.MoveNext() & valueSource.MoveNext())
            {
                newRowValues = valueSource.Current;
                rowSource.Current.Populate(newRowValues);

            }

        }






        private void button2_Click(object sender, EventArgs e)
        {
            var temp = dataGridView1.Rows[0].Cells[4].FormattedValue;

            button2.Text = temp.ToString();
        }
    }
}