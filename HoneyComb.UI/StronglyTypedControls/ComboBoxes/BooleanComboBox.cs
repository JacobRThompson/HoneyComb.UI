using Honeycomb.UI.BaseComponents.TextBoxParsers;
using Honeycomb.UI.StronglyTypedControls.ControlHost;
using Honeycomb.UI.StronglyTypedControls.TextBoxes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Honeycomb.UI.BaseComponents;

namespace Honeycomb.UI.StronglyTypedControls.ComboBoxes
{
   

    [ToolboxItem(Globals.SHOW_BASE_COMPONENTS_IN_TOOLBOX)]
    public class BooleanComboBox : BooleanControlHost<HoneycombComboBox>
    {
        public const bool AUTO_POPULATE_DEFAULT = true;

        public BooleanComboBox()
        {
            ComboBoxExtension = new(this, Child);
        }

        public ComboBoxHostExtension<HoneycombComboBox, bool> ComboBoxExtension { get; }

        [DefaultValue(AUTO_POPULATE_DEFAULT)]
        public bool AutoPopulate { get; set; } = AUTO_POPULATE_DEFAULT;

        [DefaultValue(ComboBoxHostExtension.NULL_LABEL_DEFAULT)]
        public string NullLabel
        {
            get => ComboBoxExtension.NullLabel;
            set => ComboBoxExtension.NullLabel = value;
        }

        [DefaultValue(ComboBoxHostExtension.PREPEND_NULL_VALUE_DEFAULT)]
        public bool PrependNullValue
        {
            get => ComboBoxExtension.PrependNullValue;
            set => ComboBoxExtension.PrependNullValue = value;
        }

        [DefaultValue(ComboBoxHostExtension.AUTO_SORT_DEFAULT)]
        public bool AutoSort
        {
            get => ComboBoxExtension.AutoSort;
            set => ComboBoxExtension.AutoSort = value;
        }

        public IEnumerable<bool> RawValues
        {
            get => ComboBoxExtension.RawValues;
            set => ComboBoxExtension.RawValues = value;
        }

        public int SelectedIndex
        {
            get => Child.SelectedIndex; 
            set => Child.SelectedIndex = value;
        }

        public ComboBox.ObjectCollection Items => Child.Items;
        public ComboBoxStyle DropdownStyle
        {
            get => Child.DropDownStyle;
            set => Child.DropDownStyle = value;
        }


        public virtual IEnumerable<bool> Sort(IEnumerable<bool> values) => values.Order();

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);

            if(AutoPopulate) RawValues = new bool[] { true, false }.AsEnumerable();
        }

    }
    
}
