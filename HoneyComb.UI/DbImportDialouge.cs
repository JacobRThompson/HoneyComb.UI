
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

        public string PolicyType
        {
            get => PolicyTypeBox.Text;
            set
            {
                PolicyTypeBox.Text = value;
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
                    filterSubstrings.Add($"{UNDERWRITER_NAME_COLUMN} LIKE '{UnderwriterName}'");
                }
                if (!string.IsNullOrWhiteSpace(State))
                {
                    filterSubstrings.Add($"{ACCOUNT_STATE_COLUMN} LIKE '{State}'");
                }
                if (!string.IsNullOrWhiteSpace(PolicyType))
                {
                    filterSubstrings.Add($"{POLICY_TYPE_COLUMN} LIKE '{PolicyType}'");
                }
                if (!string.IsNullOrWhiteSpace(PolicyName))
                {
                    filterSubstrings.Add($"{POLICY_NAME_COLUMN} LIKE '{PolicyName}'");
                }

                string result;
                if(filterSubstrings.Count == 0)
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

    }
}
