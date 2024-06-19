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
            if (intTextBox1.TryGetValue(out var result))
            {
                button2.Text = result.ToString();
            }
        }

        Color c;
        private void button3_Click_1(object sender, EventArgs e)
        {

            var pasteableControls = _multSelector.SelectedControls
                .Where(ctrl => ctrl.Tag is IExcelPasteTarget tag && tag.PasteableFromExcel);

            var controlRowSource = Algorithms
                .GenerateRows(pasteableControls)
                .GetEnumerator();

            var valueRowSource = StringExtensions.
                SplitClipboardCells(Clipboard.GetText()).
                GetEnumerator();

           
            IEnumerator<string> valueSource;
            IEnumerator<Control> controlSource;
            while (controlRowSource.MoveNext() & valueRowSource.MoveNext())
            {
                c = Colors.GenerateRandom();
                valueSource = valueRowSource.Current.GetEnumerator()!;
                controlSource = controlRowSource.Current.AsEnumerable().GetEnumerator()!;

                while (controlSource.MoveNext() & valueSource.MoveNext())
                {
                    controlSource.Current.Text = valueSource.Current;
                    controlSource.Current.BackColor = c;
                }
            }
        }
    }
}