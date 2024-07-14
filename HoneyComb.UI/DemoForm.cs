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

        private readonly Random Rng = new Random();
        private readonly List<string> dummyConsoleOutput = new();

        private readonly MultiSelector _multSelector;
        public DemoForm()
        {
            InitializeComponent();
            _multSelector = new MultiSelector(this)
            {
                SelectionColor = Color.Blue.ToAlpha(20)
            };

           
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //
            //var valueSource = StringExtensions.
            //    SplitClipboardCells(Clipboard.GetText()).
            //    GetEnumerator();
            //
            //var rowSource = dataGridView1.SelectedCells.
            //    OrderByPosition().
            //    GetEnumerator();
            //
            //IEnumerable<string> newRowValues;
            //while (rowSource.MoveNext() & valueSource.MoveNext())
            //{
            //    newRowValues = valueSource.Current;
            //    rowSource.Current.Populate(newRowValues);
            //
            //}


            intComboBox1.RawValues = intComboBox1.RawValues.Append(Rng.Next(-100, 100));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            intComboBox1.SetValue(Rng.Next(-100, 100));
        }


        
    }
}