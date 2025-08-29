
using Honeycomb.UI.StronglyTypedControls.ComboBoxes;
using Honeycomb.UI.StronglyTypedControls.TextBoxes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Honeycomb.UI
{
    public partial class DbImportDialouge : Form
    {
        public const string ACCOUNT_STATE_COLUMN = "account_information@account_state";
        public const string EFFECTIVE_DATE_COLUMN = "account_information@effective_date";
        public const string POLICY_NAME_COLUMN = "account_information@policy_holder_name";
        public const string POLICY_TYPE_COLUMN = "policy_type";
        public const string SAVE_ID_COLUMN = "save_id";
        public const string SAVE_DATE_COLUMN = "save_date";
        public const string UNDERWRITER_NAME_COLUMN = "account_information@underwriter_name";
        public const string POLICY_NO_COLUMN = "account_information@policy_number";

        protected bool _queryAutomatically = false;

        public DbImportDialouge()
        {
            InitializeComponent();

            SaveDateEnd = DateTime.Now;
        }

        public DateTime SaveDateStart
        {
            get => SaveDateStartBox.Value.Date;
            set
            {
                SaveDateStartBox.Value = value;
            }
        }

        public DateTime SaveDateEnd
        {
            get => SaveDateEndBox.Value.AddDays(1).Date;
            set
            {
                SaveDateEndBox.Value = value;
            }
        }

        public DateTime EffectiveDateStart
        {
            get => EffectiveDateStartBox.Value.Date;
            set
            {
                EffectiveDateStartBox.Value = value;
            }
        }

        public DateTime EffectiveDateEnd
        {
            get => EffectiveDateEndBox.Value.AddDays(1).Date;
            set
            {
                EffectiveDateEndBox.Value = value;
            }
        }

        public string PolicyName
        {
            get => PolicyNameBox.Text;
            set
            {
                PolicyNameBox.Text = value;
            }
        }

        public string PolicyNo
        {
            get => textBox1.Text;
            set
            {
                textBox1.Text = value;
            }
        }

        public string UnderwriterName
        {
            get => UnderWriterNameBox.Text;
            set
            {
                UnderWriterNameBox.Text = value;
            }
        }

        public string State
        {
            get => StateBox.Text;
            set
            {
                StateBox.Text = value;
            }
        }

        /// <summary>
        /// The WHERE clause used when retrieving saved quotes
        /// </summary>
        public string Filter
        {
            get
            {
                List<string> filterSubstrings = new();

                if (SaveDateEndBox.Checked)
                {
                    filterSubstrings.Add($"{SAVE_DATE_COLUMN} < '{SaveDateEnd:s}'");
                }
                if (SaveDateStartBox.Checked)
                {
                    filterSubstrings.Add($"{SAVE_DATE_COLUMN} > '{SaveDateStart:s}'");
                }
                if (EffectiveDateStartBox.Checked)
                {
                    filterSubstrings.Add($"{EFFECTIVE_DATE_COLUMN} > '{EffectiveDateStart:s}'");
                }
                if (EffectiveDateEndBox.Checked)
                {
                    filterSubstrings.Add($"{EFFECTIVE_DATE_COLUMN} < '{EffectiveDateEnd:s}'");
                }
                if (!string.IsNullOrWhiteSpace(UnderwriterName))
                {
                    filterSubstrings.Add($"{UNDERWRITER_NAME_COLUMN} LIKE '%{UnderwriterName}%'");
                }
                if (!string.IsNullOrWhiteSpace(State))
                {
                    filterSubstrings.Add($"{ACCOUNT_STATE_COLUMN} LIKE '%{State}%'");
                }
                if (!string.IsNullOrWhiteSpace(PolicyNo))
                {
                    filterSubstrings.Add($"{POLICY_NO_COLUMN} LIKE '%{PolicyNo}%'");
                }
                if (!string.IsNullOrWhiteSpace(PolicyName))
                {
                    filterSubstrings.Add($"{POLICY_NAME_COLUMN} LIKE '%{PolicyName}%'");
                }

                string result;
                if (filterSubstrings.Count == 0)
                {
                    result = "";
                }
                else
                {
                    result = "WHERE \n" + string.Join(" AND \n", filterSubstrings);
                }

                return result;
            }
        }

        public void UpdateRowVisibility(ItemCheckEventArgs? e)
        {
            SuspendLayout();

            bool underwriterRequired;
            bool policyNameRequired;
            bool policyNumberRequired;
            bool effectiveDateRequired;

            if (e is null)
            {
                underwriterRequired = AllowMissingList.GetItemCheckState(0) != CheckState.Checked;
                policyNameRequired = AllowMissingList.GetItemCheckState(1) != CheckState.Checked;
                policyNumberRequired = AllowMissingList.GetItemCheckState(2) != CheckState.Checked;
                effectiveDateRequired = AllowMissingList.GetItemCheckState(3) != CheckState.Checked;
            }
            else
            {
                underwriterRequired = (e.Index == 0 ? e.NewValue : AllowMissingList.GetItemCheckState(0)) != CheckState.Checked;
                policyNameRequired = (e.Index == 1 ? e.NewValue : AllowMissingList.GetItemCheckState(1)) != CheckState.Checked;
                policyNumberRequired = (e.Index == 2 ? e.NewValue : AllowMissingList.GetItemCheckState(2)) != CheckState.Checked;
                effectiveDateRequired = (e.Index == 3 ? e.NewValue : AllowMissingList.GetItemCheckState(3)) != CheckState.Checked;

            }
          
            bool showCurrentRow ;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {

                string? underWriterName = row.Cells[2].Value?.ToString();
                string? policyName = row.Cells[3].Value?.ToString();
                string? policyNumber = row.Cells[4].Value?.ToString();

                //This value is a DateTime if we can parse the string contents and null otherwise
                DateTime? effectiveDate = DateTime.TryParse(row.Cells[5].Value?.ToString(), out DateTime result) ?
                    result :
                    null;

                if (underwriterRequired && string.IsNullOrEmpty(underWriterName))
                {
                    showCurrentRow = false;
                }
                else if (policyNameRequired && string.IsNullOrEmpty(policyName))
                {
                    showCurrentRow = false;
                }
                else if (policyNumberRequired && string.IsNullOrEmpty(policyNumber))
                {
                    showCurrentRow = false;
                }
                else if (effectiveDateRequired && effectiveDate is null)
                {
                    showCurrentRow = false;
                }
                else
                {
                    showCurrentRow = true;
                }

                row.Visible = showCurrentRow;
             
            }

            ResumeLayout();
        }

        private void AllowMissingList_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            UpdateRowVisibility(e);
        }

        private void dataGridView1_SortCompare(object sender, DataGridViewSortCompareEventArgs e)
        {
            switch (e.Column.HeaderText)
            {
                case "Save Date":
                case "Effective Date":

                    //Attempt to parse cell text as date. If cell value cannot be parsed, the smallest possible datetime value is used instead.
                    DateTime cell1_date = DateTime.TryParse(e.CellValue1?.ToString(), out DateTime result1) ? result1 : DateTime.MinValue;
                    DateTime cell2_date = DateTime.TryParse(e.CellValue2?.ToString(), out DateTime result2) ? result2 : DateTime.MinValue;

                    e.SortResult = DateTime.Compare(cell1_date, cell2_date);
                    break;
                                 
                default:

                    string val1 = e.CellValue1?.ToString() ?? string.Empty;
                    string val2 = e.CellValue2?.ToString() ?? string.Empty;

                    e.SortResult = string.Compare(val1, val2);
                    break;             
            }

            e.Handled = true;
        }
    }
}
