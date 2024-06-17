using Honeycomb.UI.StronglyTypedControls.TextBoxes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoneyComb.UI.StronglyTypedControls.TextBoxes
{
    public class IntDataGridViewTextBox: DataGridViewColumn
    {
        public IntDataGridViewTextBox()  : base(new DataGridViewTextBoxCell())
        { 
        }

        public override DataGridViewCell CellTemplate
        {
            get
            {
                return base.CellTemplate;
            }
            set
            {
                // Ensure that the cell used for the template is an IntTextBoxCell
                if (value != null &&
                    !value.GetType().IsAssignableFrom(typeof(IntTextBoxCell)))
                {
                    throw new InvalidCastException("Must be an IntTextBoxCell");
                }
                base.CellTemplate = value;
            }
        }
    }


    public class IntTextBoxCell: DataGridViewTextBoxCell
    {
        public override void InitializeEditingControl(
            int rowIndex, object initialFormattedValue, DataGridViewCellStyle dataGridViewCellStyle)
        {
            // Set the value of the editing control to the current cell value.
            base.InitializeEditingControl(rowIndex, initialFormattedValue, dataGridViewCellStyle);

            IntTextBoxEditingControl ctl = (DataGridView.EditingControl as IntTextBoxEditingControl)!;

            ctl.EditingControlFormattedValue = Value?? DefaultNewRowValue;
        }

        public override Type EditType => typeof(IntTextBoxEditingControl);

        public override Type ValueType => typeof(int);

        public override object DefaultNewRowValue => 0;

        protected override object GetValue(int rowIndex)
        {
            return base.GetValue(rowIndex);
        }

        protected override bool SetValue(int rowIndex, object value)
        {
            return base.SetValue(rowIndex, value);
        }

    }


    public class IntTextBoxEditingControl : IntTextBox, IDataGridViewEditingControl
    {
        private DataGridView? _dataGridView;
        private bool _valueChanged = false;
        private int _rowIndex;
        public object EditingControlFormattedValue
        {
            get
            {
                if (TryGetValue(out int result))
                {
                    return result;
                }
                else
                {
                    return null;
                }
            }
            set
            {
                if ( value is int v)
                {
                    SetValue(v);
                }
                else if (value is string s)
                {
                    if (Parser.TryParse(s,out int parseResult))
                    {
                        SetValue(parseResult);
                    }
                }
            }
        }

        public override bool Dirty
        {
            get => base.Dirty;
            protected set
            {
                base.Dirty = value;
                EditingControlDataGridView?.NotifyCurrentCellDirty(value);
            }
        }


        public DataGridView? EditingControlDataGridView { 
            get => _dataGridView; 
            set => _dataGridView = value; 
        }
        public int EditingControlRowIndex
        {
            get => _rowIndex;
            set => _rowIndex = value;
        }

        public bool EditingControlValueChanged
        {
            get => _valueChanged; 
            set => _valueChanged = value;
        }

        public Cursor EditingPanelCursor => base.Cursor;

        public bool RepositionEditingControlOnValueChange => false;

        public void ApplyCellStyleToEditingControl(DataGridViewCellStyle dataGridViewCellStyle)
        {
            this.DefaultFont = dataGridViewCellStyle.Font;
            this.DefaultForeColor = dataGridViewCellStyle.ForeColor;
            this.DefaultBackColor = dataGridViewCellStyle.BackColor;
        }

        // Implements the IDataGridViewEditingControl.EditingControlWantsInputKey
        // method.
        public bool EditingControlWantsInputKey(
            Keys key, bool dataGridViewWantsInputKey)
        {           
            switch (key & Keys.KeyCode)
            {
                case Keys.Left:
                case Keys.Up:
                case Keys.Down:
                case Keys.Right:
                case Keys.Home:
                case Keys.End:
                case Keys.PageDown:
                case Keys.PageUp:
                case Keys.Enter:
                    return true;
                default:
                    return !dataGridViewWantsInputKey;
            }
        }

        public object GetEditingControlFormattedValue(DataGridViewDataErrorContexts context) => EditingControlFormattedValue;

        public void PrepareEditingControlForEdit(bool selectAll){}
    }

}
